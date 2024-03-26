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
    internal class CartDetailConfigs : IEntityTypeConfiguration<GioHangCT>
    {
        public void Configure(EntityTypeBuilder<GioHangCT> builder)
        {
            builder.ToTable("CartDetails");
            builder.HasKey(p => p.CartDetailId);
            builder.Property(p => p.Quantity).HasColumnName("Số Lượng").HasColumnType("int");
        }
    }
}
