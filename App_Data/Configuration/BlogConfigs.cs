using App_Data.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Data.Configuration
{
    internal class BlogConfigs : IEntityTypeConfiguration<Blog>
    {
        public void Configure(EntityTypeBuilder<Blog> builder)
        {
            builder.ToTable("Blogs");
            builder.HasKey(p => p.BlogId);
            builder.Property(p => p.Title).HasColumnName("Tiêu đề").HasColumnType("nvarchar(255)");
            builder.Property(p => p.Content).HasColumnName("Nội dung").HasColumnType("nvarchar(max)");
            builder.Property(p => p.PublishDate).HasColumnName("Ngày Đăng").HasColumnType("datetime");
        }
    }
}
