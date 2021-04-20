-- phpMyAdmin SQL Dump
-- version 5.0.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Mar 22, 2021 at 01:11 PM
-- Server version: 10.4.17-MariaDB
-- PHP Version: 8.0.2

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `bluebirddb`
--

-- --------------------------------------------------------

--
-- Table structure for table `categories`
--

CREATE TABLE `categories` (
  `CategoryId` decimal(18,0) NOT NULL,
  `CategoryName` varchar(50) DEFAULT NULL,
  `CategoryNameBangla` varchar(50) DEFAULT NULL,
  `ShopID` decimal(18,0) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `categories`
--

INSERT INTO `categories` (`CategoryId`, `CategoryName`, `CategoryNameBangla`, `ShopID`) VALUES
('1', 'Mobile Accessories', 'মোবাইল আনুষঙ্গিক পণ্য সমগ্র', '1'),
('2', 'Computer Accessories', 'কম্পিউটার আনুষঙ্গিক পণ্য সমগ্র', '1');

-- --------------------------------------------------------

--
-- Table structure for table `commoncode`
--

CREATE TABLE `commoncode` (
  `CommonCodeId` decimal(18,0) NOT NULL,
  `TableName` varchar(50) DEFAULT NULL,
  `NameEnglish` varchar(50) DEFAULT NULL,
  `NameBangla` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `commoncode`
--

INSERT INTO `commoncode` (`CommonCodeId`, `TableName`, `NameEnglish`, `NameBangla`) VALUES
('1', 'UserType', 'Admin', 'অ্যাডমিন '),
('2', 'UserType', 'User', 'ব্যবহারকারী');

-- --------------------------------------------------------

--
-- Table structure for table `inventory`
--

CREATE TABLE `inventory` (
  `Quantity` decimal(18,0) DEFAULT NULL,
  `PK` decimal(18,0) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `inventorylog`
--

CREATE TABLE `inventorylog` (
  `InventoryLogId` decimal(18,0) NOT NULL,
  `PK` decimal(18,0) NOT NULL,
  `TransactionQuantity` decimal(18,0) NOT NULL,
  `TransactionDate` varchar(50) NOT NULL,
  `QuantityUpdateType` decimal(18,0) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `orders`
--

CREATE TABLE `orders` (
  `OrderId` decimal(18,0) NOT NULL,
  `OrderDate` datetime DEFAULT NULL,
  `DeliveryLocation` text DEFAULT NULL,
  `UserId` decimal(18,0) NOT NULL,
  `OrderDescription` text DEFAULT NULL,
  `PaymentOption` decimal(18,0) DEFAULT NULL,
  `TotalOrderValue` decimal(18,0) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `productimgs`
--

CREATE TABLE `productimgs` (
  `ProductImgLocation` varchar(50) DEFAULT NULL,
  `PK` decimal(18,0) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `productimgs`
--

INSERT INTO `productimgs` (`ProductImgLocation`, `PK`) VALUES
('C:\\Users\\User\\Pictures\\Md.Nafis Sadik 1.jpg', '1');

-- --------------------------------------------------------

--
-- Table structure for table `productreturn`
--

CREATE TABLE `productreturn` (
  `ProductReturnId` decimal(18,0) NOT NULL,
  `OrderId` decimal(18,0) NOT NULL,
  `ReturnRequestDate` datetime DEFAULT NULL,
  `PK` decimal(18,0) NOT NULL,
  `ReturnQuantity` decimal(18,0) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `products`
--

CREATE TABLE `products` (
  `ProductID` decimal(18,0) NOT NULL,
  `ProductName` varchar(50) DEFAULT NULL,
  `ProductAttribute` varchar(256) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `products`
--

INSERT INTO `products` (`ProductID`, `ProductName`, `ProductAttribute`) VALUES
('1', 'Luxury Foldable Mobile Holder Stand', 'স্টাইলিশ মানুষদের জন্য আমরা নিয়ে এসেছি স্মার্ট ও ই');

-- --------------------------------------------------------

--
-- Table structure for table `productsinorder`
--

CREATE TABLE `productsinorder` (
  `PK` decimal(18,0) NOT NULL,
  `OrderId` decimal(18,0) NOT NULL,
  `Quantity` decimal(18,0) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `shopproducts`
--

CREATE TABLE `shopproducts` (
  `PK` decimal(18,0) NOT NULL,
  `ProductId` decimal(18,0) NOT NULL,
  `SubCategoryId` decimal(18,0) NOT NULL,
  `ProductPrice` decimal(18,0) DEFAULT NULL,
  `ProductDescription` text DEFAULT NULL,
  `Stock` decimal(18,0) DEFAULT NULL,
  `ShopID` decimal(18,0) DEFAULT NULL,
  `VendorId` decimal(18,0) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `shopproducts`
--

INSERT INTO `shopproducts` (`PK`, `ProductId`, `SubCategoryId`, `ProductPrice`, `ProductDescription`, `Stock`, `ShopID`, `VendorId`) VALUES
('1', '1', '4', '680', 'Muah 😘', '500', '1', NULL);

-- --------------------------------------------------------

--
-- Table structure for table `shops`
--

CREATE TABLE `shops` (
  `ShopID` decimal(18,0) NOT NULL,
  `ShopName` varchar(50) DEFAULT NULL,
  `ShopLogoLocation` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `shops`
--

INSERT INTO `shops` (`ShopID`, `ShopName`, `ShopLogoLocation`) VALUES
('1', 'Gullu', NULL);

-- --------------------------------------------------------

--
-- Table structure for table `subcategories`
--

CREATE TABLE `subcategories` (
  `SubCategoryId` decimal(18,0) NOT NULL,
  `CategoryId` decimal(18,0) DEFAULT NULL,
  `SubCategoryName` varchar(50) DEFAULT NULL,
  `SubCategoryNameBangla` varchar(10) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `subcategories`
--

INSERT INTO `subcategories` (`SubCategoryId`, `CategoryId`, `SubCategoryName`, `SubCategoryNameBangla`) VALUES
('1', '2', 'Mouse', 'মাউস '),
('2', '2', 'Key Board', 'কীবোর্ড '),
('3', '1', 'Chargers', 'চার্জার'),
('4', '1', 'Back Covers', 'ব্যাক কভার');

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `UserId` decimal(18,0) NOT NULL,
  `UserName` varchar(50) DEFAULT NULL,
  `PhoneNumber` varchar(50) DEFAULT NULL,
  `UserTypeId` decimal(18,0) DEFAULT NULL,
  `ProfilePicLoc` text DEFAULT NULL,
  `Password` text DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`UserId`, `UserName`, `PhoneNumber`, `UserTypeId`, `ProfilePicLoc`, `Password`) VALUES
('0', 'dummy user', '+8801628301510', '1', 'Kichu kichu kotha buze nite hoi', 'She to mukhe bola jai na'),
('1', 'nafis_sadik', ' 8801628301510', '1', 'Bhalo bashi', '$2a$12$vuoQez58RNU8pJ8SuGk1Y.arXvf0T6/ou0liahHcJ1jt8HaV/I3Pm');

-- --------------------------------------------------------

--
-- Table structure for table `vendors`
--

CREATE TABLE `vendors` (
  `VendorId` decimal(18,0) NOT NULL,
  `VendorName` text DEFAULT NULL,
  `VendorAddress` text DEFAULT NULL,
  `Remarks` text DEFAULT NULL,
  `ShopID` decimal(18,0) NOT NULL,
  `PhoneNumber` text DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `categories`
--
ALTER TABLE `categories`
  ADD PRIMARY KEY (`CategoryId`),
  ADD KEY `IX_Categories_ShopID` (`ShopID`);

--
-- Indexes for table `commoncode`
--
ALTER TABLE `commoncode`
  ADD PRIMARY KEY (`CommonCodeId`);

--
-- Indexes for table `inventory`
--
ALTER TABLE `inventory`
  ADD KEY `IX_Inventory_PK` (`PK`);

--
-- Indexes for table `inventorylog`
--
ALTER TABLE `inventorylog`
  ADD PRIMARY KEY (`InventoryLogId`),
  ADD KEY `IX_InventoryLog_QuantityUpdateType` (`QuantityUpdateType`);

--
-- Indexes for table `orders`
--
ALTER TABLE `orders`
  ADD PRIMARY KEY (`OrderId`),
  ADD KEY `IX_Orders_UserId` (`UserId`);

--
-- Indexes for table `productimgs`
--
ALTER TABLE `productimgs`
  ADD KEY `IX_ProductImgs_PK` (`PK`);

--
-- Indexes for table `productreturn`
--
ALTER TABLE `productreturn`
  ADD PRIMARY KEY (`ProductReturnId`),
  ADD KEY `IX_ProductReturn_OrderId` (`OrderId`),
  ADD KEY `IX_ProductReturn_PK` (`PK`);

--
-- Indexes for table `products`
--
ALTER TABLE `products`
  ADD PRIMARY KEY (`ProductID`);

--
-- Indexes for table `productsinorder`
--
ALTER TABLE `productsinorder`
  ADD KEY `IX_ProductsInOrder_OrderId` (`OrderId`),
  ADD KEY `IX_ProductsInOrder_PK` (`PK`);

--
-- Indexes for table `shopproducts`
--
ALTER TABLE `shopproducts`
  ADD PRIMARY KEY (`PK`),
  ADD KEY `IX_ShopProducts` (`ProductId`),
  ADD KEY `IX_ShopProducts_ShopID` (`ShopID`),
  ADD KEY `IX_ShopProducts_SubCategoryId` (`SubCategoryId`),
  ADD KEY `IX_ShopProducts_VendorId` (`VendorId`);

--
-- Indexes for table `shops`
--
ALTER TABLE `shops`
  ADD PRIMARY KEY (`ShopID`);

--
-- Indexes for table `subcategories`
--
ALTER TABLE `subcategories`
  ADD PRIMARY KEY (`SubCategoryId`),
  ADD KEY `IX_SubCategories_CategoryId` (`CategoryId`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`UserId`),
  ADD KEY `IX_Users_UserTypeId` (`UserTypeId`);

--
-- Indexes for table `vendors`
--
ALTER TABLE `vendors`
  ADD PRIMARY KEY (`VendorId`),
  ADD KEY `IX_Vendors_ShopID` (`ShopID`);

--
-- Constraints for dumped tables
--

--
-- Constraints for table `categories`
--
ALTER TABLE `categories`
  ADD CONSTRAINT `FK_Categories_Shops` FOREIGN KEY (`ShopID`) REFERENCES `shops` (`ShopID`);

--
-- Constraints for table `inventory`
--
ALTER TABLE `inventory`
  ADD CONSTRAINT `FK_Inventory_ShopProducts` FOREIGN KEY (`PK`) REFERENCES `shopproducts` (`PK`);

--
-- Constraints for table `inventorylog`
--
ALTER TABLE `inventorylog`
  ADD CONSTRAINT `FK_InventoryLog_CommonCode` FOREIGN KEY (`QuantityUpdateType`) REFERENCES `commoncode` (`CommonCodeId`),
  ADD CONSTRAINT `FK_InventoryLog_ShopProducts` FOREIGN KEY (`InventoryLogId`) REFERENCES `shopproducts` (`PK`);

--
-- Constraints for table `orders`
--
ALTER TABLE `orders`
  ADD CONSTRAINT `FK_Orders_Users` FOREIGN KEY (`UserId`) REFERENCES `users` (`UserId`);

--
-- Constraints for table `productimgs`
--
ALTER TABLE `productimgs`
  ADD CONSTRAINT `FK_ProductImgs_ShopProducts` FOREIGN KEY (`PK`) REFERENCES `shopproducts` (`PK`);

--
-- Constraints for table `productreturn`
--
ALTER TABLE `productreturn`
  ADD CONSTRAINT `FK_ProductReturn_Orders` FOREIGN KEY (`OrderId`) REFERENCES `orders` (`OrderId`),
  ADD CONSTRAINT `FK_ProductReturn_ShopProducts` FOREIGN KEY (`PK`) REFERENCES `shopproducts` (`PK`);

--
-- Constraints for table `productsinorder`
--
ALTER TABLE `productsinorder`
  ADD CONSTRAINT `FK_ProductsInOrder_Orders` FOREIGN KEY (`OrderId`) REFERENCES `orders` (`OrderId`),
  ADD CONSTRAINT `FK_ProductsInOrder_ShopProducts` FOREIGN KEY (`PK`) REFERENCES `shopproducts` (`PK`);

--
-- Constraints for table `shopproducts`
--
ALTER TABLE `shopproducts`
  ADD CONSTRAINT `FK_ShopProducts_Products` FOREIGN KEY (`ProductId`) REFERENCES `products` (`ProductID`),
  ADD CONSTRAINT `FK_ShopProducts_Shops1` FOREIGN KEY (`ShopID`) REFERENCES `shops` (`ShopID`),
  ADD CONSTRAINT `FK_ShopProducts_SubCategories` FOREIGN KEY (`SubCategoryId`) REFERENCES `subcategories` (`SubCategoryId`),
  ADD CONSTRAINT `FK_ShopProducts_Vendors` FOREIGN KEY (`VendorId`) REFERENCES `vendors` (`VendorId`);

--
-- Constraints for table `subcategories`
--
ALTER TABLE `subcategories`
  ADD CONSTRAINT `FK_SubCategories_Categories` FOREIGN KEY (`CategoryId`) REFERENCES `categories` (`CategoryId`);

--
-- Constraints for table `users`
--
ALTER TABLE `users`
  ADD CONSTRAINT `FK_Users_CommonCode` FOREIGN KEY (`UserTypeId`) REFERENCES `commoncode` (`CommonCodeId`);

--
-- Constraints for table `vendors`
--
ALTER TABLE `vendors`
  ADD CONSTRAINT `FK_Vendors_Shops` FOREIGN KEY (`ShopID`) REFERENCES `shops` (`ShopID`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
