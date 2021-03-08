using Entities;
using Repositories;
using Services.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Services.Implementation
{
    public class ShopService : IShopService
    {
        ICategoryRepo _categoryRepo;
        public ShopService()
        {
            _categoryRepo = new CategoryRepo();
        }
        public List<Category> GetCategoriesByShop(int shopId) {
            var data = _categoryRepo.AsQueryable().Where(x => x.ShopId == shopId).ToList();
            return _categoryRepo.AsQueryable().Where(x => x.ShopId == shopId).ToList();
        }
    }
}
