using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebDemo.Models;

namespace WebDemo.Models
{
    public class AppDBContext : IdentityDbContext<AppUser>
    {
        public DbSet<Article> Articles { get; set; }


        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }

    }
}
