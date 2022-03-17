using Microsoft.AspNetCore.Authorization;
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
        private ICategoryService _categoryService;

        public IndexModel(IProductService productService, IProductPictureService productPicture, ICategoryService categoryService)
        {
            _productService = productService;
            _productPicture = productPicture;
            _categoryService = categoryService;
        }

        public PagedResponseModel<ProductDto> ListItem { get; set; }
        public IEnumerable<CategoryDto> ListCategory { get; set; }

        [BindProperty]
        public string pId { get; set; }

        public void OnGet()
        {
            ListItem = _productService.PagedQueryAsync(x => x.Name != null, 1, 16, "ProductPictures,Category").Result;
            ListCategory = _categoryService.GetAllAsync().Result;
        }

        [Authorize]
        public void OnPost(string pId)
        {
        }
    }
}
