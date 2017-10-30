using BowlingLib.Model;
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
            Member member1 = new Member(1);
            Member member2 = new Member(2);
            Lane lane = new Lane(1);

            var systemUnderTest = new Match(member1,member2);
            systemUnderTest.Play();
            // TODO, Match should have some manner of Play method
            int winnerId = systemUnderTest.CalculateWinner();
            // Assert that the correct player won
            Assert.Equal(2, winnerId);
        }
        [Fact]
        public void BestWinRatioIsReturnedAsChampion()
        {
            // Assemble data necessary for a competition: Two members, three matches (p1 wins two, p2 wins one)
            Member member1 = new Member(1);
            Member member2 = new Member(2);
            // Call GetChampion from Competition class
            Competition systemUnderTest = new Competition(1, new List<Member>{ member1, member2 });
            
            Member winner = systemUnderTest.GetChampion();
            
            Assert.Equal(member1.MemberId, winner.MemberId);
        }
    }
}
