//using BowlingLib.Model.Interfaces;
//using System.Collections.Generic;
//using BowlingLib.Model;
//using System.Linq;

//namespace BowlingTestBase
//{
//    public class FakeCompetition : ICompetition
//    {
//        #region properties
//        public int CompetitionId { get; set; }
//        public List<IMatch> Matches { get; set; }
//        public Dictionary<Member, decimal> Players { get; set; }
//        #endregion

//        #region constructors
//        public FakeCompetition()
//        {
//            Players = new Dictionary<Member, decimal>();
//            Matches = new List<IMatch>();
//        }

//        public FakeCompetition(int CompetitionId, List<Member> Players): this()
//        {
//            this.CompetitionId = CompetitionId;
//            MatchAllPlayersOnce(Players);
//        }
//        #endregion

//        /// <summary>
//        /// Add one, and only one, match between every player in the competition
//        /// </summary>
//        /// <param name="Players">The list of Members to match</param>
//        private void MatchAllPlayersOnce(List<Member> Players)
//        {
//            foreach (Member self in Players)
//            {
//                this.Players.Add(self, 0m);
//                foreach (Member other in Players)
//                {
//                    if (self == other) continue;
//                    if (Matches.Any(x => x.HasMatch(self, other))) continue;
//                    Matches.Add(new FakeMatch(self, other, CompetitionId));
//                }
//            }
//        }

//        /// <summary>
//        /// Gets the Member obect with highest win ratio
//        /// </summary>
//        /// <returns>Member obect with highest win ratio</returns>
//        public Member GetChampion()
//        {
//            Players.Keys.ToList().ForEach(x => Players[x] = CalculateWinRatio(x));
//            var champion = Players.OrderByDescending(x => x.Value).First().Key;
//            return champion;
//        }

//        /// <summary>
//        /// Calculates a player's win ratio
//        /// </summary>
//        /// <param name="player">A key-value pair, where the key is a Member and value is their winratio</param>
//        private decimal CalculateWinRatio(Member player)
//        {
//            int participated, wins = 0;
//            participated = Matches.Count(x => x.PlayerOne.Key == player || x.PlayerTwo.Key == player);
//            wins = Matches.Count(x => x.CalculateWinner() == player.MemberId);
//            decimal ratio = wins / (decimal)participated;
//            return ratio;
//        }
//    }
//}
