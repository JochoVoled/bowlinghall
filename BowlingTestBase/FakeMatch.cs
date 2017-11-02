using BowlingLib.Model.Interfaces;
using System.Collections.Generic;
using BowlingLib.Model;

namespace BowlingTestBase
{
    public class FakeMatch : IMatch
    {
        public int CompetitionId { get; set; }
        private KeyValuePair<Member, IGame> playerOne { get; set; }
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

        public FakeMatch(Member PlayerOne, Member PlayerTwo)
        {
            playerOne = new KeyValuePair<Member, IGame>(PlayerOne, new FakeGame());
            playerTwo = new KeyValuePair<Member, IGame>(PlayerTwo, new FakeGame());

            WinnerId = 0;
        }

        public FakeMatch(Member PlayerOne, Member PlayerTwo, int CompetitionId): this(PlayerOne,PlayerTwo)
        {
            this.CompetitionId = CompetitionId;
        }

        public int CalculateWinner()
        {
            if (playerOne.Value.Score > playerTwo.Value.Score)
                return playerOne.Key.MemberId;
            return playerTwo.Key.MemberId;
        }

        public void Play()
        {
            string p1series = "12,34,5S,63,72,81,9-,42,52,43-";
            string p2series = "7S,X-,32,5S,8S,5S,X-,X-,4S,5S0";
            PlayerOne.Value.Series.Add(p1series);
            PlayerTwo.Value.Series.Add(p2series);
            p1series = "12,34,5S,63,72,81,9-,42,52,43-";
            p2series = "7S,X-,32,5S,8S,5S,X-,X-,4S,5S0";
            PlayerOne.Value.Series.Add(p1series);
            PlayerTwo.Value.Series.Add(p2series);
            p1series = "12,34,5S,63,72,81,9-,42,52,43-";
            p2series = "7S,X-,32,5S,8S,5S,X-,X-,4S,5S0";
            PlayerOne.Value.Series.Add(p1series);
            PlayerTwo.Value.Series.Add(p2series);
        }

        public bool HasMatch(Member one, Member another)
        {
            if (playerOne.Key == one && playerTwo.Key == another) return true;
            if (playerTwo.Key == one && playerOne.Key == another) return true;
            return false;
        }
    }
}