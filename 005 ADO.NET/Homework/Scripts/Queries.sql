/* Database "Wholesale Store. Sales Accounting"  */

-- Reference table for units of measurement
select
   *
from
    Units;
go

-- Reference table for product nomenclature
select
    *
from
    Goods;
go

-- Personal data
select
    *
from
    Persons;
go

-- Sellers
select
   Sellers.Id
   , Persons.Surname
   , Persons.[Name]
   , Persons.Patronymic
   , Sellers.Interest
from
    Sellers join Persons on Sellers.IdPerson = Persons.Id;
go

-- Product purchases
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

-- Sales facts
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

-- Queries based on the task


-- Query 1. Left join query  
-- Selects all sellers (display Seller ID, surname, and initials of the seller), 
-- the number and total sales amount for the given period, ordered by surname and initials
declare @from date = '11-01-2021', @to date = '11-30-2021';
select
   Sellers.Id
   , Persons.Surname + N' ' + Substring(Persons.[Name], 1, 1) + N'.' + Substring(Persons.Patronymic, 1, 1) + N'.' as Seller
   , Sellers.Interest
   , count(PeriodSales.IdSeller)                               as SalesAmount
   , isnull(sum(PeriodSales.Price*PeriodSales.Amount), 0)      as SalesTotal
from
    (Sellers join Persons on Sellers.IdPerson = Persons.Id)
    left join
    -- Sales for the given period
    (select IdSeller, IdPurchase, Price, Amount from Sales where SaleDate between @from and @to) PeriodSales
    on Sellers.Id = PeriodSales.IdSeller 
group by
    Sellers.Id, Persons.Surname, Persons.[Name], Persons.Patronymic, Sellers.Interest
order by
    Seller;
go


-- Query 2. Left join query  
-- Selects all products, the quantity, and the total sales amount for these products.
-- Orders by sales total in descending order
select
    Goods.Id
    , Goods.Item
    , count(Sales.IdUnit)                         as SalesAmount
    , isNull(sum(Sales.Price*Sales.Amount), 0)    as SalesTotal
from
    Goods left join (Sales join Purchases on Sales.IdPurchase = Purchases.Id) 
        on Goods.Id = Purchases.IdUnit
group by
    Goods.Id, Goods.Item
order by
    SalesTotal desc;
go