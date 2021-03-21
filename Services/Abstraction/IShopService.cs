using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Abstraction
{
    public interface IShopService
    {
        List<Category> GetCategoriesByShop(int shopId);
        List<Product_ProductListPage> GetProducts(int shopId, int pageNo);
    }
}
