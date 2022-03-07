using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Rookie.Ecom.Business.Interfaces;
using Rookie.Ecom.Contracts.Dtos;
using System;

namespace Rookie.Ecom.Customer.Pages
{
    public class ProductDetailModel : PageModel
    {
        private IProductService _productService;
        public ProductDetailModel(IProductService productService)
        {
            _productService = productService;
        }

        public ProductDto product { get; set; }

        public string Name = "string";
        public void OnGet()
        {
            product = _productService.GetByNameAsync(Name).Result;
        }
    }
}
