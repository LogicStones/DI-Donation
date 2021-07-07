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
    public class HomeController : Controller
    {
        public SignInManager<ApplicationUser> _signInManager { get; }
        public UserManager<ApplicationUser> _userManager { get; }
        private readonly ApplicationDbContext _context;
        public HomeController(ILogger<HomeController> logger,
            SignInManager<ApplicationUser> signInManager,
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _context = context;
        }


        public IActionResult Index()
        {
            var lstTransactions = _context.Transaction.ToList();
            var lstCategory = _context.Category.ToList();

            var transactions = (from t in lstTransactions
                                join c in lstCategory on t.CategoryId equals c.Id
                                orderby t.TimeStamp descending
                                select new
                                {
                                    t.SponsorFirstName,
                                    t.TimeStamp,
                                    t.Amount,
                                    c.TypeId
                                }).ToList();

            var dayStart = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 0, 0, 0);
            var dayEnd = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 23, 59, 59);
            var monthStart = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1, 0, 0, 0);
            var monthEnd = new DateTime(DateTime.Today.Year, DateTime.Today.Month + 1, 1, 0, 0, 0).AddSeconds(-1);
            var yearStart = new DateTime(DateTime.Today.Year, 1, 1, 0, 0, 0);
            var yearEnd = new DateTime(DateTime.Today.Year, 12, 31, 23, 59, 59);

            int nafilaType = (int)CategoryType.Nafila;
            int wajibaType = (int)CategoryType.Wajiba;

            var rawGiftAidData = transactions.Where(t => t.SponsorFirstName != null && t.TimeStamp >= yearStart && t.TimeStamp <= yearEnd).Select(t => new { t.TimeStamp.Month, t.Amount }).GroupBy(x => new { x.Month }, (key, group) => new
            {
                Month = key.Month,
                Amount = group.Sum(k => k.Amount)
            }).ToList();

            SortedList<int, string> monthList = new SortedList<int, string> {
                        { 1,"January"}, { 2,"Feburary"}, { 3,"March"}, { 4,"April"}, { 5,"May"}, { 6,"June"},
                        { 7,"July"}, { 8,"August"}, { 9,"September"}, { 10,"October"}, { 11,"November"}, { 12,"December"}
                    };

            SortedList<int, string> lstGiftData = new SortedList<int, string>();

            foreach (var item in rawGiftAidData)
            {
                switch (item.Month)
                {
                    case 1:
                        lstGiftData.Add(1, ((decimal)item.Amount).ToString("0.##"));
                        break;
                    case 2:
                        lstGiftData.Add(2, ((decimal)item.Amount).ToString("0.##"));
                        break;
                    case 3:
                        lstGiftData.Add(3, ((decimal)item.Amount).ToString("0.##"));
                        break;
                    case 4:
                        lstGiftData.Add(4, ((decimal)item.Amount).ToString("0.##"));
                        break;
                    case 5:
                        lstGiftData.Add(5, ((decimal)item.Amount).ToString("0.##"));
                        break;
                    case 6:
                        lstGiftData.Add(6, ((decimal)item.Amount).ToString("0.##"));
                        break;
                    case 7:
                        lstGiftData.Add(7, ((decimal)item.Amount).ToString("0.##"));
                        break;
                    case 8:
                        lstGiftData.Add(8, ((decimal)item.Amount).ToString("0.##"));
                        break;
                    case 9:
                        lstGiftData.Add(9, ((decimal)item.Amount).ToString("0.##"));
                        break;
                    case 10:
                        lstGiftData.Add(10, ((decimal)item.Amount).ToString("0.##"));
                        break;
                    case 11:
                        lstGiftData.Add(11, ((decimal)item.Amount).ToString("0.##"));
                        break;
                    case 12:
                        lstGiftData.Add(12, ((decimal)item.Amount).ToString("0.##"));
                        break;
                    default:
                        break;
                }
            }

            for (int i = 1; i <= 12; i++)
            {
                if (lstGiftData.Keys.Contains(monthList.Keys[i - 1]))
                    continue;
                else
                {
                    lstGiftData.Add(i, "0.00");
                }
            }

            var model = new DashboardViewModel
            {
                TotalGiftAids = transactions.Where(t => t.SponsorFirstName != null).Sum(t => t.Amount),
                TotalWajiba = transactions.Where(t => t.TypeId == wajibaType).Sum(t => t.Amount),
                TotalNafila = transactions.Where(t => t.TypeId == nafilaType).Sum(t => t.Amount),

                TodayWajiba = transactions.Where(t => t.TypeId == wajibaType && t.TimeStamp >= dayStart && t.TimeStamp <= dayEnd).Sum(t => t.Amount),
                TodayNafila = transactions.Where(t => t.TypeId == nafilaType && t.TimeStamp >= dayStart && t.TimeStamp <= dayEnd).Sum(t => t.Amount),

                MonthlyWajiba = transactions.Where(t => t.TypeId == wajibaType && t.TimeStamp >= monthStart && t.TimeStamp <= monthEnd).Sum(t => t.Amount),
                MonthlyNafila = transactions.Where(t => t.TypeId == nafilaType && t.TimeStamp >= monthStart && t.TimeStamp <= monthEnd).Sum(t => t.Amount),

                AnnualWajiba = transactions.Where(t => t.TypeId == wajibaType && t.TimeStamp >= yearStart && t.TimeStamp <= yearEnd).Sum(t => t.Amount),
                AnnualNafila = transactions.Where(t => t.TypeId == nafilaType && t.TimeStamp >= yearStart && t.TimeStamp <= yearEnd).Sum(t => t.Amount),

                GiftAidAnnualData = string.Join(",", lstGiftData.Values.ToArray())
            };

            return View(model);
        }

        public ActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));

            if (user != null)
            {
                var result = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false);
                    return View("~/Views/Home/Index.cshtml");
                }
                else
                {
                    ModelState.AddModelError("PasswordMismatch", "Incorrect current password.");
                    return View("ChangePassword", model);
                }
            }
            return NotFound();
        }

        [AllowAnonymous]
        public async Task<IActionResult> Logout(LoginViewModel model)
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}