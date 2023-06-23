using API.Model;
using Microsoft.EntityFrameworkCore;

namespace API.Context
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options) { }

        public DbSet<Book> Book { get; set; }
        public DbSet<Borrow> Borrow { get; set; }
        public DbSet<Member> Member { get; set; }
        public DbSet<Member> Officer { get; set; }
        // Fluent API
        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
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
                        .HasForeignKey(b => b.BookId)
                        .OnDelete(DeleteBehavior.Restrict);
        // One Officer has many Borrow
            modelBuilder.Entity<officer>()
                        .HasMany(o => o.Borrow)
                        .WithOne(b => b.Officer)
                        .IsRequired(false)
                        .HasForeignKey(o => o.OfficerId)
                        .OnDelete(DeleteBehavior.Restrict);
        }*/
    }
}
