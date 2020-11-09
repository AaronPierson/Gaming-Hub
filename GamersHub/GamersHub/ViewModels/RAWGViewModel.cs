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

namespace GamersHub.ViewModels
{

    public class RAWGViewModel : INotifyPropertyChanged
    {

        const string NEWGAMESURL = "https://api.rawg.io/api/games?key=cccf617d082948b2820d2b26262789c9&page_size=20&ordering=released&search=";
        string SearchURL = "https://api.rawg.io/api/games?key=cccf617d082948b2820d2b26262789c9&page_size=10&search=";
        public static List<RAWGQT.Result> datalist = new List<RAWGQT.Result>();
        static HttpClient htp = new HttpClient();

        public event PropertyChangedEventHandler PropertyChanged;
       
        public ICommand LoadCommand { get; }
        //LoadCommand = new Command(GetNewGamesAsync);

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

        public async Task<ObservableCollection<RAWGQT.Result>> GetNewGamesAsync() 
        { 
            string response = await htp.GetStringAsync(NEWGAMESURL + name);
            var data = NewReleasedGames.FromJson(response);
            // var cards = PokeCardModel.FromJson(response);
            //datalist = data.Results.ToList<RAWGQT.Result>();
            ObservableCollection<RAWGQT.Result> games =
                  new ObservableCollection<RAWGQT.Result>(data.Results.ToList());

            return games;
        }

        public async Task<ObservableCollection<RAWGQTSearch.Result>> SearchGamesAsync(string name)
        {
            string response = await htp.GetStringAsync(SearchURL + name);
            var data = UserSearchGame.FromJson(response);
           // datalist = data.Results.ToList<Result>();
            ObservableCollection<RAWGQTSearch.Result> games = new ObservableCollection<RAWGQTSearch.Result>(data.Results.ToList());

            return games;
        }
    }
}
