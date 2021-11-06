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
                CategoryViewModel model = new CategoryViewModel();
                var category = _context.Category.Where(c => c.Id == Id).FirstOrDefault();
                model.Id = category.Id;
                model.Name = category.Name;
                model.TypeId = category.TypeId;
                model.lstCategoryTypes = GetCategoriesTypeList();
                model.HasSubCategory = category.HasSubCategory;
                if (category.HasSubCategory == true)
                {
                    var subcategory = _context.SubCategories.Where(x => x.CategoryId == Id && x.IsActive == true).Select(x => new { x.Id, x.Name, x.QuotedPrice, x.IsActive }).ToList();
                    for (int i = 0; i < subcategory.Count; i++)
                    {
                        model.SubCategoryId.Add(subcategory[i].Id);
                        model.SubCategoryName.Add(subcategory[i].Name);
                        model.QuotedPrice.Add(subcategory[i].QuotedPrice);
                    }
                }
                return View(model);
            }
            else
                return View(new CategoryViewModel
                {
                    TypeId = 1,
                    lstCategoryTypes = GetCategoriesTypeList()
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
                    var category = new Categories
                    {
                        Name = model.Name,
                        isActive = true,
                        TypeId = model.TypeId,
                        HasSubCategory=model.HasSubCategory
                    };
                    _context.Category.Add(category);
                    _context.SaveChanges();
                    if (model.HasSubCategory == true)
                    {
                        for(int i = 0; i < model.SubCategoryName.Count; i++)
                        {
                            var subCategory = new SubCategories
                            {
                                Name = model.SubCategoryName[i],
                                QuotedPrice = model.QuotedPrice[i],
                                CategoryId = category.Id,
                                IsActive = true,
                            };
                            _context.SubCategories.Add(subCategory);
                        }
                    }
                }
                else
                {
                    var category = _context.Category.Where(c => c.Id == model.Id).FirstOrDefault();
                    category.Name = model.Name;
                    category.TypeId = model.TypeId;
                    category.HasSubCategory = model.HasSubCategory;
                    if(model.HasSubCategory == true)
                    {
                        var dbsubcategory = _context.SubCategories.Where(x => x.CategoryId == model.Id && x.IsActive == true).ToList();
                        if (dbsubcategory.Count > 0)
                        {
                            for (int i = 0; i < model.SubCategoryName.Count; i++)
                            {
                                if (i < dbsubcategory.Count)
                                {
                                    if (dbsubcategory[i].Id == model.SubCategoryId[i])
                                    {
                                        dbsubcategory[i].Name = model.SubCategoryName[i];
                                        dbsubcategory[i].QuotedPrice = model.QuotedPrice[i];
                                        dbsubcategory[i].IsActive = true;
                                    }
                                }
                                else
                                {
                                    var newsubCategory = new SubCategories
                                    {
                                        IsActive = true,
                                        Name = model.SubCategoryName[i],
                                        QuotedPrice = model.QuotedPrice[i],
                                        CategoryId = model.Id
                                    };
                                    _context.SubCategories.Add(newsubCategory);
                                }
                            }
                        }
                        else
                        {
                            for (int i = 0; i < model.SubCategoryName.Count; i++)
                            {
                                var subCategory = new SubCategories
                                {
                                    Name = model.SubCategoryName[i],
                                    QuotedPrice = model.QuotedPrice[i],
                                    CategoryId = category.Id,
                                    IsActive = true,
                                };
                                _context.SubCategories.Add(subCategory);
                            }
                        }
                        
                    }
                }
                _context.SaveChanges();
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Failed to add category.");
                
                model.TypeId = 1;
                model.lstCategoryTypes = GetCategoriesTypeList();

                return View(model);
            }

            return RedirectToAction("Index");
        }

        public IActionResult SubCategory()
        {
            var categories = (from c in _context.Category
                              join sc in _context.SubCategories on c.Id equals sc.CategoryId
                              where c.isActive == true
                              orderby c.Name ascending
                              select new CategoryListViewModel
                              {
                                  Name = c.Name,
                                  SubCategoryName = sc.Name,
                                  SubCategoryId = sc.Id,
                                  CategoryId = c.Id,
                                  isActive = c.isActive,
                                  TypeId = c.TypeId
                              }).ToList();

            categories.Select(c => { c.Type = Enum.GetName(typeof(CategoryType), c.TypeId).ToString(); return c; }).ToList();

            return View(categories);
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            var category = _context.Category.Where(c => c.Id == Id).FirstOrDefault();
            var subcategory = _context.SubCategories.Where(c => c.CategoryId == Id).ToList();
            foreach(var data in subcategory)
            {
                data.IsActive = false;
            }
            category.isActive = false;
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult DeleteSubCategory(int Id)
        {
            var subcategory = _context.SubCategories.Where(x => x.Id == Id).FirstOrDefault();
            subcategory.IsActive = false;
            _context.SaveChanges();

            return RedirectToAction("SubCategory");
        }

        #region Helper Functions

        private static List<CategoryTypeViewModel> GetCategoriesTypeList()
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