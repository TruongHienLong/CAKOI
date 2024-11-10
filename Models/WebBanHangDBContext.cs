using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;


namespace SellFishLuxury.Models
{
    public class WebBanHangDBContext : IdentityDbContext<User>
    {
        public WebBanHangDBContext(DbContextOptions<WebBanHangDBContext> options) : base(options) { }
        public DbSet<DanhMucSP> DanhMucSPs { get; set; }
        public DbSet<LoaiSP> LoaiSPs { get; set; }
        public DbSet<SanPham> SanPhams { get; set; }
        public DbSet<TonKho> TonKhos { get; set; }
        public DbSet<MauSac> MauSacs { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //seed data to table Categories
            modelBuilder.Entity<DanhMucSP>().HasData(
            );

            // Bảng LoaiSP
            modelBuilder.Entity<LoaiSP>().HasData(
            
            );
            //seed data to table Product
            modelBuilder.Entity<SanPham>().HasData(
            );

            // màu sắc
            modelBuilder.Entity<MauSac>().HasData(
           );
            // Tồn Kho
            modelBuilder.Entity<TonKho>().HasData(
            new TonKho { IdSPTonKho = 1, SoLuong = 1 });
        }
    }
}
