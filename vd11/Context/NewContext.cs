using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vd11.Models;

namespace vd11.Context
{
    public class NewContext:DbContext
    {
        public NewContext(DbContextOptions<NewContext> options) : base(options)
        {
            
        }
        public DbSet<CongTy> CongTy { get; set; }
        public DbSet<NhanVien> NhanVien { get; set; }
        public DbSet<ThamNien> ThamNien { get; set; }

    }
}
