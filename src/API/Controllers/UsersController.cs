using API.Helpers;
using API.Models;
using DataAccess;
using DataAccess.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Services;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class UsersController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ResponseEntity _response;
        private Dictionary<string, dynamic> dic;
        private readonly ApplicationDbContext _context;

        public UsersController(
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            ResponseEntity response
            )
        {
            _userManager = userManager;
            _response = response;
            _context = context;
            dic = new Dictionary<string, dynamic>();
        }

        [Route("list")]
        [HttpGet]
        public IActionResult GetList(string CompnyId)
        {
            if (string.IsNullOrEmpty(CompnyId))
            {
                _response.error = true;
                _response.message = ResponseMessageKeys.invalidParameters;
                return Ok(_response);
            }

            var company = _context.ApplicationUsers.Where(u => u.Id == CompnyId).FirstOrDefault();

            dic.Add("users", (from a in _context.ApplicationUsers
                              where a.CompanyId == CompnyId
                              select new
                              {
                                  a.AssignedFormId,
                                  a.Id,
                                  a.UserName,
                                  CompanyId = company.Id,
                                  company.CompanyLogo,
                                  company.CompanyName
                              }).ToList());

            _response.error = false;
            _response.data = dic;
            _response.message = ResponseMessageKeys.success;
            return Ok(_response);
        }

        [Route("get-assigned-form")]
        [HttpGet]
        public async Task<IActionResult> GetAssignedForm()
        {
            var user = await _userManager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));
            if (user == null)
            {
                _response.error = true;
                _response.message = ResponseMessageKeys.notFound;
                return Ok(_response);
            }

            var form = _context.Forms.Where(f => f.Id == user.AssignedFormId).FirstOrDefault();

            if (form == null)
            {
                _response.error = true;
                _response.message = ResponseMessageKeys.notAssigned;
                return Ok(_response);
            }

            dic.Add("form", new UserAssigendFormModel
            {
                Id = form.Id,
                Title = form.Title,
                Schema = form.Schema//.Replace(@"\", @"123")//.Replace("\n","").Replace("\r","").Replace(" ", "")
            });

            JsonConvert.DeserializeObject(form.Schema).ToString();

            _response.error = false;
            _response.data = dic;
            _response.message = ResponseMessageKeys.success;
            return Ok(_response);
        }

        [Route("get-history")]
        [HttpGet]
        public async Task<IActionResult> GetHistory()
        {
            var user = await _userManager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));
            if (user == null)
            {
                _response.error = true;
                _response.message = ResponseMessageKeys.notFound;
                return Ok(_response);
            }

            var lstUserforms = _context.UserForms.Where(uf => uf.UserId == user.Id).ToList();

            if (!lstUserforms.Any())
            {
                _response.error = false;
                _response.message = ResponseMessageKeys.notFound;
                return Ok(_response);
            }

            var lstForms = _context.Forms.Where(f => f.CreatedBy.Equals(user.CompanyId)).ToList();

            var lstFormsDetails = lstForms.Where(f => lstUserforms.Any(uf => uf.FormId == f.Id)).ToList();
            
            var response = new List<UserAssigendFormModel>();
            foreach (var form in lstFormsDetails)
            {
                response.Add(new UserAssigendFormModel
                {
                    Id = form.Id,
                    Title = form.Title,
                    Schema = form.Schema,
                    //TotalResponses = _context.FormResponses.Where(fr => fr.FormId == form.Id).Count()
                });
            }

            dic.Add("assignedForms", response);

            _response.error = false;
            _response.data = dic;
            _response.message = ResponseMessageKeys.success;
            return Ok(_response);
        }
    }
}