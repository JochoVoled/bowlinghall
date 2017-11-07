using BowlingLib.Model;
using BowlingLib.Model.Interfaces;
using BowlingTestBase;
using System.Collections.Generic;
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

            // TODO implement Lane crud methods to FakeRepository
            repo.Create(new Lane(1));
            Lane lane = repo.GetLaneById(1);

            // TODO implement Match crud to FakeRepository
            //FakeMatch sut = repo.GetMatchByPlayers(member1, member2);
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
            repo.Create(new Competition(1, new List<Member> { member1, member2}));

            Competition sut = (Competition)repo.GetCompetitionById(1);
            sut.Matches.ForEach(x => x.Play());
            
            // Call GetChampion from Competition class
            Member winner = sut.GetChampion();
            
            Assert.Equal(member2.MemberId, winner.MemberId);
        }
    }
}
