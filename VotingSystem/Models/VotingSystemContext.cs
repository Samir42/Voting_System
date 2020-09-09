using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace VotingSystem.Models
{
    public partial class VotingSystemContext : DbContext
    {
        public VotingSystemContext()
        {
        }

        public VotingSystemContext(DbContextOptions<VotingSystemContext> options)
            : base(options)
        {

        }

        public virtual DbSet<Candidates> Candidates { get; set; }
        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<Voters> Voters { get; set; }
        public virtual DbSet<VotersCandidates> VotersCandidates { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //{
            //    optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=VotingSystem;Trusted_Connection=True;");
            //}
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Candidates>(entity =>
            {
                entity.Property(e => e.CategoryId).HasColumnName("Category_Id");

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
                    .HasConstraintName("FK__Candidate__Categ__4CA06362");
            });

            modelBuilder.Entity<Categories>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("UQ__Categori__737584F68CF88A2D")
                    .IsUnique();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Voters>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<VotersCandidates>(entity =>
            {
                entity.HasIndex(e => new { e.VoterId, e.CategoryId })
                    .HasName("UQ__VotersCa__14531FB299D54805")
                    .IsUnique();

                entity.Property(e => e.CandidateId).HasColumnName("Candidate_Id");

                entity.Property(e => e.CategoryId).HasColumnName("Category_Id");

                entity.Property(e => e.VoterId).HasColumnName("Voter_Id");

                entity.HasOne(d => d.Candidate)
                    .WithMany(p => p.VotersCandidates)
                    .HasForeignKey(d => d.CandidateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__VotersCan__Candi__72C60C4A");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.VotersCandidates)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__VotersCan__Categ__71D1E811");

                entity.HasOne(d => d.Voter)
                    .WithMany(p => p.VotersCandidates)
                    .HasForeignKey(d => d.VoterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__VotersCan__Voter__70DDC3D8");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
