using HastaneProje.Areas.Identity.Data;
using HastaneProje.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HastaneProje.Areas.Identity.Data;

public class ApplicationDbContext : IdentityDbContext<HastaneUser>
{
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Branch> Branches { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
        builder.ApplyConfiguration(new ApplicationUserEntityConfiguration());
        builder.ApplyConfiguration(new DoctorEntityConfiguration());
    }
}

public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<HastaneUser>
{
    public void Configure(EntityTypeBuilder<HastaneUser> builder)
    {
        builder.Property(u => u.FirstName).HasMaxLength(50);
        builder.Property(u => u.LastName).HasMaxLength(50);
    }
}

public class DoctorEntityConfiguration : IEntityTypeConfiguration<Doctor>
{
    public void Configure(EntityTypeBuilder<Doctor> builder)
    {
        builder.HasOne(d => d.MainBranch)
               .WithMany(b => b.MainBranchDoctors)
               .HasForeignKey(d => d.MainBranchId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(d => d.PolyclinicBranch)
               .WithMany(b => b.PolyclinicDoctors)
               .HasForeignKey(d => d.PolyclinicBranchId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
