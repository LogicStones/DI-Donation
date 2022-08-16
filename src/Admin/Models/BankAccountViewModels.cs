using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Admin.Models
{
    public class BankAccountListViewModel
    {
        public List<BankAccountViewModel> lstAccounts { get; set; }
    }

    public class BankAccountViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Account Name")]
        public string AccountName { get; set; }

        [Required]
        [Display(Name = "SumUp Merchant Id")]
        public string SumUpMerchantId { get; set; }
    }
}