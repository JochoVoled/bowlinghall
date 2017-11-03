using BowlingLib.Model;
using System.Collections.Generic;

namespace BowlingTestBase
{
    /// <summary>
    /// Attempting the Singleton pattern here. Requirements never stated the patterns had to be in the class lib! :-)
    /// </summary>
    public class InMemDb
    {
        
        #region properties
        private static InMemDb db { get; set; }
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
        public List<FakeCompetition> Competitions { get; set; }
        public List<FakeMatch> Matches { get; set; }
        public List<Member> Members { get; set; }
        public List<Lane> Lanes { get; set; }
        public List<CompetitionMember> CompetitionMembers { get; set; }
        public List<MatchMember> MatchMembers { get; set; }
        #endregion

        protected InMemDb()
        {
            Competitions = new List<FakeCompetition>();
            Matches = new List<FakeMatch>();
            Members = new List<Member>();
            Lanes = new List<Lane>();
            CompetitionMembers = new List<CompetitionMember>();
            MatchMembers = new List<MatchMember>();

            List<Member> members = new List<Member> { new Member(1), new Member(2) };
            FakeCompetition competition = new FakeCompetition(1, members);
            Members.AddRange(members);
            Competitions.Add(competition);
            competition.Matches.ForEach(x => Matches.Add((FakeMatch)x));

            Lanes.Add(new Lane(1));
            CompetitionMembers.AddRange(
                new List<CompetitionMember> {
                    new CompetitionMember(competition.CompetitionId, 1, 0m),
                    new CompetitionMember(competition.CompetitionId, 2, 0m)
                }
            );
            MatchMembers.AddRange(new List<MatchMember> {
                new MatchMember(0,1),
                new MatchMember(0,2),
                new MatchMember(1,1),
                new MatchMember(1,2)
            });
        }
    }
}
