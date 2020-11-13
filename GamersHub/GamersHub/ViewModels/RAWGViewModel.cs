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
using RAWGQTSearch;
using Xamarin.Forms.Internals;

namespace GamersHub.ViewModels
{

    public class RAWGViewModel : INotifyPropertyChanged
    {
        //base url
        string AllGamesURL = "https://api.rawg.io/api/games?key=cccf617d082948b2820d2b26262789c9&page_size=20";
        const string NEWGAMESURL = "https://api.rawg.io/api/games?key=cccf617d082948b2820d2b26262789c9&page_size=20&ordering=released";
        string SearchURL = "https://api.rawg.io/api/games?key=cccf617d082948b2820d2b26262789c9&page_size=10&search=";
        //List for collecting results
        public static List<RAWGQT.Result> datalist = new List<RAWGQT.Result>();
        static HttpClient htp = new HttpClient();
        ObservableCollection<RAWGQTSearch.Result> games;
        // page resuts l
        static string NextSearchResult;
        static string PreviousSearchResult;
        public static string PageCount;

        public event PropertyChangedEventHandler PropertyChanged;
       
        public ICommand LoadCommand { get; }
        public ICommand GetNext { get; }
        public ICommand GetPrevious { get; }
        public RAWGViewModel()
        {
         //   LoadCommand = new Command<ObservableCollection<RAWGQTSearch.Result>>(GetAllGamesAsync);
        }
       

        string name = string.Empty;
        string urlImg = string.Empty;
        public string Name
        {
            get => name;
            set
            {
                if (name == value)
                    return;

                name = value;
                OnPropertyChanged(nameof(name));
                OnPropertyChanged(nameof(Display));
            }
        }

        public string Display => $"Searched For: {Name}";

        void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        //search for the newest games
        public async Task<ObservableCollection<RAWGQT.Result>> GetAllGamesAsync() 
        { 
            string response = await htp.GetStringAsync(AllGamesURL);
            var data = NewReleasedGames.FromJson(response);
            //datalist = data.Results.ToList<RAWGQT.Result>();
            ObservableCollection<RAWGQT.Result> games =
                  new ObservableCollection<RAWGQT.Result>(data.Results.ToList());
            return games;
        }

        //Search for user game
        public async Task<ObservableCollection<RAWGQTSearch.Result>> SearchGamesAsync(string name)
        {
            string response = await htp.GetStringAsync(SearchURL + name);
            var data = UserSearchGame.FromJson(response);
            PageCount = data.Count.ToString();
                //Check for nulls
                if (data.Next.ToString() == null)
                {

                }
                else
                {
                    NextSearchResult = data.Next.ToString();
                }


            // datalist = data.Results.ToList<Result>();
            games = new ObservableCollection<RAWGQTSearch.Result>(data.Results.ToList());
            return games;
        }

        //Load Next reasults
        public async Task<ObservableCollection<RAWGQTSearch.Result>> SearchNextAsync()
        {  
            string response = await htp.GetStringAsync(NextSearchResult);
            var data = UserSearchGame.FromJson(response);
            // datalist = data.Results.ToList<Result>();
            games = new ObservableCollection<RAWGQTSearch.Result>(data.Results.ToList());
            return games;
        }


    }
}
