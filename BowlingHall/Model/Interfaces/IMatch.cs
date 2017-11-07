using System.Collections.Generic;

namespace BowlingLib.Model.Interfaces
{
    public interface IMatch
    {
        int MatchId { get; }
        KeyValuePair<Member,IGame> PlayerOne { get; }
        KeyValuePair<Member, IGame> PlayerTwo { get; }
        int WinnerId { get; set; }

        int CalculateWinner();
        void Play();
        void FakePlay();
        bool HasMatch(Member one, Member another);
    }
}
