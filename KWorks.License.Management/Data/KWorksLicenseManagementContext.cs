using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KWorks.License.Management.Models;

namespace KWorks.License.Management.Data
{
    public class KWorksLicenseManagementContext : DbContext
    {
        public KWorksLicenseManagementContext (DbContextOptions<KWorksLicenseManagementContext> options) : base(options)
        {       
        }

        public DbSet<UserV1> UserV1 { get; set; }
        public DbSet<CompanyV1> CompanyV1 { get; set; }
        public DbSet<LicenseV1> LicenseV1 { get; set; }
        public DbSet<DeviceV1> DeviceV1 { get; set; }
        public DbSet<PropertyV1> PropertyV1 { get; set; }
        public DbSet<PropertyValueV1> PropertyValueV1 { get; set; }
        public DbSet<NoticeV1> NoticeV1 { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UserV1>(m =>
            {
                m.ToTable("KLC_V01_USER").HasKey(x => x.Id);
                m.HasOne(x => x.Organizations).WithMany().HasForeignKey(x => x.OrganizationId);
                m.HasOne(x => x.Positions).WithMany().HasForeignKey(x => x.PositionId);
            });

            builder.Entity<CompanyV1>(m =>
            {
                m.ToTable("KLC_V01_COMPANY");
            });

            builder.Entity<LicenseV1>(m =>
            {
                m.ToTable("KLC_V01_LICENSE");
                m.HasOne(x => x.Users).WithMany().HasForeignKey(x => x.UserId);
                m.HasOne(x => x.Companyes).WithMany().HasForeignKey(x => x.CompanyId);
                m.HasOne(x => x.Programs).WithMany().HasForeignKey(x => x.ProgramId);
                m.HasMany(x => x.Devices).WithOne().HasForeignKey(x => x.LicenseId);
            });

            builder.Entity<DeviceV1>(m =>
            {
                m.ToTable("KLC_V01_DEVICE");
            });

            builder.Entity<PropertyV1>(m =>
            {
                m.ToTable("KLC_V01_PROPERTY");
                m.HasMany(x => x.PropertyValues).WithOne().HasForeignKey(x => x.PropertyId);
            });

            builder.Entity<PropertyValueV1>(m =>
            {
                m.ToTable("KLC_V01_PROPERTY_VALUE");
            });

            builder.Entity<NoticeV1>(m =>
            {
                m.ToTable("KLC_V01_NOTICE");
                m.HasOne(x => x.Users).WithMany().HasForeignKey(x => x.CreatorId);
            });

            base.OnModelCreating(builder);
        }
    }
}
