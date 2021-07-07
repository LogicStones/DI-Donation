using System;

namespace Admin.Models
{
    public class DashboardViewModel
    {
        public float TotalWajiba { get; set; }
        public float TotalNafila { get; set; }
        public float TotalGiftAids { get; set; }

        public float TodayWajiba { get; set; }
        public float TodayNafila { get; set; }

        public float MonthlyWajiba { get; set; }
        public float MonthlyNafila { get; set; }

        public float AnnualWajiba { get; set; }
        public float AnnualNafila { get; set; }
     
        public string GiftAidAnnualData { get; set; }
    }
}
