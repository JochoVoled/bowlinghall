using BowlingLib.Model;
using BowlingTestBase;
using System;
using System.Collections.Generic;
using Xunit;

namespace BowlingTests
{
    public class BowlingMatchTests
    {
        [Fact]
        public void CanDecideWinnerAfterSimulatedGame()
        {
            // TODO, gather members from InMemDb
            Member member1 = InMemDb.Db.Members.Find(x => x.MemberId == 1);
            Member member2 = InMemDb.Db.Members.Find(x => x.MemberId == 2);
            Lane lane = InMemDb.Db.Lanes.Find(x => x.LaneId == 1);

            var sut = InMemDb.Db.Matches.Find(x => x.PlayerOne.Key.MemberId == 1 && x.PlayerTwo.Key.MemberId == 2);
            // Play fake matches
            sut.Play();
            int winnerId = sut.CalculateWinner();
            // Assert that the correct player won
            Assert.Equal(2, winnerId);
        }
        [Fact]
        public void BestWinRatioIsReturnedAsChampion()
        {
            // Assemble data necessary for a competition: Two members, three matches (p1 wins two, p2 wins one)
            Member member1 = InMemDb.Db.Members.Find(x => x.MemberId == 1);
            Member member2 = InMemDb.Db.Members.Find(x => x.MemberId == 2);
            // Call GetChampion from Competition class
            Competition sut = new Competition(1, new List<Member>{ member1, member2 });
            // Play fake matches

            Member winner = sut.GetChampion();
            
            Assert.Equal(member1.MemberId, winner.MemberId);
        }
    }
}
