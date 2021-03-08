using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Abstraction
{
    public interface IShopService
    {
        List<Category> GetCategoriesByShop(int shopId);
    }
}
