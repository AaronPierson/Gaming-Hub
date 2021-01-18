using GamersHub.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace GamersHub.ViewModels
{
    class SQLViewModel
    {
        public bool SaveWantedGames(String GameID)
        {

            WantGames want = new WantGames();
            want.GameId = GameID;

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<WantGames>();
                int rows = conn.Insert(want);
                if (rows > 0)
                {
                    return true;
                }
                else
                {
                    return false;

                }
            }
        }

        public bool SavePlayingGames(String GameID)
        {
            PlayingGames playing = new PlayingGames();
            playing.GameId = GameID;

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<PlayingGames>();
                int rows = conn.Insert(playing);
                if (rows > 0)
                {
                    return true;
                }
                else
                {
                    return false;

                }
            }
        }

        public bool SaveFinishedGames(String GameID)
        {
            FinishedGames finished = new FinishedGames();
            finished.GameId = GameID;

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<FinishedGames>();
                int rows = conn.Insert(finished);
                if (rows > 0)
                {
                    return true;
                }
                else
                {
                    return false;

                }
            }
        }
    }
    
}
