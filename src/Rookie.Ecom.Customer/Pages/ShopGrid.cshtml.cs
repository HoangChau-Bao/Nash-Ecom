using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Rookie.Ecom.Business.Interfaces;
using Rookie.Ecom.Contracts;
using Rookie.Ecom.Contracts.Dtos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rookie.Ecom.Customer.Pages
{
    public class ShopGridModel : PageModel
    {
        private IProductService _productService;
        private ICategoryService _categoryService;

        public ShopGridModel(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        public PagedResponseModel<ProductDto> listProduct { get; set; }
        public IEnumerable<ProductDto> listPro { get; set; }
        public CategoryDto category1 { get; set; }

        public int page;

        public string search;
        public string category;
        public PagedResponseModel<ProductDto> ListProduct { get; set; }


        public async Task OnGet(string search, string category, int currentpage)
        {
            this.search = search;
            this.category = category;
            if (currentpage <= 0 || currentpage == null)
            {

                if (search == null && category == null)
                {
                    listProduct = _productService.PagedQueryAsync(x => x.Name != null, 1, 16, "ProductPictures").Result;
                }
                else if (category != null)
                {
                    category1 = _categoryService.GetByNameAsync(category).Result;
                    //Console.WriteLine(category);
                    listProduct = _productService.PagedQueryAsync(x => x.CategoryId == category1.Id, 1, 16, "ProductPictures").Result;

                }
                else if (search != null)
                {
                    listProduct = _productService.PagedQueryAsync(x => x.Name.Contains(search), 1, 16, "ProductPictures").Result;
                }
            }
            else
            {
                if (search == null && category == null)
                {
                    listProduct = _productService.PagedQueryAsync(x => x.Name != null, currentpage, 16, "ProductPictures").Result;
                }
                else if (category != null)
                {
                    category1 = _categoryService.GetByNameAsync(category).Result;
                    listProduct = _productService.PagedQueryAsync(x => x.CategoryId == category1.Id, currentpage, 16, "ProductPictures").Result;
                }
                else if (search != null)
                {
                    listProduct = _productService.PagedQueryAsync(x => x.Name.Contains(search), currentpage, 16, "ProductPictures").Result;
                }
            }


        }
    }
}
