using BowlingLib.Model;
using BowlingLib.Model.Interfaces;
using BowlingTestBase;
using Xunit;

namespace BowlingTests
{
    public class BowlingMatchTests
    {
        [Fact]
        public void CanDecideWinnerAfterSimulatedGame()
        {
            //var match = new Match();
            //MatchSeeder.Seed(match);
            //int winnerId = sut.CalculateWinner();
            IRepository repo = new FakeRepository();
            repo.Create(new Member(1));
            Member member1 = repo.GetMemberById(1);
            repo.Create(new Member(2));
            Member member2 = repo.GetMemberById(2);
            
            // TODO add Lane crud methods to IRepository
            Lane lane = InMemDb.Db.Lanes.Find(x => x.LaneId == 1);
            
            // TODO add Match crud to IRepository
            FakeMatch sut = InMemDb.Db.Matches.Find(x => x.PlayerOne.Key.MemberId == 1 && x.PlayerTwo.Key.MemberId == 2);
            
            sut.Play();
            int winnerId = sut.CalculateWinner();
            
            Assert.Equal(2, winnerId);
        }
        [Fact]
        public void BestWinRatioIsReturnedAsChampion()
        {
            IRepository repo = new FakeRepository();
            repo.Create(new Member(1));
            Member member1 = repo.GetMemberById(1);
            repo.Create(new Member(2));
            Member member2 = repo.GetMemberById(2);

            FakeCompetition sut = InMemDb.Db.Competitions.Find(x => x.CompetitionId == 1);
            sut.Matches.ForEach(x => x.Play());
            
            // Call GetChampion from Competition class
            Member winner = sut.GetChampion();
            
            Assert.Equal(member2.MemberId, winner.MemberId);
        }
    }
}
