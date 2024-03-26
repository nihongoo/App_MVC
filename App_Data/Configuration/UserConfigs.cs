using App_Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Data.Configuration
{
    internal class UserConfigs : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            //thực hiện các config trên entity
            builder.ToTable("User");//đặt tên bảng
            builder.HasKey(p => p.UserId);//set khóa là cột ID
                                          //builder.HasKey(p=>new { p.ID, p.Username }); //khóa nhiều cột

            //thiết lập thuộc tính cho cột
            builder.Property(p => p.FullName).HasColumnName("Tên").HasColumnType("nvarchar(50)");

            builder.Property(p => p.Password).HasColumnName("Mật khẩu").HasMaxLength(50).IsUnicode(true);//giống cái ở trên
            builder.Property(p => p.Address).HasColumnName("Địa chỉ").HasColumnType("nvarchar(255)");
            builder.Property(p => p.Email).HasColumnName("Email").HasColumnType("nvarchar(255)");
            builder.Property(p => p.Phone).HasColumnName("Số điện thoại").HasColumnType("nvarchar(20)");
            builder.Property(p => p.Role).HasColumnName("Vai trò").HasColumnType("nvarchar(50)");
        }
    }

}
