using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel.DataAnnotations;

namespace DemoMVC.Models
{
    public class Daily
    {
        [Key]
        public int MaDaiLy { get; set; }
        public string TenDaiLy { get; set; }
        public string DiaChi { get; set; }
        public string NguoiDaiDien { get; set; }
        public string DienThoai { get; set; }

        // Khóa ngoại đến Hệ Thống Phân Phối
        public string MaHTPP { get; set; }
        public HeThongPhanPhoi HeThongPhanPhoi { get; set; }
    }
}