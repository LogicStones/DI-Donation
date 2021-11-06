using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.Models
{
    public class ScreenSaverViewModel
    {
        public int Id { get; set; }
        public string ScreenName { get; set; }

        [Required(ErrorMessage = "Screen is required")]
        [Display(Name = "Select Screen Saver")]
        public IFormFile ScreenFile { get; set; }
        public bool IsActive { get; set; }
        public DateTime AddedAt { get; set; }
    }
}
