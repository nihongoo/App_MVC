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
    internal class CartConfigs : IEntityTypeConfiguration<GioHang>
    {
        public void Configure(EntityTypeBuilder<GioHang> builder)
        {
            builder.ToTable("Carts");
            builder.HasKey(p => p.CartId);
            builder.Property(p => p.CreationDate).HasColumnName("Ngày Tạo").HasColumnType("datetime");
            builder.HasOne(x => x.User).WithMany(x => x.GioHang).HasForeignKey(x => x.UserId);
        }
    }
}
