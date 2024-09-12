using System.Collections.Generic;
using EFCodeFirst.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCodeFirst.EntityConfigurations
{
    public class OfficeConfiguration : IEntityTypeConfiguration<Office>
    {
        public void Configure(EntityTypeBuilder<Office> builder)
        {
            builder.ToTable("Office").HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("OfficeId");
            builder.Property(e => e.Title).IsRequired().HasColumnName("Title").HasMaxLength(100);
            builder.Property(e => e.Location).IsRequired().HasColumnName("Location").HasMaxLength(100);

            builder.HasData(new List<Office>()
            {
                new Office() { Id = 1, Title = "MainOffice", Location = "China" },
                new Office() { Id = 2, Title = "UkraineOffice", Location = "Ukraine" },
                new Office() { Id = 3, Title = "USAOffice", Location = "USA" }
            });
        }
    }
}
