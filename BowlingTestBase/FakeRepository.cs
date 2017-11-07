using BowlingLib.Model.Interfaces;
using System;
using System.Collections.Generic;
using BowlingLib.Model;
using BowlingLib.Model.Enums;
using System.Linq;

namespace BowlingTestBase
{
    /// <summary>
    /// Attempted facade pattern.
    /// </summary>
    public class FakeRepository : IRepository
    {
        #region Competitions
        public DatabaseResult Create(ICompetition competition)
        {
            try
            {
                InMemDb.Db.Competitions.Add((Competition)competition);
                return DatabaseResult.successful;
            }
            catch (Exception)
            {
                return DatabaseResult.failed;
            }
        }
        public IEnumerable<ICompetition> GetAllCompetition()
        {
            return InMemDb.Db.Competitions;
        }
        public ICompetition GetCompetitionById(int id)
        {
            return InMemDb.Db.Competitions.Find(x => x.CompetitionId == id);
        }
        public DatabaseResult Remove(ICompetition competition)
        {
            try
            {
                InMemDb.Db.Competitions.Remove((Competition)competition);
                return DatabaseResult.successful;
            }
            catch (Exception)
            {
                return DatabaseResult.failed;
            }
        }
        public DatabaseResult Update(ICompetition competition)
        {
            try
            {
                InMemDb.Db.Competitions.Find(x => x.CompetitionId == competition.CompetitionId).Matches = competition.Matches;
                InMemDb.Db.Competitions.Find(x => x.CompetitionId == competition.CompetitionId).Players = competition.Players;
                return DatabaseResult.successful;
            }
            catch (Exception)
            {
                return DatabaseResult.failed;
            }
        }
        #endregion
        #region Member
        public DatabaseResult Create(Member member)
        {
            try
            {
                InMemDb.Db.Members.Add(member);
                return DatabaseResult.successful;
            }
            catch (Exception)
            {
                return DatabaseResult.failed;
            }
        }        
        public IEnumerable<Member> GetAllMembers()
        {
            return InMemDb.Db.Members;
        }
        public Member GetMemberById(int id)
        {
            return InMemDb.Db.Members.Find(x => x.MemberId == id);
        }
        public DatabaseResult Remove(Member member)
        {
            try
            {
                InMemDb.Db.Members.Remove(member);
                return DatabaseResult.successful;
            }
            catch (Exception)
            {
                return DatabaseResult.failed;
            }
        }
        public DatabaseResult Update(Member member)
        {
            try
            {
                return DatabaseResult.successful;
            }
            catch (Exception)
            {
                return DatabaseResult.failed;
            }
        }
        #endregion
        #region lanes
        public DatabaseResult Create(Lane lane)
        {
            try
            {
                InMemDb.Db.Lanes.Add(lane);
                return DatabaseResult.successful;
            }
            catch (Exception)
            {
                return DatabaseResult.failed;
            }
        }

        public Lane GetLaneById(int id)
        {
            return InMemDb.Db.Lanes.Find(x => x.LaneId == id);
        }

        public IEnumerable<Lane> GetAllLanes()
        {
            return InMemDb.Db.Lanes;
        }

        public DatabaseResult Update(Lane lane)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region match
        public DatabaseResult Create(IMatch match)
        {
            try
            {
                InMemDb.Db.Matches.Add((Match)match);
                return DatabaseResult.successful;
            }
            catch (Exception)
            {
                return DatabaseResult.failed;
            }
        }

        public IMatch GetMatchById(int id)
        {
            return InMemDb.Db.Matches.Find(x => x.MatchId == id);
        }

        public IEnumerable<IMatch> GetAllMatches()
        {
            throw new NotImplementedException();
        }
        public List<Match> GetMatchByPlayers(Member player1, Member player2)
        {
            return InMemDb.Db.Matches.Where(x => (x.PlayerOne.Key==player1 && x.PlayerTwo.Key == player2 ) || (x.PlayerTwo.Key == player1 && x.PlayerOne.Key == player2)).ToList();
        }
        public DatabaseResult Update(IMatch match)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
