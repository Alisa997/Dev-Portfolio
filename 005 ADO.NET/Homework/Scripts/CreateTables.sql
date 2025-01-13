/* 
 * Database "Wholesale Store. Sales Accounting" 
 *
 * Description of the subject area
 * The wholesale store purchases goods at the purchase price per unit and sells 
 * goods at the sale price per unit. The difference between the sale price and 
 * the purchase price is the store's profit from selling a unit of goods.
 * Each seller receives a commission for the goods sold. 
 * The amount of commission is equal to: 
 *     Sale price per unit * Number of units sold 
 *                                 * Seller's commission percentage.
 * The profit from selling a batch of goods is calculated as 
 *     (Sale price per unit - Purchase price per unit) 
 *          * Number of units sold.
 *
 * The database should include at least the following tables: GOODS, SELLERS, SALES,
 * containing the following information:
 *     • Name of the product
 *     • Unit of measure for the product
 *     • Purchase price per unit
 *     • Sale date
 *     • Sale price per unit
 *     • Quantity of units sold
 *     • Seller's last name
 *     • Seller's first name
 *     • Seller's patronymic
 *     • Seller's commission percentage
 * 
 TASK DESCRIPTION
 *     1. Define the fields of the base tables.
 *     2. Define the properties of each field in the table.
 *     3. In each table, define the key field.
 *     4. Define the types of relationships between the tables.
 *     5. Establish the relationships between the tables.
 * Develop scripts for:
 *     1. Creating tables 
 *     2. Populating the tables with initial data. Each table must
 *        contain at least 10 records.
 *     3. Execute queries based on the task
 * 
 */

-- Creating database tables

-- Delete old versions of tables, whether they are empty or not. 
-- Delete tables in reverse order of creation. 
-- Specifically, we delete tables with foreign keys first, then the others 
drop table if exists Sales;        -- Sales facts by sellers
drop table if exists Sellers;      -- Sellers 
drop table if exists Persons;      -- Personal data of sellers
drop table if exists Purchases;    -- Purchase facts for goods
drop table if exists Goods;        -- Product catalog
drop table if exists Units;        -- Units of measurement for goods

-- Table: Units (unit of measurement reference)
create table dbo.Units(
	Id     int          not null primary key identity (1, 1),
	Short  nvarchar(6)  not null,   -- Short name of the unit of measurement
	Long   nvarchar(26) not null    -- Full name of the unit of measurement
); 
go

-- Table: Goods (product catalog)
create table dbo.Goods(
	Id    int          not null primary key identity (1, 1),
	Item  nvarchar(60) not null   -- Product name
); 
go

-- Table: Purchases (purchase facts)
create table dbo.Purchases(
	Id            int  not null primary key identity (1, 1),
	IdItem        int  not null, -- Foreign key referencing Goods
	IdUnit        int  not null, -- Foreign key referencing Units
	PurchaseDate  date not null, -- Purchase date
	Price         int  not null, -- Purchase price per unit
	Amount        int  not null, -- Quantity of goods purchased

	-- Field value constraints
	constraint    CK_Purchases_PurchaseDate check(PurchaseDate > '01-01-2021'),
	constraint    CK_Purchases_Price        check(Price > 0),
	constraint    CK_Purchases_Amount       check(Amount > 0),

	-- Foreign keys
	constraint    FK_Purchases_Goods  foreign key (IdItem) references dbo.Goods(Id), 
	constraint    FK_Purchases_Units  foreign key (IdUnit) references dbo.Units(Id) 
); 
go

-- Table: Persons (personal data of sellers)
create table dbo.Persons (
	Id          int          not null primary key identity (1, 1),
	Surname     nvarchar(60) not null,    -- Seller's last name
	[Name]      nvarchar(50) not null,    -- Seller's first name
	Patronymic  nvarchar(60) not null,    -- Seller's patronymic
	Passport    nvarchar(15) not null,    -- Seller's passport series and number

	-- Unique constraint on passport number
	constraint  CK_Persons_Passport unique(Passport)
);
go

-- Table: Sellers (sellers)
create table dbo.Sellers (
	Id        int   not null primary key identity (1, 1),
	IdPerson  int   not null,   -- Foreign key referencing Persons
	Interest  float not null,   -- Seller's commission percentage

	-- Commission percentage between 1% and 15%
	constraint CK_Sellers_Interest check(Interest between 1.0 and 15.0),  
	
	-- Foreign key to link to the Persons table  
	constraint FK_Sellers_Persons foreign key (IdPerson) references dbo.Persons(Id) 
);
go

-- Table: Sales (sales transactions)
create table Sales(
	Id          int   not null primary key identity (1, 1),
	IdPurchase  int   not null,  -- Foreign key referencing Purchases (what is sold)
	IdUnit      int   not null,  -- Foreign key referencing Units (units of measurement)
	IdSeller    int   not null,  -- Foreign key referencing Sellers (who sold)
	SaleDate    date  not null,  -- Sale date
	Price       int   not null,  -- Sale price per unit
	Amount      int   not null,  -- Quantity of goods sold

	-- Constraints
	constraint  CK_Sales_SaleDate  check(SaleDate > '01-01-2021'),
	constraint  CK_Sales_Price     check(Price > 0),
	constraint  CK_Sales_Amount    check(Amount > 0),

	-- Foreign keys
	constraint  FK_Sales_Purchases foreign key (IdPurchase) references dbo.Purchases(Id),
	constraint  FK_Sales_Units     foreign key (IdUnit)     references dbo.Units(Id),
	constraint  FK_Sales_Sellers   foreign key (IdSeller)   references dbo.Sellers(Id)
);
go

-- View: Purchases (Purchase facts view)
drop view if exists PurchasesView; go;

create view PurchasesView as
	select
		Purchases.Id
		, Goods.Item
		, Units.Short
		, Purchases.PurchaseDate
		, Purchases.Price
		, Purchases.Amount
	from
		Purchases join Goods on Purchases.IdItem = Goods.Id
				  join Units on Purchases.IdUnit = Units.Id;
go

-- View: Sellers (Seller view)
drop view if exists SellersView; go;

create view SellersView as
	select
	   Sellers.Id
	   , Persons.Surname
	   , Persons.[Name]
	   , Persons.Patronymic
	   , Persons.Passport
	   , Sellers.Interest
	from
		Sellers join Persons on Sellers.IdPerson = Persons.Id;
go

-- View: Sales (Sales view)
drop view if exists SalesView; go;

create view SalesView as
	select
		Sales.Id
		, Goods.Item
		, Units.Short
		, Persons.Surname + N' ' + Substring(Persons.[Name], 1, 1) + N'.' + Substring(Persons.Patronymic, 1, 1) + N'.' as Seller
		, Sales.SaleDate
		, Purchases.Price   as PurchasePrice
		, Sales.Price       as SalePrice
		, Sales.Amount
	from
		Sales join (Sellers join Persons on Sellers.IdPerson = Persons.Id) on Sales.IdSeller = Sellers.IdPerson
			  join (Purchases join Goods on Purchases.IdItem = Goods.Id) on Sales.IdPurchase = Purchases.Id
			  join Units on Sales.IdUnit = Units.Id;
go