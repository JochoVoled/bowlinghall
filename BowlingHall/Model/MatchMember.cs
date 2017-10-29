namespace BowlingLib.Model
{
    public class MatchMember
    {
        public int MatchId { get; set; }
        public int MemberId { get; set; }
        public int Score { get; set; }
        public bool IsVictory { get; set; }
    }
}
