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
    class FakeRepository : IRepository
    {
        public DatabaseResultState Create(Competition competition)
        {
            try
            {
                InMemDb.Db.Competitions.Add(competition);
                return DatabaseResultState.successful;
            }
            catch (Exception)
            {
                return DatabaseResultState.failed;
            }            
        }

        public IEnumerable<Competition> GetAllCompetition()
        {
            return InMemDb.Db.Competitions;
        }

        public Competition GetCompetitionById(int id)
        {
            return InMemDb.Db.Competitions.Find(x => x.CompetitionId == id);
        }

        public DatabaseResultState Remove(Competition competition)
        {
            try
            {
                InMemDb.Db.Competitions.Remove(competition);
                return DatabaseResultState.successful;
            }
            catch (Exception)
            {
                return DatabaseResultState.failed;   
            }
        }

        public DatabaseResultState Update(Competition competition)
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
