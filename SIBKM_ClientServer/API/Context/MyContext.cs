using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Context;

public class MyContext : DbContext
{
    public MyContext(DbContextOptions<MyContext> options) : base(options) { }

    public DbSet<Employee> Employees { get; set; }
    public DbSet<Profilings> Profilings { get; set; }
    public DbSet<AccountRoles> AccountRoles { get; set; }
    public DbSet<Accounts> Accounts { get; set; }
    public DbSet<Educations> Educations { get; set; }
    public DbSet<Roles> Roles { get; set; }
    public DbSet<Universities> Universities { get; set;}
    
    // Fluent API
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // One University has many Educations
        modelBuilder.Entity<Universities>()
                    .HasMany(u => u.Educations)
                    .WithOne(e => e.Universities)
                    .IsRequired(false)
                    .HasForeignKey(e => e.university_id)
                    .OnDelete(DeleteBehavior.Restrict);

        // One Education has one Profiling
        modelBuilder.Entity<Educations>()
                    .HasOne(e => e.Profilings)
                    .WithOne(p => p.Educations)
                    .IsRequired(false)
                    .HasForeignKey<Profilings>(p => p.education_id)
                    .OnDelete(DeleteBehavior.Restrict);

        // One Profiling has one Employee
        modelBuilder.Entity<Employee>()
                    .HasOne(e => e.Profilings)
                    .WithOne(p => p.Employee)
                    .HasForeignKey<Profilings>(p => p.employee_nik)
                    .OnDelete(DeleteBehavior.Restrict);

        // One Employee has one Account
        modelBuilder.Entity<Employee>()
                    .HasOne(e => e.Accounts)
                    .WithOne(a => a.Employee)
                    .IsRequired(false)
                    .HasForeignKey<Accounts>(e => e.employee_nik)
                    .OnDelete(DeleteBehavior.Restrict);

        // One Account has many AccountRole
        modelBuilder.Entity<Accounts>()
                    .HasMany(e => e.AccountRoles)
                    .WithOne(a => a.Accounts)
                    .IsRequired(false)
                    .HasForeignKey(a => a.account_nik)
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