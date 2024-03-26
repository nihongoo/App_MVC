using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App_Data.Models;

namespace App_Data.Configuration
{
    internal class BrandConfigs : IEntityTypeConfiguration<ThuongHieu>
    {
        public void Configure(EntityTypeBuilder<ThuongHieu> builder)
        {
            builder.ToTable("Brands");
            builder.HasKey(p => p.BrandId);
            builder.Property(p => p.Name).HasColumnName("Tên").HasColumnType("nvarchar(255)");
        }
    }
}
