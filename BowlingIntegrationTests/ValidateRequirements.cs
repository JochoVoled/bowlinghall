using BowlingLib.Data;
using BowlingLib.Model;
using BowlingLib.Model.Interfaces;
using Xunit;

namespace BowlingIntegrationTests
{
    public class ValidateRequirements
    {
        [Fact]
        public void CruCompetitionInfo()
        {
            Repository repo = new Repository();
            Competition competition = new Competition {
                CompetitionId = 999
            };
            // Create competition, assert
            var cResult = repo.Create(competition);
            Assert.Equal(DatabaseResultState.successful, cResult);

            // Read competition, assert
            var rResult = repo.GetCompetitionById(competition.CompetitionId);
            Assert.Equal(competition.CompetitionId, rResult.CompetitionId);
            
            // Update competition, assert
            competition.Matches.Add(new Match(new Member(4), new Member(5)));
            var uResult = repo.Update(competition);
            Assert.Equal(DatabaseResultState.successful, uResult);
        }

        //Verifiera med integrationstester attdet går att generera, lagra och hämta medlemmar.
        [Fact]
        public void CruMember()
        {
            // Create Member, assert
            // Read Member, assert
            // Update Member, assert
        }
    }
}
