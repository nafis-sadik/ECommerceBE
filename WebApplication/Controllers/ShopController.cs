using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Services.Abstraction;
using Services.Implementation;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace WebApplication.Controllers
{
    public class ShopController : Controller
    {
        IShopService shopService;
        public ShopController()
        {
            shopService = new ShopService();
        }
        [Route("api/Categories/{shopId}")]
        public IActionResult GetCategories(int shopId) => new JsonResult(shopService.GetCategoriesByShop(shopId));
        [Route("api/CategoryWiseProducts/{shopId}/{CategoryId}")]
        public IActionResult CategoryWiseProducts(int shopId, int CategoryId) => new JsonResult(shopService.GetCategoriesByShop(shopId));
        [Route("api/SubCategoryWiseProducts/{shopId}/{SubCategoryId}")]
        public IActionResult SubCategoryWiseProducts(int shopId, int SubCategoryId) => new JsonResult(shopService.GetCategoriesByShop(shopId));
    }
}
