namespace BowlingLib.Model
{
    public class Member: System.IEquatable<Member>
    {
        public int MemberId { get; set; }
        public Member() { }
        public Member(int MemberId)
        {
            this.MemberId = MemberId;
        }

        public bool Equals(Member other)
        {
            return MemberId == other.MemberId;
        }
    }
}
