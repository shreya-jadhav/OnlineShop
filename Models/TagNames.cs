using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Models
{
    public class TagNames
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Tag Name")]
        public string TagName { get; set; }
    }
}
