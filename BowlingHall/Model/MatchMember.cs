using System.ComponentModel.DataAnnotations;

namespace BowlingLib.Model
{
    public class MatchMember
    {
        [Key]
        public int MatchId { get; set; }
        public int MemberId { get; set; }
        public int Score { get; set; }
        public bool IsVictory { get; set; }

        public MatchMember(int MatchId, int MemberId)
        {
            this.MatchId = MatchId;
            this.MemberId = MemberId;
        }
        public MatchMember(int MatchId, int MemberId, int Score): this(MatchId,MemberId)
        {
            this.Score = Score;
        }
        public MatchMember(int MatchId, int MemberId, int Score, bool IsVictory): this(MatchId, MemberId, Score)
        {
            this.IsVictory = IsVictory;
        }
        public MatchMember()
        {

        }
    }
}
