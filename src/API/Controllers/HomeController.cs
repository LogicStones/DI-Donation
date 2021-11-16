using API.Helpers;
using API.Models;
using DataAccess;
using DataAccess.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly ApplicationDbContext _context; 
        private readonly ResponseEntity _response;
        private Dictionary<string, dynamic> dic;
        public HomeController(
            ApplicationDbContext context,
            ResponseEntity response
            )
        {
            _response = response;
            _context = context;
            dic = new Dictionary<string, dynamic>();
        }

        [Route("pay-donation")]
        [HttpPost]
        public IActionResult PayDonation([FromForm] PayDonationModel model)
        {
            if (!ModelState.IsValid)
            {
                _response.error = true;
                _response.message = ResponseMessageKeys.invalidParameters;
                return Ok(_response);
            }

            _context.Transaction.Add(new Transactions
            {
                Id = Guid.NewGuid().ToString(),
                Amount = model.Amount,
                CategoryId = model.CategoryId,
                TransactionFees = model.TransactionFees,
                isFeeInclusive = model.isFeeInclusive,
                ReferenceTransactionId = model.ReferenceTransactionId,
                TimeStamp = DateTime.Now,
                SponsorFirstName = model.SponsorFirstName,
                SponsorLastName = model.SponsorLastName,
                SponsorPostCode = model.SponsorPostCode,
                SponsorAddress = model.SponsorAddress
            });

            _context.SaveChanges();
            _response.error = false;
            _response.message = ResponseMessageKeys.success;
            return Ok(_response);
        }

        [Route("pay-campaign")]
        [HttpPost]
        public IActionResult PayCampaign([FromForm] PayCampaignModel model)
        {
            if (!ModelState.IsValid)
            {
                _response.error = true;
                _response.message = ResponseMessageKeys.invalidParameters;
                return Ok(_response);
            }

            _context.Campaigns.Add(new Campaign
            {
                Name = model.Name,
                Amount = float.Parse(model.Amount),
                Fees = float.Parse(model.Fees),
                TransactionId = model.TransactionId,
                CreatedAt = DateTime.UtcNow
            });

            _context.SaveChanges();
            _response.error = false;
            _response.message = ResponseMessageKeys.success;
            return Ok(_response);
        }

        [Route("get-screensaver")]
        [HttpGet]
        public IActionResult GetScreenSaver()
        {
            _response.data = _context.Screens.Where(x => x.IsActive == true).OrderByDescending(x => x.Id).ToList();
            _response.error = false;
            _response.message = ResponseMessageKeys.success;
            return Ok(_response);
        }


        [Route("get-categories")]
        [HttpGet]
        public IActionResult GetFormResponses(string type)
        {
            if (string.IsNullOrEmpty(type))
            {
                _response.error = true;
                _response.message = ResponseMessageKeys.invalidParameters;
                return Ok(_response);
            }

            var lstFilter = new List<int> { (int)CategoryType.Nafila };

            if (type.ToLower().Equals("all"))
                lstFilter.Add((int)CategoryType.Wajiba);

            var subcategory = (from c in _context.Category
                               where c.isActive == true && lstFilter.Contains(c.TypeId)
                               orderby c.Name ascending
                               select new
                               {
                                   c.Id,
                                   c.Name,
                                   sc = _context.SubCategories.Where(sc => sc.IsActive == true && sc.CategoryId == c.Id).OrderBy(sc => sc.Name).ToList()
                               }).ToList();

            _response.data = subcategory;
            _response.error = false;
            _response.message = ResponseMessageKeys.success;
            return Ok(_response);
        }
    }
}