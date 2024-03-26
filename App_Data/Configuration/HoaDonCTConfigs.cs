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
    internal class InvoiceDetailConfigs : IEntityTypeConfiguration<HoaDonCT>
    {
        public void Configure(EntityTypeBuilder<HoaDonCT> builder)
        {
            builder.ToTable("InvoiceDetails");
            builder.HasKey(p => p.InvoiceDetailId);
            builder.Property(p => p.Quantity).HasColumnName("Số Lượng").HasColumnType("int");
            builder.Property(p => p.UnitPrice).HasColumnName("Đơn Giá").HasColumnType("decimal(18,2)");
        }
    }
}
