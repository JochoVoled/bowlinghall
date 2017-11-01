using BowlingLib.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using BowlingLib.Model;

namespace BowlingTestBase
{
    class FakeMatch : IMatch
    {
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

        public int CalculateWinner()
        {
            if (playerOne.Value.Score > playerTwo.Value.Score)
                return playerOne.Key.MemberId;
            return playerTwo.Key.MemberId;
            //throw new NotImplementedException();
        }

        public void Play()
        {
            throw new NotImplementedException();
        }
    }
}
