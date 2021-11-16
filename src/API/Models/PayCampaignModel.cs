using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class PayCampaignModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Amount { get; set; }

        [Required]
        public string Fees { get; set; }

        [Required]
        public string TransactionId { get; set; }
    }
}
