using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccess.Entities
{
    public class Screens
    {
        [Key]
        public int Id { get; set; }
        public string ScreenPath { get; set; }
        public bool IsActive { get; set; }
        public DateTime AddedAt { get; set; }
    }
}
