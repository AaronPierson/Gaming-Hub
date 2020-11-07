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

namespace GamersHub.ViewModels
{

    public class RAWGViewModel : INotifyPropertyChanged
    {

        const string NEWGAMESURL = "https://api.rawg.io/api/games?key=cccf617d082948b2820d2b26262789c9&page_size=10&ordering=released";
        public static List<Result> datalist = new List<Result>();
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

        public static async Task<ObservableCollection<Result>> GetNewGamesAsync() 
        { 
            string response = await htp.GetStringAsync(NEWGAMESURL);
            var data = NewReleasedGames.FromJson(response);
            // var cards = PokeCardModel.FromJson(response);
            datalist = data.Results.ToList<Result>();
            //_allcardslst = cards.Cards.ToList<Card>();
            // AllCards = cards.Cards.ToList<Card>();
          ObservableCollection<Result> games = new ObservableCollection<Result>(datalist);

            return games;
        }
    }
}
