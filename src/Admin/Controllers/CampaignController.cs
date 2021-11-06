using Admin.Models;
using DataAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CampaignController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CampaignController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var campaign = new List<CampaignViewModel>();
            var dbcampaign = _context.Campaigns.OrderByDescending(x => x.Id).ToList();
            foreach(var data in dbcampaign)
            {
                campaign.Add(new CampaignViewModel
                {
                    Id = data.Id,
                    Name = data.Name,
                    Amount = data.Amount,
                    Fees = data.Fees,
                    TransactionId = data.TransactionId,
                    CreatedAt = data.CreatedAt
                });
            }
            return View(campaign);
        }
    }
}
