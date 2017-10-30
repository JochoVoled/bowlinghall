using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BowlingLib.Model
{
    public class Competition
    {
        public int CompetitionId { get; set; }
        public List<Match> Matches { get; set; }
        public Dictionary<Member,decimal> Players { get; set; }

        public Competition(int CompetitionId, List<Member> Players)
        {
            this.CompetitionId = CompetitionId;
            // Add one, and only, match between every player in the competition
            foreach (Member self in Players)
            {
                this.Players.Add(self, 0m);
                foreach (Member other in Players)
                {
                    if (self == other) continue;
                    if (Matches.Any(x => x.HasMatch(self, other))) continue;
                    Matches.Add(new Match(self, other));
                }
            }
        }

        public Member GetChampion()
        {
            var champion = Players.OrderByDescending(x => x.Value).First().Key;
            return champion;
        }
        //public decimal GetHitRatio(Member member)
        //{
        //    return 0m;
        //}
    }
}
