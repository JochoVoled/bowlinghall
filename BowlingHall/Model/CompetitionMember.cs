using System.ComponentModel.DataAnnotations;

namespace BowlingLib.Model
{
    public class CompetitionMember
    {
        [Key]
        public int CompetitionMemberId { get; set; }
        public int CompetitionId { get; set; }
        public int MemberId { get; set; }
        public decimal WinRatio { get; set; }

        public CompetitionMember(int CompetitionId, int MemberId, decimal WinRatio)
        {
            this.CompetitionId = CompetitionId;
            this.MemberId = MemberId;
            this.WinRatio = WinRatio;
        }
        public CompetitionMember()
        {

        }
    }
}
