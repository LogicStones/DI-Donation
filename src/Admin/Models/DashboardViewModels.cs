using System;

namespace Admin.Models
{
    public class TransactionsListViewModel
    {
        public string Id { get; set; }
        public DateTime TimeStamp { get; set; }
        public int TypeId { get; set; }
        public string Type { get; set; }
        public string Category { get; set; }
        public float Amount { get; set; }
        public float TransactionFees { get; set; }
        public bool isFeeInclusive { get; set; }
        public string ReferenceTransactionId { get; set; }
        public string SponsorFirstName { get; set; }
        public string SponsorLastName { get; set; }
        public string SponsorAddress { get; set; }
        public string SponsorPostCode { get; set; }
    }
}
