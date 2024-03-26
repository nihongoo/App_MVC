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
    internal class SizeConfigs : IEntityTypeConfiguration<Size>
    {
        public void Configure(EntityTypeBuilder<Size> builder)
        {
            builder.ToTable("Sizes");
            builder.HasKey(p => p.SizeId);
            builder.Property(p => p.SizeName).HasColumnName("Kích Thước").HasColumnType("nvarchar(50)");
        }
    }
}