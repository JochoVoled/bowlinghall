using BowlingLib.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BowlingLib.Model
{
    public class Match : IMatch
    {
        //public Dictionary<int, IGame> Players { get; set; }
        
        private KeyValuePair<Member,IGame> playerOne { get; set; }
        private KeyValuePair<Member, IGame> playerTwo { get; set; }
        public KeyValuePair<Member, IGame> PlayerOne { get => playerOne; }
        public KeyValuePair<Member, IGame> PlayerTwo { get => playerTwo; }
        public int WinnerId
        {
            get
            {
                if (WinnerId == 0) return CalculateWinner();
                return WinnerId;
            }
            set { WinnerId = value; }
        }

        public Match(Member PlayerOne, Member PlayerTwo)
        {
            playerOne = new KeyValuePair<Member,IGame>(PlayerOne, new Game());
            playerTwo = new KeyValuePair<Member, IGame>(PlayerTwo, new Game());
            
            WinnerId = 0;
        }
        /// <summary>
        /// Calculates the winning player based off the players' scores
        /// </summary>
        /// <returns>The MemberId of the winning player</returns>
        public int CalculateWinner()
        {
            if (playerOne.Value.Score > playerTwo.Value.Score)
                return playerOne.Key.MemberId;
            return playerTwo.Key.MemberId;
            
            //Dictionary<int, int> MapPlayerToScore = new Dictionary<int, int>();
            //foreach (KeyValuePair<int, IGame> player in Players)
            //{
            //    MapPlayerToScore.Add(player.Key, player.Value.Score);
            //}
            //int winningMemberId = MapPlayerToScore.OrderBy(x => x.Value).First().Key;
            //return winningMemberId;
        }

        public void Play()
        {
            throw new NotImplementedException();
        }
        public bool HasMatch(Member one, Member another)
        {
            if (playerOne.Key == one && playerTwo.Key == another) return true;
            if (playerTwo.Key == one && playerOne.Key == another) return true;
            return false;
        }
    }
}
