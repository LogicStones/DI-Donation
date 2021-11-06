using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccess.Entities
{
    public class Campaign
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public float Amount { get; set; }
        public float Fees { get; set; }
        public string TransactionId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
