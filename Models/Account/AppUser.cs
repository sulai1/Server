using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using WebDemo.Models.Articles;

namespace WebDemo.Models
{
    public class AppUser : IdentityUser
    {
        //add your custom properties which have not included in IdentityUser before
        public List<Article> Articles { get; set; }
    }
}