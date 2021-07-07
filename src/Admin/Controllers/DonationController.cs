using Admin.Models;
using DataAccess;
using DataAccess.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DonationController : Controller
    {
        private readonly ApplicationDbContext _context;
        public DonationController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var donations = new List<TransactionsListViewModel>();

            donations = (from t in _context.Transaction
                     join c in _context.Category on t.CategoryId equals c.Id
                     where t.SponsorFirstName == null && t.SponsorFirstName != ""
                     orderby t.TimeStamp descending
                     select new TransactionsListViewModel
                     {
                         Id = t.Id,
                         Amount = t.Amount,
                         TypeId = c.TypeId,
                         Category = c.Name,
                         TransactionFees = t.TransactionFees,
                         isFeeInclusive = t.isFeeInclusive,
                         ReferenceTransactionId = t.ReferenceTransactionId,
                         TimeStamp = t.TimeStamp
                     }).ToList();

            if (donations.Any())
            {
                donations.Select(t => { t.Type = Enum.GetName(typeof(CategoryType), t.TypeId).ToString(); return t; }).ToList();
            }

            return View(donations);
        }
    }
}