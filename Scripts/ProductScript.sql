-- 🛒 Categories Table (For Product Classification)
CREATE TABLE ProductCategories (
    CategoryId UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    Name NVARCHAR(100) NOT NULL,
    Description NVARCHAR(255) NULL,
	ParentCategoryId UNIQUEIDENTIFIER   NULL,
    CreatedAt DATETIME DEFAULT GETDATE()
);

-- 🏷 Products Table
CREATE TABLE Products (
    Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    Name NVARCHAR(200) NOT NULL,
    Description NVARCHAR(500) NULL,
    Price DECIMAL(18,2) NOT NULL,
    StockQuantity INT NOT NULL CHECK (StockQuantity >= 0),
	IsActive bit NOT NULL default(0),
    CategoryId UNIQUEIDENTIFIER NOT NULL,
    CreatedAt DATETIME DEFAULT GETDATE(),
    UpdatedAt DATETIME DEFAULT GETDATE(),
    CONSTRAINT FK_Products_Categories FOREIGN KEY (CategoryId) REFERENCES ProductCategories(CategoryId) ON DELETE CASCADE
);
-- Parent Categories
INSERT INTO ProductCategories (CategoryId, Name, ParentCategoryId) VALUES
(NEWId(), 'Electronics', NULL),
(NEWId(), 'Fashion', NULL),
(NEWId(), 'Home & Kitchen', NULL),
(NEWId(), 'Groceries & Food', NULL),
(NEWId(), 'Health & Personal Care', NULL),
(NEWId(), 'Books & Stationery', NULL),
(NEWId(), 'Toys & Baby Products', NULL),
(NEWId(), 'Sports & Outdoor', NULL),
(NEWId(), 'Automotive', NULL),
(NEWId(), 'Music & Entertainment', NULL);

-- Subcategories (Belong to Parent Categories)
INSERT INTO ProductCategories (CategoryId, Name, ParentCategoryId) VALUES
(NEWId(), 'Mobile Phones', (SELECT CategoryId FROM ProductCategories WHERE Name = 'Electronics')),
(NEWId(), 'Laptops & Computers', (SELECT CategoryId FROM ProductCategories WHERE Name = 'Electronics')),
(NEWId(), 'Cameras', (SELECT CategoryId FROM ProductCategories WHERE Name = 'Electronics')),
(NEWId(), 'Smartwatches', (SELECT CategoryId FROM ProductCategories WHERE Name = 'Electronics')),
(NEWId(), 'Accessories', (SELECT CategoryId FROM ProductCategories WHERE Name = 'Electronics')),

(NEWId(), 'Men’s Clothing', (SELECT CategoryId FROM ProductCategories WHERE Name = 'Fashion')),
(NEWId(), 'Women’s Clothing', (SELECT CategoryId FROM ProductCategories WHERE Name = 'Fashion')),
(NEWId(), 'Footwear', (SELECT CategoryId FROM ProductCategories WHERE Name = 'Fashion')),
(NEWId(), 'Watches & Jewelry', (SELECT CategoryId FROM ProductCategories WHERE Name = 'Fashion')),

(NEWId(), 'Furniture', (SELECT CategoryId FROM ProductCategories WHERE Name = 'Home & Kitchen')),
(NEWId(), 'Kitchen Appliances', (SELECT CategoryId FROM ProductCategories WHERE Name = 'Home & Kitchen')),
(NEWId(), 'Home Decor', (SELECT CategoryId FROM ProductCategories WHERE Name = 'Home & Kitchen')),

(NEWId(), 'Fruits & Vegetables', (SELECT CategoryId FROM ProductCategories WHERE Name = 'Groceries & Food')),
(NEWId(), 'Beverages', (SELECT CategoryId FROM ProductCategories WHERE Name = 'Groceries & Food')),
(NEWId(), 'Snacks & Chocolates', (SELECT CategoryId FROM ProductCategories WHERE Name = 'Groceries & Food')),

(NEWId(), 'Skincare & Beauty', (SELECT CategoryId FROM ProductCategories WHERE Name = 'Health & Personal Care')),
(NEWId(), 'Haircare', (SELECT CategoryId FROM ProductCategories WHERE Name = 'Health & Personal Care')),
(NEWId(), 'Vitamins & Supplements', (SELECT CategoryId FROM ProductCategories WHERE Name = 'Health & Personal Care')),

(NEWId(), 'Fiction & Non-fiction Books', (SELECT CategoryId FROM ProductCategories WHERE Name = 'Books & Stationery')),
(NEWId(), 'Educational Books', (SELECT CategoryId FROM ProductCategories WHERE Name = 'Books & Stationery')),
(NEWId(), 'Office Supplies', (SELECT CategoryId FROM ProductCategories WHERE Name = 'Books & Stationery')),

(NEWId(), 'Baby Clothing', (SELECT CategoryId FROM ProductCategories WHERE Name = 'Toys & Baby Products')),
(NEWId(), 'Educational Toys', (SELECT CategoryId FROM ProductCategories WHERE Name = 'Toys & Baby Products')),
(NEWId(), 'Diapers & Baby Care', (SELECT CategoryId FROM ProductCategories WHERE Name = 'Toys & Baby Products')),

(NEWId(), 'Gym Equipment', (SELECT CategoryId FROM ProductCategories WHERE Name = 'Sports & Outdoor')),
(NEWId(), 'Bicycles', (SELECT CategoryId FROM ProductCategories WHERE Name = 'Sports & Outdoor')),
(NEWId(), 'Outdoor Gear', (SELECT CategoryId FROM ProductCategories WHERE Name = 'Sports & Outdoor')),

(NEWId(), 'Car Accessories', (SELECT CategoryId FROM ProductCategories WHERE Name = 'Automotive')),
(NEWId(), 'Bike Accessories', (SELECT CategoryId FROM ProductCategories WHERE Name = 'Automotive')),

(NEWId(), 'Musical Instruments', (SELECT CategoryId FROM ProductCategories WHERE Name = 'Music & Entertainment')),
(NEWId(), 'Gaming Consoles', (SELECT CategoryId FROM ProductCategories WHERE Name = 'Music & Entertainment'));
