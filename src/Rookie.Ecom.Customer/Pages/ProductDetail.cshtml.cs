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
        private IProductGroupService _productGroupService;
        public ProductDetailModel(IProductService productService, IProductGroupService productGroupService)
        {
            _productService = productService;
            _productGroupService = productGroupService;
        }

        public ProductDto product { get; set; }
        public ProductGroupDto productGroup { get; set; }

        public void OnGet(Guid productid)
        {

            product = _productService.GetByAsync(x => x.Id == productid, "ProductPictures,Category,Brand,ProductGroup").Result;
            productGroup = _productGroupService.GetByAsync(x => x.Id == product.ProductGroupId, "Products").Result;
        }
    }
}
