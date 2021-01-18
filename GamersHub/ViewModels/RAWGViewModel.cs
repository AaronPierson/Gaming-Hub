using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using RAWGQT;
using System.Linq;
using Xamarin.Forms;
using System.ComponentModel;
using System.Windows.Input;
using HttpTracer;
using Xamarin.Forms.Internals;
using RAWGQTDetail;
using RAGWAchievements;

namespace GamersHub.ViewModels
{

    public class RAWGViewModel  
    {
        //base url
        string AllGamesURL = "https://api.rawg.io/api/games?key=cccf617d082948b2820d2b26262789c9&page_size=10";
        const string APIKEY = "key=cccf617d082948b2820d2b26262789c9";
        const string NEWGAMESURL = "https://api.rawg.io/api/games?key=cccf617d082948b2820d2b26262789c9&page_size=20&ordering=released";
        private const string pageSize = "&page_size=10";
        string SearchURL = "https://api.rawg.io/api/games?key=cccf617d082948b2820d2b26262789c9&page_size=10&search=";
        string DetailsURL = "https://api.rawg.io/api/games/";

        // private string SearchURL = "https://api.rawg.io/api/games?key=cccf617d082948b2820d2b26262789c9&page_size=10&search=";
        private string BaseURL = "https://api.rawg.io/api/games";
        private string todayDate;
        private string twoWeeksAgo;
        private string futureRelease;
        private string monthAgo;
      
        // page resuts 
        static string NextSearchResult;
        static string PreviousSearchResult;
        public static string PageCount;
        //
        public RAWGViewModel()
        {
            todayDate = DateTime.Now.ToString("yyyy'-'MM'-'dd");
            twoWeeksAgo = DateTime.Now.AddDays(-14).ToString("yyyy'-'MM'-'dd"); ;
            futureRelease = DateTime.MaxValue.ToString("yyyy'-'MM'-'dd");
            monthAgo = DateTime.Now.AddDays(-30).ToString("yyyy'-'MM'-'dd"); ;

        }

        //List for collecting result
       // static List<RAGWAchievements.Result> Achievements = new List<RAGWAchievements.Result>();
         HttpClient htp = new HttpClient(new HttpTracerHandler
        {
            Verbosity = HttpMessageParts.All
        });
        ObservableCollection<RAWGQT.Result> games;
        ObservableCollection<RAGWAchievements.Result> Achievements;
        //search all games
        public async Task<ObservableCollection<RAWGQT.Result>> GetAllGamesAsync()
        {
            string response = await htp.GetStringAsync(AllGamesURL);
            var data = UserSearchGame.FromJson(response);
            PageCount = data.Count.ToString();
            BackNextNullChecker(data);
             // datalist = data.Results.ToList<Result>();
             games = new ObservableCollection<RAWGQT.Result>(data.Results.ToList());
            return games;
        }

        public async Task<ObservableCollection<RAGWAchievements.Result>> GetAchievementsAsync(string id)
        {
            string response = await htp.GetStringAsync(String.Format("https://api.rawg.io/api/games/{0}/achievements", id.ToString()));
            var data = AchievementsModel.FromJson(response);
            string url = "";
            int i = 1;
            while (data.Next != null)
            {
                i++;
                url = data.Next.AbsoluteUri.Remove(data.Next.AbsoluteUri.Length -1, 1) + i;
                try
                {
                    string _res = await htp.GetStringAsync(url);
                    var _data = AchievementsModel.FromJson(_res);
                    data.Results.AddRange(_data.Results);
                }
                catch (Exception)
                {
                    Achievements = new ObservableCollection<RAGWAchievements.Result>(data.Results.ToList());
                    return Achievements;
                }               
                    
               
            }
            //return new ObservableCollection<RAGWAchievements.Result>(data.Results.ToList());
             Achievements = new ObservableCollection<RAGWAchievements.Result>(data.Results.ToList());
            return Achievements;
        }

        public async Task<ObservableCollection<RAWGQT.Result>> GetUpComingGamesAsync()
        {
            string LatestURL = BaseURL + "?dates=" + todayDate + "," + futureRelease + pageSize + "&" + "ordering=-added" + APIKEY;
            string response = await htp.GetStringAsync(LatestURL);
            var data = UserSearchGame.FromJson(response);
            BackNextNullChecker(data);
            games = new ObservableCollection<RAWGQT.Result>(data.Results.ToList());
            return games;
        }

        public async Task<ObservableCollection<RAWGQT.Result>> GetHighestRatedGamesAsync()
        {
            string LatestURL = BaseURL + "?dates=" + monthAgo + "," + todayDate + pageSize + "&" + "ordering=-rating" + APIKEY;
            string response = await htp.GetStringAsync(LatestURL);
            var data = UserSearchGame.FromJson(response);
            BackNextNullChecker(data);
            games = new ObservableCollection<RAWGQT.Result>(data.Results.ToList());
            return games;
        }

        //lastes games
        public async Task<ObservableCollection<RAWGQT.Result>> GetLatestesGamesAsync()
        {
            string LatestURL = BaseURL + "?dates=" + twoWeeksAgo + "," + todayDate + pageSize + "&" + APIKEY;
            string response = await htp.GetStringAsync(LatestURL);
            var data = UserSearchGame.FromJson(response);
            BackNextNullChecker(data);
            games = new ObservableCollection<RAWGQT.Result>(data.Results.ToList());
            return games;
        }

        public async Task<GamesDetails> GetGameDetails(string id)
        {
            string response = await htp.GetStringAsync(DetailsURL + id + "?" + APIKEY);
            var data = GamesDetails.FromJson(response);
            //datalist = data.Results.ToList<RAWGQT.Result>();
            //ObservableCollection<GamesDetails> gamesinfo =
             //     new ObservableCollection<GamesDetails>(data);      
            return data;
        }

        //Search for user game
        public async Task<ObservableCollection<RAWGQT.Result>> SearchGamesAsync(string name)
        {
            string response = await htp.GetStringAsync(SearchURL + name);
            var data = UserSearchGame.FromJson(response);
            PageCount = data.Count.ToString();
            //Check for nulls
            BackNextNullChecker(data);
         // datalist = data.Results.ToList<Result>();
         games = new ObservableCollection<RAWGQT.Result>(data.Results.ToList());
            return games;
        }

        //Load Next reasults
        public async Task<ObservableCollection<RAWGQT.Result>> SearchNextAsync()
        {
            string response = await htp.GetStringAsync(NextSearchResult);
            var data = UserSearchGame.FromJson(response);
            BackNextNullChecker(data);
            // datalist = data.Results.ToList<Result>();
            games = new ObservableCollection<RAWGQT.Result>(data.Results.ToList());
            return games;
        }

        //Load Pervious reasults
        public async Task<ObservableCollection<RAWGQT.Result>> SearchPerviousAsync()
        {
            string response = await htp.GetStringAsync(PreviousSearchResult);
            var data = UserSearchGame.FromJson(response);
            BackNextNullChecker(data);
            // datalist = data.Results.ToList<Result>();
            games = new ObservableCollection<RAWGQT.Result>(data.Results.ToList());
            return games;
        }

        public static void BackNextNullChecker(UserSearchGame data)
        {
            //next
            if (data.Next == null)
            {
                // do nothing
            }
            else
            {
                NextSearchResult = data.Next.ToString();
            }
            //Pervious
            if(data.Previous == null)
            {

            }
            else
            {
                PreviousSearchResult = data.Previous.ToString();
            }
        }
    }
}
