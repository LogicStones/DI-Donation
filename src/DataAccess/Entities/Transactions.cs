using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccess.Entities
{
    public class Transactions
    {
        [Key]
        public string Id { get; set; }
        public int CategoryId { get; set; }
        public float Amount { get; set; }
        public float TransactionFees { get; set; }
        public bool isFeeInclusive { get; set; }
        public string ReferenceTransactionId { get; set; }
        public DateTime TimeStamp { get; set; }
        public string SponsorFirstName { get; set; }
        public string SponsorLastName { get; set; }
        public string SponsorAddress { get; set; }
        public string SponsorPostCode { get; set; }
    }
}
