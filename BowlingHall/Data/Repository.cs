using BowlingLib.Model;
using BowlingLib.Model.Interfaces;
using BowlingLib.Model.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace BowlingLib.Data
{
    public class Repository : IRepository
    {
        #region properties
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
        #endregion
        #region constructor
        public Repository()
        {
            _context = new BowlingContext();
        }
        #endregion
        #region Competition
        public DatabaseResult Create(ICompetition competition)
        {
            //try
            //{
                _context.Competitions.Add((Competition)competition);
                return DatabaseResult.successful;
                // TODO (high prio) System.InvalidOperationException: 'The entity type 'CompetitionMember' requires a primary key to be defined.'
            //}
            //catch (Exception e)
            //{
            //    Debug.WriteLine($"While attempting competition creation: {e.Message}", e.GetType().ToString() );
            //    return DatabaseResult.failed;
            //}            
        }

        public IEnumerable<ICompetition> GetAllCompetition()
        {
            var data = (IEnumerable<Competition>)_context.Competitions.ToList();
            return data;
        }

        public ICompetition GetCompetitionById(int id)
        {
            return _context.Competitions.First(x => x.CompetitionId == id);
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
            //try
            //{
                _context.Members.Add(member);
                // TODO (high prio) System.InvalidOperationException: 'The entity type 'CompetitionMember' requires a primary key to be defined.'
            return DatabaseResult.successful;
            //}
            //catch (Exception)
            //{
            //    return DatabaseResult.failed;
            //}
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
            return _context.Members.First(x => x.MemberId == id);
        }

        public IEnumerable<Member> GetAllMembers()
        {
            var data = _context.Members.ToList();
            return data;
        }
        #endregion
        #region lanes
        public DatabaseResult Create(Lane lane)
        {
            throw new NotImplementedException();
        }

        public Lane GetLaneById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Lane> GetAllLanes()
        {
            throw new NotImplementedException();
        }

        public DatabaseResult Update(Lane lane)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region matches
        public DatabaseResult Create(IMatch match)
        {
            throw new NotImplementedException();
        }

        public IMatch GetMatchById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Match> GetMatchByPlayers(Member player1, Member player2)
        {
            
            throw new NotImplementedException();
        }

        public IEnumerable<IMatch> GetAllMatches()
        {
            throw new NotImplementedException();
        }

        public DatabaseResult Update(IMatch match)
        {
            throw new NotImplementedException();
        }


        #endregion
    }
}
