using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccess.Entities
{
    public class SubCategories
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public float QuotedPrice { get; set; }
        public int CategoryId { get; set; }
        public bool IsActive { get; set; }
    }
}
