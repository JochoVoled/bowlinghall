using System.Collections.Generic;

namespace BowlingLib.Model.Interfaces
{
    public interface ICompetition
    {
        int CompetitionId { get; set; }
        List<Match> Matches { get; set; }
        Dictionary<Member, decimal> Players { get; set; }
        Member GetChampion();
    }
}
