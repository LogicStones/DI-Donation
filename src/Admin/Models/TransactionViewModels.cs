using System;

namespace Admin.Models
{
    public class DashboardViewModel
    {
        public float TotalWajiba { get; set; }
        public float TotalNafila { get; set; }
        public float TotalGiftAids { get; set; }

        public string TodayWajiba { get; set; }
        public string TodayNafila { get; set; }
               
        public string MonthlyWajiba { get; set; }
        public string MonthlyNafila { get; set; }
               
        public string AnnualWajiba { get; set; }
        public string AnnualNafila { get; set; }
     
        public string GiftAidAnnualData { get; set; }
    }
}
