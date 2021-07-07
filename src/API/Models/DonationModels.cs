using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class PayDonationModel
    {
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public float Amount { get; set; }
        [Required]
        public float TransactionFees { get; set; }
        [Required]
        public bool isFeeInclusive { get; set; }
        [Required]
        public string ReferenceTransactionId { get; set; }
        public string SponsorFirstName { get; set; }
        public string SponsorLastName { get; set; }
        public string SponsorAddress { get; set; }
        public string SponsorPostCode { get; set; }
    }
}
