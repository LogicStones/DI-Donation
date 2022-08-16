using API.Helpers;
using API.Models;
using DataAccess;
using DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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


        [Route("get-access-token")]
        [HttpGet]
        public async Task<IActionResult> GetAccessToken(string code, string state)
        {
            var options = new RestClientOptions("https://api.sumup.com/token")
            {
                ThrowOnAnyError = true,
                Timeout = -1
            };
            var client = new RestClient(options);

            var request = new RestRequest();
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("grant_type", "authorization_code");
            request.AddParameter("client_id", "cc_classic_27NmlG0lIDlSou2LYaBqL5P6aoBSo");
            request.AddParameter("client_secret", "cc_sk_classic_WP5E2G4rALkwxyBRaFXJut18P3YQh0780aSYY29k7IgDuYuUsd");
            request.AddParameter("code", code);
            request.AddParameter("state", state);
            try
            {
                _response.data = (await client.ExecutePostAsync<SumUpAccessToken>(request)).Data;
                _response.error = false;
                _response.message = ResponseMessageKeys.success;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.data = ex;
                _response.error = true;
                _response.message = ResponseMessageKeys.serverError;
                return Ok(_response);
            }
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

        [Route("get-bank-accounts")]
        [HttpGet]
        public IActionResult GetBankAccounts()
        {
            _response.data = _context.BankAccounts.Where(x => x.IsActive == true).OrderByDescending(x => x.Id).ToList();
            _response.error = false;
            _response.message = ResponseMessageKeys.success;
            return Ok(_response);
        }

        [Route("verify-passcode")]
        [HttpPost]
        public IActionResult VerifyPassCode([FromForm] string AuthString)
        {
            _response.data = new Dictionary<string, string> {
                { "isVerified", AuthString.Equals(_context.PassCodes.OrderByDescending(pc => pc.LastUpdate).FirstOrDefault().AuthString) ? "true" : "false" }
            };
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
                                   Type = c.TypeId == 1 ? "Wajiba" : "Nafila",
                                   sc = _context.SubCategories.Where(sc => sc.IsActive == true && sc.CategoryId == c.Id).OrderBy(sc => sc.Name).ToList()
                               }).ToList();

            _response.data = subcategory;
            _response.error = false;
            _response.message = ResponseMessageKeys.success;
            return Ok(_response);
        }
    }

    public class SumUpAccessToken
    {
        public dynamic access_token { get; set; }
        public dynamic token_type { get; set; }
        public dynamic expires_in { get; set; }
        public dynamic refresh_token { get; set; }
    }
}