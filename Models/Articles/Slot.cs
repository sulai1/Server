using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebDemo.Models.Articles
{
    public class Slot
    {
        [Key, Column(Order=0)]
        public int ArticleId { get; set; }
        [ForeignKey("ArticleId")]
        public Article Article { get; set; }

        [Key, Column(Order = 1)]
        public int SlotTypeId{ get; set; }
        [ForeignKey("SlotTypeId")]
        public SlotType SlotType { get; set; }

        public List<Element> Elements { get; set; }
    }
}
