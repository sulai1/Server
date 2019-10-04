using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebDemo.Models;
using WebDemo.Models.Articles;

namespace WebDemo.Models
{


    public class AppDBContext : IdentityDbContext<AppUser>
    {
        public DbSet<Article> Articles { get; set; }

        public DbSet<TextElement> TextElements { get; set; }

        public DbSet<Slot> Slots { get; set; }

        public DbSet<SlotType> SlotTypes { get; set; }

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Slot>().HasKey(s => new { s.ArticleId, s.SlotTypeId });
        }

        public DbSet<WebDemo.Models.Articles.Element> Element { get; set; }
    }
}
