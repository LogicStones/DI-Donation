using Admin.Models;
using DataAccess;
using DataAccess.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class BankAccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BankAccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var lstBankAccounts = (from c in _context.BankAccounts
                                   where c.IsActive == true
                                   orderby c.AccountName ascending
                                   select new BankAccountViewModel
                                   {
                                       Id = c.Id,
                                       AccountName = c.AccountName,
                                       SumUpMerchantId = c.SumUpMerchantId
                                   }).ToList();
            return View(lstBankAccounts);
        }

        [HttpGet]
        public IActionResult Create(int Id)
        {
            if (Id > 0)
            {
                BankAccountViewModel model = new BankAccountViewModel();
                var bankAccount = _context.BankAccounts.Where(c => c.Id == Id).FirstOrDefault();
                model.Id = bankAccount.Id;
                model.AccountName = bankAccount.AccountName;
                model.SumUpMerchantId = bankAccount.SumUpMerchantId;
                return View(model);
            }
            else
                return View(new BankAccountViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(BankAccountViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Id == 0)
                {
                    var bankAccount = new BankAccount
                    {
                        AccountName = model.AccountName,
                        IsActive = true,
                        LastUpdate = DateTime.UtcNow,
                        SumUpMerchantId = model.SumUpMerchantId
                    };
                    _context.BankAccounts.Add(bankAccount);
                    _context.SaveChanges();
                }
                else
                {
                    var bankAccount = _context.BankAccounts.Where(c => c.Id == model.Id).FirstOrDefault();
                    bankAccount.AccountName = model.AccountName;
                    bankAccount.SumUpMerchantId = model.SumUpMerchantId;
                    bankAccount.LastUpdate = DateTime.UtcNow;
                }
                _context.SaveChanges();
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Failed to add bank account.");
                return View(model);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            var account = _context.BankAccounts.Where(c => c.Id == Id).FirstOrDefault();
            account.IsActive = false;
            account.LastUpdate = DateTime.UtcNow;
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}