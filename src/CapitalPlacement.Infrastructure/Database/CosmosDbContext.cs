using CapitalPlacement.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace CapitalPlacement.Infrastructure.Database
{
    public class CosmosDbContext : DbContext
    {
        public CosmosDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<ProgramEntity> Programs { get; set; }
        public DbSet<QuestionEntity> Questions { get; set; }
        public DbSet<CandidateApplicationEntity> CandidateApplications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAutoscaleThroughput(1000);
            modelBuilder.Entity<ProgramEntity>()
                .HasNoDiscriminator()
                .ToContainer("Programs")
                .HasPartitionKey(p => p.Id)
                .HasKey(p => p.Id);

            modelBuilder.Entity<QuestionEntity>()
                .HasNoDiscriminator()
                .ToContainer("Questions")
                .HasPartitionKey(q => q.QuestionType)
                .HasKey(q => q.Id);

            modelBuilder.Entity<CandidateApplicationEntity>()
                .HasNoDiscriminator()
                .ToContainer("CandidateApplications")
                .HasPartitionKey(c => c.Id)
                .HasKey(c => c.Id);
        }

    }
}
