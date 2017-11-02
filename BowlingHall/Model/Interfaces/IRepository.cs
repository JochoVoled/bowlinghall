using System.Collections.Generic;

namespace BowlingLib.Model.Interfaces
{
    /// <summary>
    /// Repository interface, intended to be interfacing client and database, as well as tests and fake database.
    /// Initially only supports Competition to test out, intended to be expanded to cover other types later
    /// </summary>
    public interface IRepository
    {
        /// <summary>
        /// Creates a competition to database, based on a competition object
        /// </summary>
        /// <param name="competition">A competition object to save</param>
        /// <returns>successful if transfer succeeded, otherwise failed</returns>
        DatabaseResultState Create(ICompetition competition);
        /// <summary>
        /// Fetches a competition by its id
        /// </summary>
        /// <typeparam name="Competition"></typeparam>
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
        DatabaseResultState Remove(ICompetition competition);
    }
    public enum DatabaseResultState
    {
        successful,
        failed
    }
}
