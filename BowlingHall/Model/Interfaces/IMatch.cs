using System.Collections.Generic;

namespace BowlingLib.Model.Interfaces
{
    public interface IMatch
    {
        KeyValuePair<Member,IGame> PlayerOne { get; }
        KeyValuePair<Member, IGame> PlayerTwo { get; }
        int WinnerId { get; set; }

        int CalculateWinner();
        void Play();
        bool HasMatch(Member one, Member another);
    }
}
