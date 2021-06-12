using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UsersApi.Models;

namespace UsersApi.Models
{
    public class CompanyContext:DbContext
    {
        public DbSet<Company> Companies{ get; set; }

        public CompanyContext(DbContextOptions<CompanyContext> options)
            : base(options)
        {

            Database.EnsureCreated();
        }

        public DbSet<UsersApi.Models.User> User { get; set; }
    }
}
