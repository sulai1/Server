using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebDemo.Models.Articles
{
    public class Article
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; internal set; }

        [BindProperty, Required]
        public string Name { get; set; }

        [Required]
        public AppUser User { get; set; }

        [Required, Display(Name = "Public")]
        public bool IsPublic { get; set; } = true;

        List<Slot> Slots { get; set; } 
    }
}
