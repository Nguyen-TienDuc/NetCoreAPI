using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace DemoMVC.Models
{
    public class person
    {public string personId { get; set; }
        public string fullname { get; set; }
        public string address { get; set; }
        public int YearOfBirth { get; set; }
        public int Age { get; set; }
    }
}