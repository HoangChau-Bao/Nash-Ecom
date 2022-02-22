using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Rookie.Ecom.Contracts;
using Rookie.Ecom.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Rookie.Ecom.Business.Interfaces;


namespace Rookie.Ecom.Customer.Pages
{
    public class CategoryModel : PageModel
    {
        private readonly ICategoryService _categoryService;
        public CategoryModel(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IEnumerable<CategoryDto> Category => _categoryService.GetAllAsync().Result;

        public void OnGet()
        {
        }
    }
}
