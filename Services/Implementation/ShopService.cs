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

        public Page_ProductListPage GetProducts(Page_ProductListPage PageDetails)
        {
            string searchString = "";
            if (!string.IsNullOrEmpty(PageDetails.SearchString))
                searchString = PageDetails.SearchString.ToLower();
            List<Product_ProductListPage> productsRequested = _shopProductsRepo.AsQueryable().
                Where(x => x.ShopId == PageDetails.ShopId 
                && x.Product.ProductName.ToLower().Contains(searchString)
                && x.ProductPrice >= PageDetails.PriceRange_LowerBound
                && x.ProductPrice <= PageDetails.PriceRange_UpperBound).
                OrderBy(x => x.Product.ProductName).
                Skip(CommonConstants.StandardPageSize * (PageDetails.PageNo - 1)).
                Take(CommonConstants.StandardPageSize).
                Select(x => new Product_ProductListPage {
                    Pk = (int)x.Pk,
                    ProductName = x.Product.ProductName,
                    ProductPrice = (float)x.ProductPrice
                }).ToList();
            foreach (Product_ProductListPage product in productsRequested)
                product.ImageUrl = _productsImgRepo.AsQueryable().FirstOrDefault(i => i.Pk == product.Pk).ProductImgLocation;
            
            PageDetails.Products = productsRequested;
            return PageDetails;
        }
    }
}
