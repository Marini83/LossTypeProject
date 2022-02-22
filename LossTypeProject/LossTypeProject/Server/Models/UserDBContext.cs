using Microsoft.EntityFrameworkCore;

namespace LossTypeProject.Server.Models
{
    public partial class UserDBContext : DbContext
    {
        public UserDBContext()
        {
        }

        public UserDBContext(DbContextOptions<UserDBContext> options)
            : base(options)
        {
        }
        public virtual DbSet<LossType> LossTypes { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LossType>(entity =>
            {
                entity.ToTable("LossTypes");

                entity.Property(e => e.LossTypeID).HasColumnName("LossTypeID");

                entity.Property(e => e.LossTypeCode)
                    .HasMaxLength(2)
                    .IsUnicode(false);
                entity.Property(e => e.LossTypeDescription)
                  .HasMaxLength(20)
                  .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("Users");

                entity.Property(e => e.UserID).HasColumnName("UserID");

                //entity.Property(e => e.UserID)
                //    .HasMaxLength(20)
                //    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Active)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.DisplayName)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
