using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace App_Data.Models;

public partial class Sd18302Net104Context : DbContext
{
    public Sd18302Net104Context()
    {
    }

    public Sd18302Net104Context(DbContextOptions<Sd18302Net104Context> options)
        : base(options)
    {
    }
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<GioHang> GioHangs { get; set; }
    public DbSet<GioHangCT> GioHangCTs { get; set; }
    public DbSet<HoaDon> HoaDons { get; set; }
    public DbSet<HoaDonCT> HoaDonCTs { get; set; }
    public DbSet<LoaiSP> LoaiSPs { get; set; }
    public DbSet<SanPham> SanPhams { get; set; }
    public DbSet<Size> Sizes { get; set; }
    public DbSet<SizeSanPham> SizeSanPhams { get; set; }
    public DbSet<ThuongHieu> ThuongHieus { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=NIHONGGOO\\SQLEXPRESS;Database=SD18302_NET104;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
