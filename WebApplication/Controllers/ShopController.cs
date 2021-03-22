using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Services.Abstraction;
using Services.Implementation;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authorization;
using Entities.Models;

namespace WebApplication.Controllers
{
    [Route("api/Shop")]
    [ApiController]
    public class ShopController : Controller
    {
        private readonly IShopService shopService;
        public ShopController()
        {
            shopService = new ShopService();
        }
        [Route("ProductCategories/{shopId}")]
        [AllowAnonymous]
        public IActionResult GetCategories(int shopId) => new JsonResult(shopService.GetCategoriesByShop(shopId));
        [Route("GetProducts")]
        [AllowAnonymous]
        public IActionResult GetProducts(int shopId, int pageNo, int minPrice, int maxPrice, string? searchString)
        {
            return new JsonResult(shopService.GetProducts(new Page_ProductListPage {
                PageNo = pageNo,
                ShopId = shopId,
                PriceRange_LowerBound = minPrice,
                PriceRange_UpperBound = maxPrice,
                SearchString = searchString
            }));
        }
    }
}
