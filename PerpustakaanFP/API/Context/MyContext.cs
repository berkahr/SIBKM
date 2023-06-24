using API.Model;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Context
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options) { }

        public DbSet<Book> Book { get; set; }
        public DbSet<Borrow> Borrow { get; set; }
        public DbSet<Member> Member { get; set; }
        public DbSet<Accounts> Accounts { get; set; }
        public DbSet<AccountRoles> AccountRoles { get; set; }
        public DbSet<Roles> Roles { get; set; }
        // Fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // One Anggora has many Meminjam
            modelBuilder.Entity<Member>()
                        .HasMany(m => m.Borrow)
                        .WithOne(b => b.Member)
                        .IsRequired(false)
                        .HasForeignKey(m => m.MemberId)
                        .OnDelete(DeleteBehavior.Restrict);
            // One Meminjam has many Buku
            modelBuilder.Entity<Borrow>()
                        .HasMany(b => b.Book)
                        .WithOne(bo => bo.Borrow)
                        .IsRequired(false)
                        .HasForeignKey(b => b.Id)
                        .OnDelete(DeleteBehavior.Restrict);
            // One member has one Account
            modelBuilder.Entity<Member>()
                        .HasOne(m => m.Accounts)
                        .WithOne(a => a.Member)
                        .IsRequired(false)
                        .HasForeignKey<Accounts>(e => e.memberId)
                        .OnDelete(DeleteBehavior.Restrict);
            // One Account has many AccountRole
            modelBuilder.Entity<Accounts>()
                        .HasMany(e => e.AccountRoles)
                        .WithOne(a => a.Accounts)
                        .IsRequired(false)
                        .HasForeignKey(a => a.AccountId)
                        .OnDelete(DeleteBehavior.Restrict);

            // Many AccountRole has one Role
            modelBuilder.Entity<AccountRoles>()
                        .HasOne(a => a.Roles)
                        .WithMany(r => r.AccountRoles)
                        .IsRequired(false)
                        .HasForeignKey(r => r.role_id)
                        .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
