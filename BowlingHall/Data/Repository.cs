using BowlingLib.Model;
using BowlingLib.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BowlingLib.Data
{
    public class Repository : IRepository
    {
        // TODO Implement repository
        private static BowlingContext _context { get; set; }

        public BowlingContext Context
        {
            get {
                if (_context == null)
                {
                    _context = new BowlingContext();
                }
                return _context;
            }
        }

        public DatabaseResultState Create(ICompetition competition)
        {
            try
            {
                _context.Competitions.Add((Competition)competition);
                return DatabaseResultState.successful;
            }
            catch (Exception)
            {
                return DatabaseResultState.failed;
            }            
        }

        public IEnumerable<ICompetition> GetAllCompetition()
        {
            // TODO debug, then shrink to one line
            var data = (IEnumerable<Competition>)_context.Competitions.ToList();
            return data;
        }

        public ICompetition GetCompetitionById(int id)
        {
            // TODO debug, then shrink to one line
            var data = _context.Competitions.First(x => x.CompetitionId == id);
            return data;
        }

        public DatabaseResultState Remove(ICompetition competition)
        {
            try
            {
                _context.Competitions.Remove((Competition)competition);
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
                _context.Competitions.First(x => x.CompetitionId == competition.CompetitionId).Matches = competition.Matches;
                _context.Competitions.First(x => x.CompetitionId == competition.CompetitionId).Players = competition.Players;
                return DatabaseResultState.successful;
            }
            catch (Exception)
            {
                return DatabaseResultState.failed;
            }
        }
    }
}
