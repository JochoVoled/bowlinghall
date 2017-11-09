using BowlingLib.Data;
using BowlingLib.Model;
using BowlingLib.Model.Enums;
using Xunit;

namespace BowlingIntegrationTests
{
    public class VerifyRequirements
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
            Assert.Equal(DatabaseResult.successful, cResult);
            repo.Save();
            // Read competition, assert
            var rResult = repo.GetCompetitionById(competition.CompetitionId);
            Assert.Equal(competition.CompetitionId, rResult.CompetitionId);
            
            // Update competition, assert
            competition.Matches.Add(new Match(new Member(4), new Member(5)));
            var uResult = repo.Update(competition);
            Assert.Equal(DatabaseResult.successful, uResult);
        }

        //Verifiera med integrationstester attdet går att generera, lagra och hämta medlemmar.
        [Fact]
        public void CruMember()
        {
            Repository repo = new Repository();
            Member member = new Member(999);
            // Create Member, assert
            var cResult = repo.Create(member);
            Assert.Equal(DatabaseResult.successful, cResult);
            repo.Save();
            // Read Member, assert
            var rResult = repo.GetMemberById(member.MemberId);
            Assert.Equal(member, rResult);
        }
    }
}
