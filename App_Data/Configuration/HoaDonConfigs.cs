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
    internal class InvoiceConfigs : IEntityTypeConfiguration<HoaDon>
    {
        public void Configure(EntityTypeBuilder<HoaDon> builder)
        {
            builder.ToTable("Invoices");
            builder.HasKey(p => p.InvoiceId);
            builder.Property(p => p.CreationDate).HasColumnName("Ngày Tạo").HasColumnType("datetime");
            builder.Property(p => p.DeliveryDate).HasColumnName("Ngày Giao Hàng").HasColumnType("datetime");
            builder.Property(p => p.Address).HasColumnName("Địa chỉ").HasColumnType("nvarchar(255)");
            builder.Property(p => p.Status).HasColumnName("Trạng thái").HasColumnType("nvarchar(50)");
            builder.HasOne(x => x.User).WithMany(x => x.HoaDon).HasForeignKey(x => x.UserId);
        }
    }
}
