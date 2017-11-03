using BowlingLib.Model;
using BowlingTestBase;
using Xunit;

namespace BowlingTests
{
    public class BowlingMatchTests
    {
        [Fact]
        public void CanDecideWinnerAfterSimulatedGame()
        {
            Member member1 = InMemDb.Db.Members.Find(x => x.MemberId == 1);
            Member member2 = InMemDb.Db.Members.Find(x => x.MemberId == 2);
            Lane lane = InMemDb.Db.Lanes.Find(x => x.LaneId == 1);
            FakeMatch sut = InMemDb.Db.Matches.Find(x => x.PlayerOne.Key.MemberId == 1 && x.PlayerTwo.Key.MemberId == 2);
            
            sut.Play();
            int winnerId = sut.CalculateWinner();
            
            Assert.Equal(2, winnerId);
        }
        [Fact]
        public void BestWinRatioIsReturnedAsChampion()
        {            
            Member member1 = InMemDb.Db.Members.Find(x => x.MemberId == 1);
            Member member2 = InMemDb.Db.Members.Find(x => x.MemberId == 2);
            FakeCompetition sut = InMemDb.Db.Competitions.Find(x => x.CompetitionId == 1);
            sut.Matches.ForEach(x => x.Play());
            
            // Call GetChampion from Competition class
            Member winner = sut.GetChampion();
            
            Assert.Equal(member2.MemberId, winner.MemberId);
        }
    }
}
