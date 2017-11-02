using BowlingLib.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BowlingTestBase
{
    public class FakeGame : IGame
    {
        #region properties
        private int score { get; set; }
        public int Score
        {
            get
            {
                if (Score == 0)
                    return CalculateScore();
                return score;
            }
        }
        private int currentSeries { get; set; }
        private int currentRoll { get; set; }
        public IList<string> Series { get; }
        #endregion
        #region constructors
        public FakeGame()
        {
            score = 0;
            currentSeries = 1;
            currentRoll = 1;
            Series = new List<string> { "", "", "" };
        }
        #endregion
        /// <summary>
        /// Steps through the series strings, and sums the scores. Adds flat values to Spares and Strikes right now.
        /// </summary>
        /// <returns>The summarized final score</returns>
        public int CalculateScore()
        {
            int tmp = 0;
            // Step through the score string (param?)
            // Add the number, 0 for -
            // For S and X, use 20 and 30 temporarily
            // TODO do something proper for S and X
            foreach (string series in Series)
            {
                var charArr = series.ToCharArray();
                foreach (char c in charArr)
                {
                    switch (c)
                    {
                        case '1':
                        case '2':
                        case '3':
                        case '4':
                        case '5':
                        case '6':
                        case '7':
                        case '8':
                        case '9':
                            tmp += int.Parse(c.ToString());
                            break;
                        case 'S':
                            tmp += 20;
                            break;
                        case 'X':
                            tmp += 30;
                            break;
                        case '-':
                            break;
                        default:
                            break;
                    }
                }
            }
            score = tmp;
            return score;
        }

        public char ThrowBall()
        {
            throw new NotImplementedException();
        }
    }
}
