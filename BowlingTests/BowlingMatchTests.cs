using BowlingLib.Model;
using System;
using Xunit;

namespace BowlingTests
{
    public class BowlingMatchTests
    {
        [Fact]
        public void CanDecideWinnerAfterSimulatedGame()
        {
            // TODO, gather members from InMemDb
            Member member1 = new Member();
            Member member2 = new Member();
            Lane lane = new Lane();

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
            Member member1 = new Member();
            Member member2 = new Member();
            // Call GetChampion from Competition class
            Competition systemUnderTest = new Competition();


            Member winner = systemUnderTest.GetChampion();
            
            Assert.Equal(member1.Id, winner.Id);
        }
    }
}
