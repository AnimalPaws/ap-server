using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ap_server.Model
{
    public partial class ap_dbContext : DbContext
    {
        public ap_dbContext()
        {
        }

        public ap_dbContext(DbContextOptions<ap_dbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Donation> Donations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;password=;database=ap_db;convert zero datetime=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Donation>(entity =>
            {
                entity.ToTable("donation");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.CategoryId)
                    .HasColumnType("int(11)")
                    .HasColumnName("category_id")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("description");

                entity.Property(e => e.Goal)
                    .HasColumnName("goal")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Image)
                    .HasColumnType("blob")
                    .HasColumnName("image")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Likes)
                    .HasColumnType("int(11)")
                    .HasColumnName("likes")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.ProfileId)
                    .HasColumnType("int(11)")
                    .HasColumnName("profile_id")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("title");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
