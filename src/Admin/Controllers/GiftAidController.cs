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
    public class GiftAidController : Controller
    {
        private readonly ApplicationDbContext _context;
        public GiftAidController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var gifts = new List<TransactionsListViewModel>();

            gifts = (from t in _context.Transaction
                     join c in _context.Category on t.CategoryId equals c.Id
                     where t.SponsorFirstName != null && t.SponsorFirstName != ""
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
                         SponsorFirstName = t.SponsorFirstName,
                         SponsorLastName = t.SponsorLastName,
                         SponsorAddress = t.SponsorAddress,
                         SponsorPostCode = t.SponsorPostCode,
                         TimeStamp = t.TimeStamp
                     }).ToList();

            if (gifts.Any())
            {
                gifts.Select(t => { t.Type = Enum.GetName(typeof(CategoryType), t.TypeId).ToString(); return t; }).ToList();
            }

            return View(gifts);
        }
    }
}