using System;
using System.Collections.Generic;
using System.Text;

namespace BowlingLib.Model
{
    public class Competition
    {
        public List<Match> Matches { get; set; }
        public Dictionary<Member,decimal> Players { get; set; }

        public Member GetChampion()
        {
            return new Member();
        }
        public decimal GetHitRatio(Member member)
        {
            return 0m;
        }
    }
}
