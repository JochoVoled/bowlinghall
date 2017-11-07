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

            repo.Create(new Lane(1));
            Lane lane = repo.GetLaneById(1);
                        
            repo.Create(new Match(member1,member2));
            Match sut = repo.GetMatchByPlayers(member1, member2)[0];

            sut.FakePlay();
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
            repo.Create(new Competition(1, new List<Member> { member1, member2 }));

            Competition sut = (Competition)repo.GetCompetitionById(1);
            sut.Matches.ForEach(x => x.Play());

            // Call GetChampion from Competition class
            Member winner = sut.GetChampion();

            Assert.Equal(member2.MemberId, winner.MemberId);
        }

        [Fact]
        public void CanPlay() {
            IRepository repo = new FakeRepository();
            repo.Create(new Member(1));
            Member member1 = repo.GetMemberById(1);
            repo.Create(new Member(2));
            Member member2 = repo.GetMemberById(2);

            repo.Create(new Lane(1));
            Lane lane = repo.GetLaneById(1);
            repo.Create(new Match(member1, member2));
            Match sut = repo.GetMatchByPlayers(member1, member2)[0];

            sut.Play();
        }
    }
}
