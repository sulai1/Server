
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebDemo.Models.Articles
{
    [ModelBinder(BinderType = typeof(ElementModelBinder))]
    public abstract class Element
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public SlotType Type { get; set; }

        [Required]
        public int Sort { get; set; }

        public abstract string Html();
    }
}