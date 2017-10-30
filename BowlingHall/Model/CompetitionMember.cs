namespace BowlingLib.Model
{
    public class CompetitionMember
    {
        public int CompetitionId { get; set; }
        public int MemberId { get; set; }
        public decimal WinRatio { get; set; }

        public CompetitionMember(int CompetitionId, int MemberId, decimal WinRatio)
        {
            this.CompetitionId = CompetitionId;
            this.MemberId = MemberId;
            this.WinRatio = WinRatio;
        }
    }
}
