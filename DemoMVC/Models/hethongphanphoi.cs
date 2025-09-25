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
    public class HeThongPhanPhoi
    
    {
        [Key]
        public string MaHTPP { get; set; }
        public string TenHTPP { get; set; }
    }
}