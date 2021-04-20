using Entities;
using Repositories;
using Services.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Entities.Models;

namespace Services.Implementation
{
    public class ShopService : IShopService
    {
        private readonly ICategoryRepo _categoryRepo;
        private readonly ISubCategoryRepo _subCategoryRepo;
        private readonly IShopProductRepo _shopProductRepo;
        private readonly IProductRepo _productRepo;
        private const int defaultGridSize = 20;
        private const int miniGridSize = 5;
        public ShopService()
        {
            _categoryRepo = new CategoryRepo();
            _subCategoryRepo = new SubCategoryRepo();
            _shopProductRepo = new ShopProductRepo();
            _productRepo = new ProductRepo();
        }

        public List<Category> GetCategoriesByShop(int shopId) {
            List<Category> categories = _categoryRepo.AsQueryable().Where(x => x.ShopId == shopId).ToList();
            foreach (var category in categories)
            {
                if (category.Subcategories.Count() > 0)
                    continue;
                IEnumerable<Subcategory> subCategories = _subCategoryRepo.AsQueryable().Where(x => x.CategoryId == category.CategoryId).ToList();
                foreach(Subcategory subCategory in subCategories)
                {
                    category.Subcategories.Add(subCategory);
                }
            }
            return categories;
        }

        public List<ProductGridProducts> GetProductsBySubCategories(int shopId, int SubCategoryId)
        {
            List<ProductGridProducts> result = new List<ProductGridProducts>();
            IQueryable<Shopproduct> shopProducts = _shopProductRepo.AsQueryable().Where(sp => sp.ShopId == shopId && sp.SubCategoryId == SubCategoryId)
                .OrderByDescending(sp => sp.ProductPrice).Take(miniGridSize);

            Random rand = new Random();
            foreach (Shopproduct product in shopProducts)
            {
                result.Add(new ProductGridProducts {
                    ProductId = (int)product.ProductId,
                    ProductName = "",
                    Price = (int)product.ProductPrice,
                    HasDiscount = rand.Next(1, miniGridSize) % 2 == 0,
                    DiscountPercentage = rand.Next(1, miniGridSize)
                });
            }

            return result;
        }
    }
}
