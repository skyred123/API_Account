using Microsoft.EntityFrameworkCore;
using DataModels.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DataModels
{
	public class AppDbContext : DbContext
	{
		DbSet<User> Users { get; set; }
		DbSet<Login> Logins { get; set; }
		DbSet<Role> Roles { get; set; }
		DbSet<RoleClaim> RoleClaims { get; set; }
		DbSet<RoleUser> RoleUsers { get; set; }
		DbSet<Token> Tokens { get; set; }

		public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
		{
		}
		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			PrimaryKey(builder);
			Relationship_OneToMany(builder);
			Relationship_ManyToMany(builder);
			Relationship_OneToOne(builder);
		}
		private void PrimaryKey(ModelBuilder builder)
		{
			builder.Entity<User>().HasKey(a => a.Id);
			builder.Entity<Login>().HasKey(a => a.ProviderKey);
			builder.Entity<Role>().HasKey(a => a.Id);
			builder.Entity<Token>().HasKey(a => a.Id);
			builder.Entity<RoleClaim>().HasKey(a => a.Id);
		}
		private void Relationship_OneToMany(ModelBuilder builder)
		{
			builder.Entity<User>()
				.HasMany(a => a.Logins)
				.WithOne(a => a.User)
				.HasForeignKey(a => a.UserId)
				.OnDelete(DeleteBehavior.NoAction);
			builder.Entity<User>()
				.HasMany(a => a.Tokens)
				.WithOne(a => a.User)
				.HasForeignKey(a => a.UserId)
				.OnDelete(DeleteBehavior.NoAction);
		}
		private void Relationship_ManyToMany(ModelBuilder builder)
		{
			builder.Entity<RoleUser>()
				.HasKey(a => new { a.RoleId, a.UserId });
			builder.Entity<RoleUser>()
				.HasOne(a => a.Role)
				.WithMany(a => a.RoleUsers)
				.HasForeignKey(a =>a.RoleId)
				.OnDelete(DeleteBehavior.Cascade);
			builder.Entity<RoleUser>()
				.HasOne(a => a.User)
				.WithMany(a => a.RoleUsers)
				.HasForeignKey(a => a.UserId)
				.OnDelete(DeleteBehavior.Cascade);
		}
		private void Relationship_OneToOne(ModelBuilder builder)
		{
		}
	}
}
