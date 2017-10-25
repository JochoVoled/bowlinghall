using System.Collections.Generic;

namespace BowlingLib.Model.Interfaces
{
    public interface IMatch
    {
        Dictionary<int, IGame> Players { get; set; }
        int WinnerId { get; set; }

        int CalculateWinner();
    }
}
