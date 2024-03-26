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
    internal class ProductTypeConfigs : IEntityTypeConfiguration<LoaiSP>
    {
        public void Configure(EntityTypeBuilder<LoaiSP> builder)
        {
            builder.ToTable("ProductTypes");
            builder.HasKey(p => p.TypeId);
            builder.Property(p => p.TypeName).HasColumnName("Tên loại sản phẩm").HasColumnType("nvarchar(255)");
        }
    }
}
