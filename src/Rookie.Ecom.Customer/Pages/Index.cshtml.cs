using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Rookie.Ecom.Business.Interfaces;
using Rookie.Ecom.Contracts;
using Rookie.Ecom.Contracts.Dtos;
using Rookie.Ecom.DataAccessor.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rookie.Ecom.Customer.Pages
{
    public class IndexModel : PageModel
    {

        private IProductService _productService;
        private IProductPictureService _productPicture;

        public IndexModel(IProductService productService, IProductPictureService productPicture)
        {
            _productService = productService;
            _productPicture = productPicture;
        }

        public PagedResponseModel<ProductDto> ListItem { get; set; }

        public void OnGet()
        {
            ListItem = _productService.PagedQueryAsync(x => x.Name != null, 1, 10, "ProductPictures").Result;
        }
    }
}
