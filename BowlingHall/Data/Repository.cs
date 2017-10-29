using BowlingLib.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using BowlingLib.Model;

namespace BowlingLib.Data
{
    public class Repository : IRepository
    {
        public DatabaseResultState Create(Competition competition)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Competition> GetAll<Competition>()
        {
            throw new NotImplementedException();
        }

        public Competition GetById<Competition>(int id)
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
