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

namespace GamersHub.ViewModels
{

    class RAWGViewModel : INotifyPropertyChanged
    {
       
        const string NEWGAMESURL = "https://api.rawg.io/api/games?key=cccf617d082948b2820d2b26262789c9&page_size=10&ordering=released";
       // public ObservableCollection<Result> Games = new ObservableCollection<Result>();
        public static List<Result> datalist = new List<Result>();
        static HttpClient htp = new HttpClient();

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(ObservableCollection<Result> datalist)
        {
            //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(datalist.));
        }

        public static async Task<ObservableCollection<Result>> GetNewGamestAsync()
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
