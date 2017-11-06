using BowlingLib.Model;
using BowlingLib.Model.Interfaces;
using BowlingLib.Model.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace BowlingLib.Data
{
    // TODO Change data calls in code proper to go through IRepository
    public class Repository : IRepository
    {
        private static BowlingContext _context { get; set; }
        
        #region constructor
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
        #endregion
        #region Competition
        public DatabaseResult Create(ICompetition competition)
        {
            try
            {
                _context.Competitions.Add((Competition)competition);
                return DatabaseResult.successful;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"While attempting competition creation: {e.Message}", e.GetType().ToString() );
                return DatabaseResult.failed;
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

        public DatabaseResult Remove(ICompetition competition)
        {
            try
            {
                _context.Competitions.Remove((Competition)competition);
                return DatabaseResult.successful;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"While attempting competition removal: {e.Message}", "Error");
                return DatabaseResult.failed;
            }
        }

        public DatabaseResult Update(ICompetition competition)
        {
            try
            {
                _context.Competitions.First(x => x.CompetitionId == competition.CompetitionId).Matches = competition.Matches;
                _context.Competitions.First(x => x.CompetitionId == competition.CompetitionId).Players = competition.Players;
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
                _context.Members.Add(member);
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
                // As of first implementation, Member only has ID, which should not be changed.
                return DatabaseResult.successful;
            }
            catch (Exception)
            {
                return DatabaseResult.failed;
            }
        }
        public DatabaseResult Remove(Member member)
        {
            try
            {
                _context.Members.Remove(member);
                return DatabaseResult.successful;
            }
            catch (Exception)
            {
                return DatabaseResult.failed;
            }
        }

        public Member GetMemberById(int id)
        {
            var data = _context.Members.First(x => x.MemberId == id);
            return data;
        }

        public IEnumerable<Member> GetAllMembers()
        {
            var data = _context.Members.ToList();
            return data;
        }
        #endregion
    }
}
