using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccess.Entities
{
    public class BankAccount
    {
        [Key]
        public int Id { get; set; }
        public string AccountName { get; set; }
        public string SumUpMerchantId { get; set; }
        public bool IsActive { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}
