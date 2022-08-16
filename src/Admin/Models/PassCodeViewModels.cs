using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Admin.Models
{
    public class PassCodeViewModel
    {
        [Required]
        [Display(Name = "Auth String")]
        public string AuthString { get; set; }
    }
}