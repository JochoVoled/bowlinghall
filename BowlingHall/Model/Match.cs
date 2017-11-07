using BowlingLib.Model.Interfaces;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace BowlingLib.Model
{
    public class Match : IMatch
    {
        #region properties
        private int matchId { get; set; }
        public int MatchId { get { return matchId; } }
        private static int count { get; set; } = 0;
        public int CompetitionId { get; set; }
        private int winnerId { get; set; }
        private KeyValuePair<Member,IGame> playerOne { get; set; }
        private KeyValuePair<Member, IGame> playerTwo { get; set; }
        public KeyValuePair<Member, IGame> PlayerOne { get => playerOne; }
        public KeyValuePair<Member, IGame> PlayerTwo { get => playerTwo; }
        public int WinnerId
        {
            get
            {
                if (winnerId == 0) return CalculateWinner();
                return winnerId;
            }
            set { winnerId = value; }
        }
        #endregion

        #region constructors
        public Match(Member PlayerOne, Member PlayerTwo)
        {
            playerOne = new KeyValuePair<Member,IGame>(PlayerOne, new Game());
            playerTwo = new KeyValuePair<Member, IGame>(PlayerTwo, new Game());
            
            winnerId = 0;
            matchId = ++count;
        }
        public Match(Member PlayerOne, Member PlayerTwo, int CompetitionId): this(PlayerOne,PlayerTwo)
        {
            this.CompetitionId = CompetitionId;
        }
        #endregion

        /// <summary>
        /// Calculates the winning player based off the players' scores. Returns The MemberId of the winning player.
        /// </summary>
        /// <returns>The MemberId of the winning player</returns>
        public int CalculateWinner()
        {
            if (playerOne.Value.Score > playerTwo.Value.Score)
                return playerOne.Key.MemberId;
            return playerTwo.Key.MemberId;
        }

        /// <summary>
        /// Each player throw twice in each round, for three series
        /// </summary>
        public void Play()
        {
            // 1-9 are pins, - is a miss, S is a spare, X is a strike, . is 'not yet thrown'
            // "..,..,..,..,..,..,..,..,..,..." is an empty series
            for (int i = 0; i < 3; i++)
            {
                string p1series = "..,..,..,..,..,..,..,..,..,...";
                string p2series = "..,..,..,..,..,..,..,..,..,...";
                char[][] seriesCharArray = { p1series.ToCharArray(), p2series.ToCharArray() };
                int cursorOnPlayer = 0;
                for (int cursor = 0; cursor < seriesCharArray[1].Length; cursor++)
                {
                    // Upon encountering a ',', switch player or proceed to the next round
                    if (seriesCharArray[cursorOnPlayer][cursor] == ',')
                    {
                        // 'up one' and 'is len-1' to support multiple players in the future
                        if (cursorOnPlayer == seriesCharArray.Length-1)
                        {
                            cursorOnPlayer = 0;
                            continue;
                        }
                        cursorOnPlayer++;
                        cursor = cursor - 3;
                        continue;
                    }
                    // TEMP keeping ThrowBall non-static to comply with interface, considering changing method call to delegate function
                    char c = PlayerOne.Value.ThrowBall();
                    if (cursorOnPlayer == 0)
                    {
                        seriesCharArray[cursorOnPlayer][cursor] = c;
                    }
                    else
                    {
                        seriesCharArray[cursorOnPlayer][cursor] = c;
                    }
                }
                PlayerOne.Value.Series.Add(new string(seriesCharArray[0]));
                PlayerTwo.Value.Series.Add(new string(seriesCharArray[1]));
            }
        }
        public void FakePlay()
        {
            string p1series = "12,34,5S,63,72,81,9-,42,52,43-";
            string p2series = "7S,X-,32,5S,8S,5S,X-,X-,4S,5S0";
            PlayerOne.Value.Series.Add(p1series);
            PlayerTwo.Value.Series.Add(p2series);
            p1series = "12,34,5S,63,72,81,9-,42,52,43-";
            p2series = "7S,X-,32,5S,8S,5S,X-,X-,4S,5S0";
            PlayerOne.Value.Series.Add(p1series);
            PlayerTwo.Value.Series.Add(p2series);
            p1series = "12,34,5S,63,72,81,9-,42,52,43-";
            p2series = "7S,X-,32,5S,8S,5S,X-,X-,4S,5S0";
            PlayerOne.Value.Series.Add(p1series);
            PlayerTwo.Value.Series.Add(p2series);
        }
        public bool HasMatch(Member one, Member another)
        {
            if (playerOne.Key == one && playerTwo.Key == another) return true;
            if (playerTwo.Key == one && playerOne.Key == another) return true;
            return false;
        }
    }
}
