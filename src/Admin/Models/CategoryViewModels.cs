using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Admin.Models
{
    public class CategoryListViewModel
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public int TypeId { get; set; }
        public bool isActive { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
    }

    public class CategoryViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        public List<CategoryTypeViewModel> lstCategoryTypes { get; set; }

        [Display(Name = "Type")]
        public int TypeId { get; set; }
    }

    public class CategoryTypeViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}