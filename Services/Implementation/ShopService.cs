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
        private readonly IShopProductRepo _shopProductsRepo;
        private readonly IProductImgRepo _productsImgRepo;
        public ShopService()
        {
            _categoryRepo = new CategoryRepo();
            _shopProductsRepo = new ShopProductRepo();
            _subCategoryRepo = new SubCategoryRepo();
            _productsImgRepo = new ProductImgRepo();
        }
        public List<Category> GetCategoriesByShop(int shopId) {
            List<Category> categories = _categoryRepo.AsQueryable().Where(x => x.ShopId == shopId).ToList();
            foreach (Category category in categories)
                category.SubCategories = _subCategoryRepo.AsQueryable().Where(x => x.CategoryId == category.CategoryId).ToList();
            return categories;
        }

        public List<Product_ProductListPage> GetProducts(int shopId, int pageNo)
        {
            List<Product_ProductListPage> productsRequested = _shopProductsRepo.AsQueryable().Where(x => x.ShopId == shopId).
                OrderBy(x => x.Product.ProductName).
                Skip(CommonConstants.StandardPageSize * (pageNo-1)).
                Take(CommonConstants.StandardPageSize).
                Select(x => new Product_ProductListPage {
                    Pk = (int)x.Pk,
                    ProductName = x.Product.ProductName,
                    ProductPrice = (float)x.ProductPrice
                }).ToList();
            foreach (Product_ProductListPage product in productsRequested)
                product.ImageUrl = _productsImgRepo.AsQueryable().FirstOrDefault(i => i.Pk == product.Pk).ProductImgLocation;
            return productsRequested;
        }
    }
}
