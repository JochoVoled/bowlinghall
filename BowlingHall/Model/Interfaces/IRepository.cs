using System.Collections.Generic;
using BowlingLib.Model.Enums;

namespace BowlingLib.Model.Interfaces
{
    /// <summary>
    /// Repository interface, intended to be interfacing client and database, as well as tests and fake database.
    /// Initially only supports Competition to test out, intended to be expanded to cover other types later
    /// </summary>
    public interface IRepository
    {
        #region competition
        /// <summary>
        /// Creates a competition to database, based on a competition object
        /// </summary>
        /// <param name="competition">A competition object to save</param>
        /// <returns>successful if transfer succeeded, otherwise failed</returns>
        DatabaseResult Create(ICompetition competition);
        /// <summary>
        /// Fetches a competition by its id
        /// </summary>
        /// <param name="id">The available id</param>
        /// <returns>Returns null if id does not map to any registered competition</returns>
        ICompetition GetCompetitionById(int id);
        /// <summary>
        /// Gets all added Competitions
        /// </summary>
        /// <typeparam name="Competition">Intended to be clue to method which table you wish to GetAll of</typeparam>
        /// <returns>All Competitions as an IEnumerable collection</returns>
        IEnumerable<ICompetition> GetAllCompetition();
        /// <summary>
        /// Updates a competition to database, based on a competition object
        /// </summary>
        /// <param name="competition">A competition object to save</param>
        /// <returns>successful if transfer succeeded, otherwise failed</returns>
        DatabaseResult Update(ICompetition competition);
        /// <summary>
        /// Removes a competition to database, based on a competition object
        /// </summary>
        /// <param name="competition">A competition object to save</param>
        /// <returns>successful if transfer succeeded, otherwise failed</returns>
        DatabaseResult Remove(ICompetition member);
        #endregion
        #region member
        /// <summary>
        /// Creates a member to database, based on a member object
        /// </summary>
        /// <param name="competition">A member object to save</param>
        /// <returns>successful if transfer succeeded, otherwise failed</returns>
        DatabaseResult Create(Member member);
        /// <summary>
        /// Fetches a member by its id
        /// </summary>
        /// <param name="id">The available id</param>
        /// <returns>Returns null if id does not map to any registered member</returns>
        Member GetMemberById(int id);
        /// <summary>
        /// Gets all added Competitions
        /// </summary>
        /// <typeparam name="Competition">Intended to be clue to method which table you wish to GetAll of</typeparam>
        /// <returns>All Competitions as an IEnumerable collection</returns>
        IEnumerable<Member> GetAllMembers();
        /// <summary>
        /// Updates a member to database, based on a member object
        /// </summary>
        /// <param name="member">A member object to save</param>
        /// <returns>successful if transfer succeeded, otherwise failed</returns>
        DatabaseResult Update(Member member);
        /// <summary>
        /// Removes a member to database, based on a member object
        /// </summary>
        /// <param name="member">A member object to save</param>
        /// <returns>successful if transfer succeeded, otherwise failed</returns>
        DatabaseResult Remove(Member member);
        #endregion
        #region lanes
        /// <summary>
        /// Creates a lane to database, based on a lane object
        /// </summary>
        /// <param name="lane">A lane object to save</param>
        /// <returns>successful if transfer succeeded, otherwise failed</returns>
        DatabaseResult Create(Lane lane);
        /// <summary>
        /// Fetches a lane by its id
        /// </summary>
        /// <param name="id">The available id</param>
        /// <returns>Returns null if id does not map to any registered lane</returns>
        Lane GetLaneById(int id);
        /// <summary>
        /// Gets all added Lanes
        /// </summary>
        /// <returns>All Lanes as an IEnumerable collection</returns>
        IEnumerable<Lane> GetAllLanes();
        /// <summary>
        /// Updates a lane to database, based on a lane object
        /// </summary>
        /// <param name="member">A lane object to save</param>
        /// <returns>successful if transfer succeeded, otherwise failed</returns>
        DatabaseResult Update(Lane lane);
        /// <summary>
        /// Removes a lane to database, based on a lane object
        /// </summary>
        /// <param name="member">A member object to save</param>
        /// <returns>successful if transfer succeeded, otherwise failed</returns>
        #endregion
        #region matches
        /// <summary>
        /// Creates a match to database, based on a match object
        /// </summary>
        /// <param name="match">A match object to save</param>
        /// <returns>successful if transfer succeeded, otherwise failed</returns>
        DatabaseResult Create(IMatch match);
        /// <summary>
        /// Fetches a match by its id
        /// </summary>
        /// <param name="id">The available id</param>
        /// <returns>Returns null if id does not map to any registered member</returns>
        IMatch GetMatchById(int id);
        /// <summary>
        /// Finds a match both players participate in. The order of the players does not matter.
        /// </summary>
        /// <param name="player1">One of the players</param>
        /// <param name="player2">The other player </param>
        /// <returns>Returns the matches where both players participated, or null if none was found</returns>
        List<Match> GetMatchByPlayers(Member player1, Member player2);
        /// <summary>
        /// Gets all added matches
        /// </summary>
        /// <returns>All matches as an IEnumerable collection</returns>
        IEnumerable<IMatch> GetAllMatches();
        /// <summary>
        /// Updates a member to database, based on a member object
        /// </summary>
        /// <param name="member">A member object to save</param>
        /// <returns>successful if transfer succeeded, otherwise failed</returns>
        DatabaseResult Update(IMatch match);
        /// <summary>
        /// Removes a member to database, based on a member object
        /// </summary>
        /// <param name="member">A member object to save</param>
        /// <returns>successful if transfer succeeded, otherwise failed</returns>
        #endregion
    }
}
