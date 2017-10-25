using BowlingLib.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BowlingLib.Model
{
    public class Match : IMatch
    {
        public Dictionary<int, IGame> Players { get; set; }
        public int WinnerId
        {
            get
            {
                if (WinnerId == 0) return CalculateWinner();
                return WinnerId;
            }
            set { WinnerId = value; }
        }

        public Match(List<Member> Participants)
        {
            foreach (Member participant in Participants)
            {
                Players.Add(participant.Id, new Game());
            }
            WinnerId = 0;
        }
        public int CalculateWinner()
        {
            Dictionary<int, int> MapPlayerToScore = new Dictionary<int, int>();
            foreach (KeyValuePair<int, IGame> player in Players)
            {
                MapPlayerToScore.Add(player.Key, player.Value.Score);
            }
            int winningMemberId = MapPlayerToScore.OrderBy(x => x.Value).First().Key;
            return winningMemberId;
        }
    }
}
