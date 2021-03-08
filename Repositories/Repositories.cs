using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories
{
    public interface ICategoryRepo : IRepositoryBase <Category> { }
    public class CategoryRepo : RepositoryBase <Category>, ICategoryRepo { public CategoryRepo() : base() { } }
    public interface ICommonCodeRepo : IRepositoryBase <CommonCode> { }
    public class CommonCodeRepo : RepositoryBase <CommonCode>, ICommonCodeRepo { public CommonCodeRepo() : base() { } }
    public interface IInventoryRepo : IRepositoryBase <Inventory> { }
    public class InventoryRepo : RepositoryBase <Inventory>, IInventoryRepo { public InventoryRepo() : base() { } }
    public interface IInventoryLogRepo : IRepositoryBase <InventoryLog> { }
    public class InventoryLogRepo : RepositoryBase <InventoryLog>, IInventoryLogRepo { public InventoryLogRepo() : base() { } }
    public interface IOrderRepo : IRepositoryBase <Order> { }
    public class OrderRepo : RepositoryBase <Order>, IOrderRepo { public OrderRepo() : base() { } }
    public interface IProductRepo : IRepositoryBase <Product> { }
    public class ProductRepo : RepositoryBase <Product>, IProductRepo { public ProductRepo() : base() { } }
    public interface IProductImgRepo : IRepositoryBase <ProductImg> { }
    public class ProductImgRepo : RepositoryBase <ProductImg>, IProductImgRepo { public ProductImgRepo() : base() { } }
    public interface IProductReturnRepo : IRepositoryBase <ProductReturn> { }
    public class ProductReturnRepo : RepositoryBase <ProductReturn>, IProductReturnRepo { public ProductReturnRepo() : base() { } }
    public interface IProductsInOrderRepo : IRepositoryBase <ProductsInOrder> { }
    public class ProductsInOrderRepo : RepositoryBase <ProductsInOrder>, IProductsInOrderRepo { public ProductsInOrderRepo() : base() { } }
    public interface IShopRepo : IRepositoryBase <Shop> { }
    public class ShopRepo : RepositoryBase <Shop>, IShopRepo { public ShopRepo() : base() { } }
    public interface IShopProductRepo : IRepositoryBase <ShopProduct> { }
    public class ShopProductRepo : RepositoryBase <ShopProduct>, IShopProductRepo { public ShopProductRepo() : base() { } }
    public interface ISubCategoryRepo : IRepositoryBase <SubCategory> { }
    public class SubCategoryRepo : RepositoryBase <SubCategory>, ISubCategoryRepo { public SubCategoryRepo() : base() { } }
    public interface IUserRepo : IRepositoryBase <User> { }
    public class UserRepo : RepositoryBase <User>, IUserRepo { public UserRepo() : base() { } }
    public interface IVendorRepo : IRepositoryBase <Vendor> { }
    public class VendorRepo : RepositoryBase <Vendor>, IVendorRepo { public VendorRepo() : base() { } }
}
