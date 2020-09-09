using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Context
{
    public partial class VotingSystemContext : DbContext, IVotingSystemContext
    {
        public VotingSystemContext()
        {
        }

        public VotingSystemContext(DbContextOptions<VotingSystemContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Candidate> Candidates { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Voter> Voters { get; set; }
        public virtual DbSet<VoterCandidate> VotersCandidates { get; set; }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //{
            //    optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=VotingSystem;Trusted_Connection=True;");
            //}
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Candidate>(entity =>
            {
                entity.HasIndex(e => e.IdNumber)
                    .HasName("UQ__Candidat__01631DBEEEF4D400")
                    .IsUnique();

                entity.HasIndex(e => new { e.CategoryId, e.Id })
                    .HasName("unq_Candidates_Candidate_Category")
                    .IsUnique();

                entity.Property(e => e.CategoryId).HasColumnName("Category_Id");

                entity.Property(e => e.IdNumber)
                    .IsRequired()
                    .HasColumnName("ID_Number")
                    .HasMaxLength(15);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Candidates)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Candidate__Categ__4F7CD00D");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("UQ__Categori__737584F6CE188273")
                    .IsUnique();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Voter>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<VoterCandidate>(entity =>
            {
                entity.HasIndex(e => new { e.VoterId, e.CategoryId })
                    .HasName("unq_VotersCandidates_Voter_Category")
                    .IsUnique();

                entity.Property(e => e.CandidateId).HasColumnName("Candidate_Id");

                entity.Property(e => e.CategoryId).HasColumnName("Category_Id");

                entity.Property(e => e.VoterId).HasColumnName("Voter_Id");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.VotersCandidates)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__VotersCan__Categ__5BE2A6F2");

                entity.HasOne(d => d.Voter)
                    .WithMany(p => p.VotersCandidates)
                    .HasForeignKey(d => d.VoterId)
                    .HasConstraintName("FK__VotersCan__Voter__5AEE82B9");

                entity.HasOne(d => d.Ca)
                    .WithMany(p => p.VotersCandidates)
                    .HasPrincipalKey(p => new { p.CategoryId, p.Id })
                    .HasForeignKey(d => new { d.CategoryId, d.CandidateId })
                    .HasConstraintName("fk_voterscandidates_candidates");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
