using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories
{
    public interface ICategoryRepo : IRepositoryBase <Category> { }
    public class CategoryRepo : RepositoryBase <Category>, ICategoryRepo { public CategoryRepo() : base() { } }
    public interface ICommonCodeRepo : IRepositoryBase <Commoncode> { }
    public class CommonCodeRepo : RepositoryBase <Commoncode>, ICommonCodeRepo { public CommonCodeRepo() : base() { } }
    public interface IInventoryRepo : IRepositoryBase <Inventory> { }
    public class InventoryRepo : RepositoryBase <Inventory>, IInventoryRepo { public InventoryRepo() : base() { } }
    public interface IInventoryLogRepo : IRepositoryBase <Inventorylog> { }
    public class InventoryLogRepo : RepositoryBase <Inventorylog>, IInventoryLogRepo { public InventoryLogRepo() : base() { } }
    public interface IOrderRepo : IRepositoryBase <Order> { }
    public class OrderRepo : RepositoryBase <Order>, IOrderRepo { public OrderRepo() : base() { } }
    public interface IProductRepo : IRepositoryBase <Product> { }
    public class ProductRepo : RepositoryBase <Product>, IProductRepo { public ProductRepo() : base() { } }
    public interface IProductImgRepo : IRepositoryBase <Productimg> { }
    public class ProductImgRepo : RepositoryBase <Productimg>, IProductImgRepo { public ProductImgRepo() : base() { } }
    public interface IProductReturnRepo : IRepositoryBase <Productreturn> { }
    public class ProductReturnRepo : RepositoryBase <Productreturn>, IProductReturnRepo { public ProductReturnRepo() : base() { } }
    public interface IProductsInOrderRepo : IRepositoryBase <Productsinorder> { }
    public class ProductsInOrderRepo : RepositoryBase <Productsinorder>, IProductsInOrderRepo { public ProductsInOrderRepo() : base() { } }
    public interface IShopRepo : IRepositoryBase <Shop> { }
    public class ShopRepo : RepositoryBase <Shop>, IShopRepo { public ShopRepo() : base() { } }
    public interface IShopProductRepo : IRepositoryBase <Shopproduct> { }
    public class ShopProductRepo : RepositoryBase <Shopproduct>, IShopProductRepo { public ShopProductRepo() : base() { } }
    public interface ISubCategoryRepo : IRepositoryBase <Subcategory> { }
    public class SubCategoryRepo : RepositoryBase <Subcategory>, ISubCategoryRepo { public SubCategoryRepo() : base() { } }
    public interface IUserRepo : IRepositoryBase <User> { }
    public class UserRepo : RepositoryBase <User>, IUserRepo { public UserRepo() : base() { } }
    public interface IVendorRepo : IRepositoryBase <Vendor> { }
    public class VendorRepo : RepositoryBase <Vendor>, IVendorRepo { public VendorRepo() : base() { } }
}
