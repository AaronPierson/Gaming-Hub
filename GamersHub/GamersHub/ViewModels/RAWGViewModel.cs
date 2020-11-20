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
using RAWGQT;
using Xamarin.Forms.Internals;
using RAWGQTDetail;

namespace GamersHub.ViewModels
{

    public class RAWGViewModel  
    {
        //base url
        string AllGamesURL = "https://api.rawg.io/api/games?key=cccf617d082948b2820d2b26262789c9&page_size=10";
        const string APIKEY = "key=cccf617d082948b2820d2b26262789c9";
        const string NEWGAMESURL = "https://api.rawg.io/api/games?key=cccf617d082948b2820d2b26262789c9&page_size=20&ordering=released";
        string SearchURL = "https://api.rawg.io/api/games?key=cccf617d082948b2820d2b26262789c9&page_size=10&search=";
        string DetailsURL = "https://api.rawg.io/api/games/";
        //List for collecting results
        public static List<RAWGQT.Result> datalist = new List<RAWGQT.Result>();
        static HttpClient htp = new HttpClient();
        ObservableCollection<RAWGQT.Result> games;
        // page resuts l
        static string NextSearchResult;
        static string PreviousSearchResult;
        public static string PageCount;



        //search all games
        public async Task<ObservableCollection<RAWGQT.Result>> GetAllGamesAsync()
        {
            string response = await htp.GetStringAsync(AllGamesURL);
            var data = UserSearchGame.FromJson(response);
            PageCount = data.Count.ToString();
            LoadNextPerviousURL(data);
             // datalist = data.Results.ToList<Result>();
             games = new ObservableCollection<RAWGQT.Result>(data.Results.ToList());
            return games;
        }

        public async Task<GamesDetails> GetGameDetails(string id)
        {
            string response = await htp.GetStringAsync(DetailsURL + id + APIKEY);
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
            LoadNextPerviousURL(data);


         // datalist = data.Results.ToList<Result>();
         games = new ObservableCollection<RAWGQT.Result>(data.Results.ToList());
            return games;
        }

      

        //Load Next reasults
        public async Task<ObservableCollection<RAWGQT.Result>> SearchNextAsync()
        {
            string response = await htp.GetStringAsync(NextSearchResult);
            var data = UserSearchGame.FromJson(response);
            LoadNextPerviousURL(data);
            // datalist = data.Results.ToList<Result>();
            games = new ObservableCollection<RAWGQT.Result>(data.Results.ToList());
            return games;
        }

        private static void LoadNextPerviousURL(UserSearchGame data)
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
                PreviousSearchResult = data.Next.ToString();

            }
        }
    }
}
