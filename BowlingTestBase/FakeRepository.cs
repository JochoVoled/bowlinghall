using BowlingLib.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using BowlingLib.Model;

namespace BowlingTestBase
{
    /// <summary>
    /// Attempted facade pattern.
    /// </summary>
    public class FakeRepository : IRepository
    {
        public DatabaseResultState Create(ICompetition competition)
        {
            try
            {
                InMemDb.Db.Competitions.Add((FakeCompetition)competition);
                return DatabaseResultState.successful;
            }
            catch (Exception)
            {
                return DatabaseResultState.failed;
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

        public DatabaseResultState Remove(ICompetition competition)
        {
            try
            {
                InMemDb.Db.Competitions.Remove((FakeCompetition)competition);
                return DatabaseResultState.successful;
            }
            catch (Exception)
            {
                return DatabaseResultState.failed;   
            }
        }

        public DatabaseResultState Update(ICompetition competition)
        {
            try
            {
                InMemDb.Db.Competitions.Find(x => x.CompetitionId == competition.CompetitionId).Matches = competition.Matches;
                InMemDb.Db.Competitions.Find(x => x.CompetitionId == competition.CompetitionId).Players = competition.Players;
                return DatabaseResultState.successful;
            }
            catch (Exception)
            {
                return DatabaseResultState.failed;
            }
        }
    }
}
