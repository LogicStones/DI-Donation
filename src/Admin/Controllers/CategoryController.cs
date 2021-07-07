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
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var categories = (from c in _context.Category
                              where c.isActive == true
                              orderby c.Name ascending
                              select new CategoryListViewModel
                              {
                                  Name = c.Name,
                                  CategoryId = c.Id,
                                  isActive = c.isActive,
                                  TypeId = c.TypeId
                              }).ToList();

            //categories.Select(c => { c.Status = c.isActive ? "Enabled" : "Disabled"; return c; }).ToList();
            categories.Select(c => { c.Type = Enum.GetName(typeof(CategoryType), c.TypeId).ToString(); return c; }).ToList();

            return View(categories);
        }

        [HttpGet]
        public IActionResult Create(int Id)
        {
            if (Id > 0)
            {
                var category = _context.Category.Where(c => c.Id == Id).FirstOrDefault();

                return View(new CategoryViewModel
                {
                    Id = category.Id,
                    Name = category.Name,
                    TypeId = category.TypeId,
                    lstCategoryTypes = GetCategoriesList()
                });
            }
            else
                return View(new CategoryViewModel
                {
                    TypeId = 1,
                    lstCategoryTypes = GetCategoriesList()
                });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Id == 0)
                {
                    _context.Category.Add(new Categories
                    {
                        Name = model.Name,
                        isActive = true,
                        TypeId = model.TypeId
                    });
                }
                else
                {
                    var category = _context.Category.Where(c => c.Id == model.Id).FirstOrDefault();
                    category.Name = model.Name;
                    category.TypeId = model.TypeId;
                }
                _context.SaveChanges();
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Failed to add category.");
                
                model.TypeId = 1;
                model.lstCategoryTypes = GetCategoriesList();

                return View(model);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            var category = _context.Category.Where(c => c.Id == Id).FirstOrDefault();
            category.isActive = false;
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        #region Helper Functions

        private static List<CategoryTypeViewModel> GetCategoriesList()
        {
            return new List<CategoryTypeViewModel>
            {
                new CategoryTypeViewModel
                {
                    Id = (int)CategoryType.Wajiba,
                    Name = Enum.GetName(typeof(CategoryType), (int)CategoryType.Wajiba).ToString()
                },
                new CategoryTypeViewModel
                {
                    Id = (int)CategoryType.Nafila,
                    Name = Enum.GetName(typeof(CategoryType), (int)CategoryType.Nafila).ToString()
                }
            };
        }
    
        #endregion
    }
}