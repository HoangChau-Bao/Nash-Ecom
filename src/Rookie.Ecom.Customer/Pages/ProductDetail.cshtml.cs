using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.DependencyInjection;
using Rookie.Ecom.Business.Interfaces;
using Rookie.Ecom.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Rookie.Ecom.Customer.Pages
{
    public class ProductDetailModel : PageModel
    {
        private IProductService _productService;
        private IProductGroupService _productGroupService;
        private IProductRatingService _productRatingService;
        public ProductDetailModel(IProductService productService, IProductGroupService productGroupService, IProductRatingService productRatingService)
        {
            _productService = productService;
            _productGroupService = productGroupService;
            _productRatingService = productRatingService;
        }

        public ProductDto product { get; set; }
        public ProductGroupDto productGroup { get; set; }

        public IEnumerable<ProductRatingDto> productRating { get; set; }

        [BindProperty]
        public string productid { get; set; }

        [BindProperty]
        public string comment { get; set; }

        [BindProperty]
        public string rating { get; set; }

        public void OnGet(Guid productid)
        {

            product = _productService.GetByAsync(x => x.Id == productid, "ProductPictures,Category,Brand,ProductGroup").Result;
            productGroup = _productGroupService.GetByAsync(x => x.Id == product.ProductGroupId, "Products").Result;
            productRating = _productRatingService.GetAllByAsync(x => x.ProductID == product.Id, "").Result;
        }

        public async Task<RedirectResult> OnPostAsync()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                ProductDto product = new ProductDto();
                product = _productService.GetByIdAsync(Guid.Parse(productid)).Result;
                //var user = User.Claims.ToList();
                var id = User.Claims.ToList()[2].Value;
                ProductRatingDto rate = new ProductRatingDto();
                rate.Id = Guid.NewGuid();
                rate.Comment = comment;
                rate.CreatedDate = DateTime.Now;
                rate.UpdatedDate = DateTime.Now;
                rate.UserID = Guid.Parse(id);
                rate.ProductID = Guid.Parse(productid);
                rate.Pubished = true;
                rate.Rating = int.Parse(rating);
                await _productRatingService.AddAsync(rate);
                return Redirect("/ProductDetail?productid=" + productid);

            }
            else
            {
                return Redirect("/login");
            }
        }
    }
}
