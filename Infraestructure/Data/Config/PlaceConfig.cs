using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.Data.Config
{
    public class PlaceConfig : IEntityTypeConfiguration<Place>
    {
        public void Configure(EntityTypeBuilder<Place> builder)
        {
          builder.Property(l => l.id).IsRequired();
          builder.Property(l => l.name).IsRequired().HasMaxLength(100);
          builder.Property(l => l.Description).IsRequired();
          builder.Property(l => l.Cost).IsRequired();
          
         #region relationships
          builder.HasOne(c => c.category).WithMany()
          .HasForeignKey(l => l.CategoryId);
          builder.HasOne(p => p.country).WithMany()
          .HasForeignKey(l => l.CountryId);
          #endregion
          
        }
    }
}