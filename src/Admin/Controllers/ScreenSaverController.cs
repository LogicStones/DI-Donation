using Admin.Models;
using DataAccess;
using DataAccess.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ScreenSaverController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;
        public ScreenSaverController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            webHostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
            var screens = _context.Screens.Where(x => x.IsActive == true).OrderBy(x => x.Id).ToList();
            var lstscreens = new List<ScreenSaverViewModel>();
            foreach(var data in screens)
            {
                lstscreens.Add(new ScreenSaverViewModel
                {
                    Id = data.Id,
                    ScreenName = data.ScreenPath,
                    AddedAt = data.AddedAt
                });
            }
            return View(lstscreens);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ScreenSaverViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.ScreenFile.Length > 0)
                {
                    //string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "/Uploads/Screens/");

                    string uploadsFolder = webHostEnvironment.WebRootPath + "\\Uploads\\Screens\\";

                    string imagePath = "/Uploads/Screens/" +
                        FilesManagerService.UploadFile(model.ScreenFile, uploadsFolder,model.ScreenFile.FileName);

                }
                var screens = new Screens
                {
                    ScreenPath = "/Uploads/Screens/" + model.ScreenFile.FileName,
                    IsActive = true,
                    AddedAt = DateTime.UtcNow,
                };
                _context.Screens.Add(screens);
                await _context.SaveChangesAsync();
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Failed to add Screen Saver.");
                return View(model);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int Id)
        {
            var screens = _context.Screens.Where(c => c.Id == Id).FirstOrDefault();
            screens.IsActive = false;
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
