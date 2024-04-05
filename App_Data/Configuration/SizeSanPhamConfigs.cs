using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App_Data.Models;
using System.Security.Cryptography.X509Certificates;

namespace App_Data.Configuration
{
    internal class ProductSizeConfigs : IEntityTypeConfiguration<SizeSanPham>
    {
        public void Configure(EntityTypeBuilder<SizeSanPham> builder)
        {
            builder.ToTable("ProductSizes");
            builder.HasKey(p => new { p.ProductId, p.SizeId });
            builder.HasOne(x => x.Size).WithMany(x => x.SizeSanPhams).HasForeignKey(x => x.SizeId);
            builder.HasOne(x => x.SanPham).WithMany(x => x.SizeSanPhams).HasForeignKey(x => x.ProductId);
        }
    }
}
