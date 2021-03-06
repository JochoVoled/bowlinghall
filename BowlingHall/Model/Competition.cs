﻿using BowlingLib.Model.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace BowlingLib.Model
{
    public class Competition: ICompetition
    {
        #region properties
        public int CompetitionId { get; set; }
        [NotMapped]
        public List<Match> Matches { get; set; }
        // In order to avoid confusin and circle-reference issues: These are for reference within the competition
        [NotMapped]
        public Dictionary<Member,decimal> Players { get; set; }
        #endregion
        #region constructors

        public Competition()
        {
            Players = new Dictionary<Member, decimal>();
            Matches = new List<Match>();
        }

        public Competition(int CompetitionId, List<Member> Players): this()
        {
            this.CompetitionId = CompetitionId;
            MatchAllPlayersOnce(Players);
        }
        #endregion

        /// <summary>
        /// Add one, and only one, match between every player in the competition
        /// </summary>
        /// <param name="Players">The list of Members to match</param>
        private void MatchAllPlayersOnce(List<Member> Players)
        {
            foreach (Member self in Players)
            {
                this.Players.Add(self, 0m);
                foreach (Member other in Players)
                {
                    if (self == other) continue;
                    if (Matches.Any(x => x.HasMatch(self, other))) continue;
                    Matches.Add(new Match(self, other, this.CompetitionId));
                }
            }
        }

        /// <summary>
        /// Gets the Member obect with highest win ratio
        /// </summary>
        /// <returns>Member obect with highest win ratio</returns>
        public Member GetChampion()
        {
            Players = Players.Keys.ToDictionary(x => x, y => AssignWinRatio(y) );
            var champion = Players.OrderByDescending(x => x.Value).First().Key;
            return champion;
        }

        /// <summary>
        /// Calculates a player's win ratio
        /// </summary>
        /// <param name="player">A key-value pair, where the key is a Member and value is their winratio</param>
        private decimal AssignWinRatio(Member player)
        {
            int participated, wins = 0;
            participated = Matches.Count(x => x.PlayerOne.Key == player || x.PlayerTwo.Key == player);
            wins = Matches.Count(x => x.CalculateWinner() == player.MemberId);
            decimal ratio = wins / (decimal)participated;
            //Players[player.Key] = ratio;
            return ratio;
        }
    }
}
