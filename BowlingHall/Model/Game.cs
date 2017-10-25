using BowlingLib.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace BowlingLib.Model
{
    class Game : IGame
    {
        private int score { get; set; }
        private int currentSeries { get; set; }
        private int currentRoll { get; set; }

        public IList<string> Series { get; }
        public int Score { get {
                if (Score == 0)
                    return CalculateScore();
                return score;
            }}
        

        public Game()
        {
            score = 0;
            currentSeries = 1;
            currentRoll = 1;
            Series = new List<string> { "", "", "" };
        }
        public int CalculateScore()
        {
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

    }
}
