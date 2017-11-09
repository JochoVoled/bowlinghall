using BowlingLib.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace BowlingLib.Model
{
    class Game : IGame
    {
        [Key]
        public int GameId { get; set; }
        private int score { get; set; }
        private int currentSeries { get; set; }
        private int currentRoll { get; set; }
        [NotMapped]
        public IList<string> Series { get; }
        public int Score { get {
                if (score == 0)
                    return CalculateScore();
                return score;
            }}
        

        public Game()
        {
            score = 0;
            currentSeries = 1;
            currentRoll = 1;
            Series = new List<string>();
        }
        /// <summary>
        /// Steps through the series strings, and sums the scores. Adds flat values to Spares and Strikes right now.
        /// </summary>
        /// <returns>The summarized final score</returns>
        public int CalculateScore()
        {
            int tmp = 0;
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

        public void RegisterRoll(char roll)
        {
            string str = roll.ToString().ToUpper();
            if (!Regex.IsMatch(str, "[1-9-\\/X]") || currentSeries>3)
            {
                return; // No support for this character
            }
            Series[currentSeries] += str;
        }

        /// <summary>
        /// Randomly finds a throw result
        /// </summary>
        /// <returns>A char representing the throw result</returns>
        public char ThrowBall()
        {
            char[] possibleOutcomes = { '-', 'S', 'X','1','2','3','4','5','6','7','8','9' };
            Random dice = new Random();
            // TODO (low prio) Add validation to throw randomization:
            //  Sum of two throws may not exceed 10, as that is a Spare
            //  No throw may proceed Strike
            //  Tenth round will only have a third throw if the second is a S or X
            //  X can only happen first throw (or second and third of 10th round). Spare can only happen second throw
            //  A strike ends the current round (unless 10th turn)
            return possibleOutcomes[dice.Next(0,possibleOutcomes.Length)];
        }
    }
}
