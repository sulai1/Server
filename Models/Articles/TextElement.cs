using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebDemo.Models.Articles
{
    public class TextElement : Element
    {
        public string Text { get; set; }

        public override string Html()
        {
            return Text;
        }
    }
}
