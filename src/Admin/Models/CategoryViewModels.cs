using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Admin.Models
{
    public class CategoryListViewModel
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string SubCategoryName { get; set; }
        public int SubCategoryId { get; set; }
        public int TypeId { get; set; }
        public bool isActive { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
    }

    public class CategoryViewModel: SubCategoryViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        public List<CategoryTypeViewModel> lstCategoryTypes { get; set; }

        [Display(Name = "Type")]
        public int TypeId { get; set; }

        [Display(Name="Sub Categories")]
        public bool HasSubCategory { get; set; }
    }

    public class CategoryTypeViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class SubCategoryViewModel
    {
        public List<int> SubCategoryId { get; set; } = new List<int>();

        [Required(ErrorMessage = "Sub Category is required")]
        [Display(Name = "Sub Category Name")]
        public List<string> SubCategoryName { get; set; } = new List<string>();

        [Display(Name = "Price")]
        public List<float> QuotedPrice { get; set; } = new List<float>();

        [Display(Name = "Active")]
        public List<bool> IsActive { get; set; } = new List<bool>();
    }
}