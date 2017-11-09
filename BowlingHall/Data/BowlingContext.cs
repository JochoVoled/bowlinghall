using Microsoft.EntityFrameworkCore;
using BowlingLib.Model;

namespace BowlingLib.Data
{
    public class BowlingContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //string connectionString = @"Data Source=C:\Users\Johannes Smidelöv\source\repos\BowlingHall\BowlingHall\bowling.db";
            //optionsBuilder.UseSqlite(connectionString);
            optionsBuilder.UseSqlite("Data Source=bowling.db");
        }

        public DbSet<Competition> Competition { get; set; }
        public DbSet<Match> Match { get; set; }
        public DbSet<Member> Member { get; set; }
        public DbSet<Lane> Lane { get; set; }
        public DbSet<CompetitionMember> CompetitionMember { get; set; }
        public DbSet<MatchMember> MatchMember { get; set; }

    }
}
