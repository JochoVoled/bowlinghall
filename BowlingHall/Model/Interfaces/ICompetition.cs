using System;
using System.Collections.Generic;
using System.Text;

namespace BowlingLib.Model.Interfaces
{
    public interface ICompetition
    {
        int CompetitionId { get; set; }
        List<IMatch> Matches { get; set; }
        Dictionary<Member, decimal> Players { get; set; }
        Member GetChampion();
    }
}
