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
    internal class ProductConfigs : IEntityTypeConfiguration<SanPham>
    {
        public void Configure(EntityTypeBuilder<SanPham> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(p => p.ProductId);
            builder.Property(p => p.Name).HasColumnName("Tên").HasColumnType("nvarchar(255)");
            builder.Property(p => p.Price).HasColumnName("Giá").HasColumnType("decimal(18,2)");
            builder.Property(p => p.Material).HasColumnName("Chất Liệu").HasColumnType("nvarchar(255)");
            builder.Property(p => p.ImportDate).HasColumnName("Ngày Nhập").HasColumnType("datetime");
            builder.Property(p => p.Image).HasColumnName("Ảnh").HasColumnType("nvarchar(max)");
            builder.Property(p => p.Quantity).HasColumnName("Số Lượng").HasColumnType("int");
            builder.HasOne(x=>x.LoaiSP).WithMany(x=>x.sanPhams).HasForeignKey(x=>x.ProductTypeId);
            builder.HasOne(x=>x.ThuongHieu).WithMany(x=>x.sanPhams).HasForeignKey(x=> x.BrandId);
        }
    }
}
