using BowlingLib.Data;
using BowlingLib.Model;
using BowlingLib.Model.Interfaces;
using BowlingTestBase;
using Xunit;

namespace BowlingIntegrationTests
{
    public class VerifyRequirements
    {
        //Verifiera med integrationstester attdet går att generera, lagra och hämta tävlingsinformation.
        [Fact]
        public void CruCompetitionInfo()
        {
            // Create competition, assert
            // Read competition, assert
            // Update competition, assert

        }

        //Verifiera med integrationstester attdet går att generera, lagra och hämta medlemmar.
        [Fact]
        public void CruMember()
        {
            Repository repo = new Repository();
            Member member = new Member(999);
            // Create Member, assert
            var cResult = repo.Create(member);
            Assert.Equal(DatabaseResultState.successful, cResult);

            // Read Member, assert
            var rResult = repo.GetMemberById(member.MemberId);
            Assert.Equal(member, rResult);

            // Update Member, assert
            // Kind of pointless, as member only has one property, which is unchangable
        }
    }
}
