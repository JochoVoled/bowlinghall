using BowlingLib.Model.Interfaces;
using System;
using System.Collections.Generic;
using BowlingLib.Model;
using BowlingLib.Model.Enums;

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
                InMemDb.Db.Competitions.Add((FakeCompetition)competition);
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
                InMemDb.Db.Competitions.Remove((FakeCompetition)competition);
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
    }
}
