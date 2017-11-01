using BowlingLib.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using BowlingLib.Model;

namespace BowlingLib.Data
{
    public class Repository : IRepository
    {
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

        public DatabaseResultState Create(Competition competition)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Competition> GetAll<Competition>()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Competition> GetAllCompetition()
        {
            throw new NotImplementedException();
        }

        public Competition GetById<Competition>(int id)
        {
            throw new NotImplementedException();
        }

        public Competition GetCompetitionById(int id)
        {
            throw new NotImplementedException();
        }

        public DatabaseResultState Remove(Competition competition)
        {
            throw new NotImplementedException();
        }

        public DatabaseResultState Update(Competition competition)
        {
            throw new NotImplementedException();
        }
    }
}
