using System.Collections.Generic;

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
        DatabaseResultState Create(ICompetition competition);
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
        DatabaseResultState Update(ICompetition competition);
        /// <summary>
        /// Removes a competition to database, based on a competition object
        /// </summary>
        /// <param name="competition">A competition object to save</param>
        /// <returns>successful if transfer succeeded, otherwise failed</returns>
        DatabaseResultState Remove(ICompetition member);
        #endregion
        #region member
        /// <summary>
        /// Creates a member to database, based on a member object
        /// </summary>
        /// <param name="competition">A member object to save</param>
        /// <returns>successful if transfer succeeded, otherwise failed</returns>
        DatabaseResultState Create(Member member);
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
        DatabaseResultState Update(Member member);
        /// <summary>
        /// Removes a member to database, based on a member object
        /// </summary>
        /// <param name="member">A member object to save</param>
        /// <returns>successful if transfer succeeded, otherwise failed</returns>
        DatabaseResultState Remove(Member member);
        #endregion
    }
    public enum DatabaseResultState
    {
        successful,
        failed
    }
}
