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
        [Route("GetProducts/{shopId}/{pageNo}")]
        [AllowAnonymous]
        public IActionResult GetProducts(int shopId, int pageNo)
        {
            return new JsonResult(shopService.GetProducts(shopId, pageNo));
        }
    }
}
