using BowlingLib.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BowlingTestBase
{
    /// <summary>
    /// Attempting the Singleton pattern here. Requirements never stated the patterns had to be in the class lib! :-)
    /// </summary>
    public class InMemDb
    {
        private static volatile InMemDb db;

        public static InMemDb Db
        {
            get
            {
                if (db == null)
                {
                    db = new InMemDb();
                }
                return db;
            }
        }
        public List<Competition> Competitions { get; set; }
        public List<Match> Matches { get; set; }
        public List<Member> Members { get; set; }
        public List<Lane> Lanes { get; set; }
        public List<CompetitionMember> CompetitionMembers { get; set; }
        public List<MatchMember> MatchMembers { get; set; }

        public InMemDb()
        {
            List<Member> members = new List<Member> { new Member(1), new Member(2) };
            Competition competition = new Competition(1, members);
            Db.Members.AddRange(members);
            Db.Competitions.Add(competition);
            Db.Matches.AddRange(competition.Matches);
            Db.Lanes.Add(new Lane(1));            
            Db.CompetitionMembers.AddRange(
                new List<CompetitionMember> {
                    new CompetitionMember(competition.CompetitionId, 1, 0m),
                    new CompetitionMember(competition.CompetitionId, 2, 0m)
                }
            );
            Db.MatchMembers.AddRange(new List<MatchMember> {
                new MatchMember(0,1),
                new MatchMember(0,2),
                new MatchMember(1,1),
                new MatchMember(1,2)
            });
        }
    }
}
