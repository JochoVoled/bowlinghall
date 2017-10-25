using BowlingLib.Model.Enums;
using System.Collections.Generic;

namespace BowlingLib.Model.Interfaces
{
    public interface IGame
    {
        IList<string> Series { get; }
        int Score { get; }

        int CalculateScore();
    }
}
