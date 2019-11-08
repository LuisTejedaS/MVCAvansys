using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MVCAvansys.DataLayer
{
    public class MVCAvansysContext : DbContext
    {
        public MVCAvansysContext()
        {

        }
 
        public MVCAvansysContext(DbContextOptions<MVCAvansysContext> options)
            : base(options)
        {
        }

        public DbSet<Career> Career { get; set; }
        public DbSet<Student> Student { get; set; }
    }
}
