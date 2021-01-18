using SQLite;

namespace GamersHub.Models
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int userId { get; set; }
        public string userName { get; set; }
    }

    public class WantGames
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string GameId { get; set; }
    }

    public class PlayingGames
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string GameId { get; set; }
    }
    public class FinishedGames
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string GameId { get; set; }
    }

}
