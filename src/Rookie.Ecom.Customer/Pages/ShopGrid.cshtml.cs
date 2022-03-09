using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Rookie.Ecom.Business.Interfaces;
using Rookie.Ecom.Contracts;
using Rookie.Ecom.Contracts.Dtos;
using System.Collections;
using System.Collections.Generic;

namespace Rookie.Ecom.Customer.Pages
{
    public class ShopGridModel : PageModel
    {
        private IProductService _productService;

        public ShopGridModel(IProductService productService)
        {
            _productService = productService;
        }

        public PagedResponseModel<ProductDto> listProduct { get; set; }
        public void OnGet(string search)
        {
            listProduct = _productService.PagedQueryAsync(x => x.Name != null, 1, 10, "ProductPictures").Result;
        }
    }
}
