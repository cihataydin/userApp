using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using UserApi.Data;
using Microsoft.Extensions.Configuration;

namespace UserApi
{
    public partial class UserDBContext : DbContext
    {
        public UserDBContext()
        {
           
        }

        public virtual DbSet<UserEntity> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConnectionStringConstant.msSqlConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");

            modelBuilder.Entity<UserEntity>(entity =>
            {
                entity.ToTable("users");

                entity.Property(i => i.Id).HasColumnName("id").HasColumnType("int").UseIdentityColumn().IsRequired();
                entity.Property(i => i.Name).HasColumnName("name").HasColumnType("nvarchar").HasMaxLength(250);
                entity.Property(i => i.Surname).HasColumnName("surname").HasColumnType("nvarchar").HasMaxLength(250);
                entity.Property(i => i.BirthDate).HasColumnName("birth_date");
                entity.Property(i => i.Email).HasColumnName("email");
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
