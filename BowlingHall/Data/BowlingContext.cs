using Microsoft.EntityFrameworkCore;
using BowlingLib.Model;

namespace BowlingLib.Data
{
    public class BowlingContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=bowling.db");
        }

        public DbSet<Competition> Competitions { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Lane> Lanes { get; set; }
        public DbSet<CompetitionMember> CompetitionMembers { get; set; }
        public DbSet<MatchMember> MatchMembers { get; set; }

    }
}
