using System;
using System.Collections.Generic;
using EFCodeFirst.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCodeFirst.EntityConfigurations
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.ToTable("Project").HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("ProjectId");
            builder.Property(e => e.Name).IsRequired().HasColumnName("Name").HasMaxLength(50);
            builder.Property(e => e.Budget).IsRequired().HasColumnName("Budget").HasColumnType("money");
            builder.Property(e => e.StartedDate).IsRequired().HasColumnName("StartedDate").HasColumnType("datetime2(7)");

            builder.HasData(new List<Project>()
            {
                new Project() { Id = 1, Name = "WebShop", Budget = 1563546, StartedDate = new DateTime(2020, 5, 4) },
                new Project() { Id = 2, Name = "Shipper", Budget = 978783, StartedDate = new DateTime(2001, 6, 10) },
                new Project() { Id = 3, Name = "EmailWorker", Budget = 68524, StartedDate = new DateTime(1983, 12, 8) }
            });
        }
    }
}