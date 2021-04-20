using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Entities.Models;

namespace Services.Abstraction
{
    public interface IShopService
    {
        List<Category> GetCategoriesByShop(int shopId);
        List<ProductGridProducts> GetProductsBySubCategories(int shopId, int SubCategoryId);
    }
}
