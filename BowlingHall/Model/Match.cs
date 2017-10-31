using BowlingLib.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;

namespace BowlingLib.Model
{
    public class Match : IMatch
    {
        public int CompetitionId { get; set; }

        private KeyValuePair<Member,IGame> playerOne { get; set; }
        private KeyValuePair<Member, IGame> playerTwo { get; set; }
        public KeyValuePair<Member, IGame> PlayerOne { get => playerOne; }
        public KeyValuePair<Member, IGame> PlayerTwo { get => playerTwo; }
        public int WinnerId
        {
            get
            {
                if (WinnerId == 0) return CalculateWinner();
                return WinnerId;
            }
            set { WinnerId = value; }
        }

        public Match(Member PlayerOne, Member PlayerTwo)
        {
            playerOne = new KeyValuePair<Member,IGame>(PlayerOne, new Game());
            playerTwo = new KeyValuePair<Member, IGame>(PlayerTwo, new Game());
            
            WinnerId = 0;
        }
        public Match(Member PlayerOne, Member PlayerTwo, int CompetitionId): this(PlayerOne,PlayerTwo)
        {
            this.CompetitionId = CompetitionId;
        }
        /// <summary>
        /// Calculates the winning player based off the players' scores
        /// </summary>
        /// <returns>The MemberId of the winning player</returns>
        public int CalculateWinner()
        {
            if (playerOne.Value.Score > playerTwo.Value.Score)
                return playerOne.Key.MemberId;
            return playerTwo.Key.MemberId;
        }

        public void Play()
        {
            // 1-9 are pins, - is a miss, S is a spare, X is a strike, . is 'not yet thrown'
            // "..,..,..,..,..,..,..,..,..,..." is an empty series
            for (int i = 0; i < 3; i++)
            {
                string p1series = "..,..,..,..,..,..,..,..,..,...";
                string p2series = "..,..,..,..,..,..,..,..,..,...";
                char[][] seriesCharArray = { p1series.ToCharArray(), p2series.ToCharArray() };
                int cursor = 0;
                int cursorOnPlayer = 0;
                while (Regex.IsMatch(p1series,"\\.") || Regex.IsMatch(p2series, "\\."))
                {
                    // Upon encountering a ',', switch player or proceed to the next round
                    if (seriesCharArray[cursorOnPlayer][i] == ',')
                    {
                        if (cursorOnPlayer == seriesCharArray.Length)
                        {
                            cursorOnPlayer = 0;
                            cursor++;
                            continue;
                        }
                        cursorOnPlayer++;
                        cursor = cursor - 2;
                        continue;
                    }
                    AssignThrowToSeriesString(i, seriesCharArray, cursorOnPlayer);
                    cursor++;
                }
                PlayerOne.Value.Series.Add(p1series);
                PlayerTwo.Value.Series.Add(p2series);
            }
        }

        private void AssignThrowToSeriesString(int i, char[][] seriesCharArray, int cursorOnPlayer)
        {
            if (cursorOnPlayer == 0)
            {
                seriesCharArray[cursorOnPlayer][i] = PlayerOne.Value.ThrowBall();
            }
            else
            {
                seriesCharArray[cursorOnPlayer][i] = PlayerTwo.Value.ThrowBall();
            }
        }

        public bool HasMatch(Member one, Member another)
        {
            if (playerOne.Key == one && playerTwo.Key == another) return true;
            if (playerTwo.Key == one && playerOne.Key == another) return true;
            return false;
        }
    }
}
