using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebDemo.Models
{
    public class Article
    {
        public int Id { get; internal set; }

        public AppUser User { get; set; }
    }
}
