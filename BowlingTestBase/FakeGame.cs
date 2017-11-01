using BowlingLib.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BowlingTestBase
{
    public class FakeGame : IGame
    {
        private int score { get; set; }
        private int currentSeries { get; set; }
        private int currentRoll { get; set; }

        public IList<string> Series { get; }
        public int Score
        {
            get
            {
                if (Score == 0)
                    return CalculateScore();
                return score;
            }
        }

        public FakeGame()
        {
            score = 0;
            currentSeries = 1;
            currentRoll = 1;
            Series = new List<string> { "", "", "" };
        }

        public int CalculateScore()
        {
            throw new NotImplementedException();
        }
    }
}
