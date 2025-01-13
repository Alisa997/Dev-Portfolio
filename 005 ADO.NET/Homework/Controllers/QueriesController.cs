using Homework.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homework.Models;

namespace Homework.Controllers
{
    class QueriesController
    {
        // Data context - connection to the database
        private WholesaleDataContext _db;
        public QueriesController() {
            _db = new WholesaleDataContext();
        } // QueriesController

        public List<Persons> GetPersons() => _db.Persons.ToList();
        public List<Goods> GetGoods() => _db.Goods.ToList();
        public List<Units> GetUnits() => _db.Units.ToList();
        public List<Purchase> GetPurchases() {
            return _db.Purchases
                .Select(purchase => new Purchase {
                    Id = purchase.Id,
                    Price = purchase.Price,
                    Amount = purchase.Amount,
                    Good = purchase.Goods.Item,
                    PurchaseDate = purchase.PurchaseDate,
                    Unit = purchase.Units.Short
                }).ToList();
        } // GetPurchases

        public List<Seller> GetSellers() =>
            _db.Sellers
                .Select(seller => new Seller {
                    Id = seller.Id,
                    Interest = seller.Interest,
                    Name = seller.Persons.Name,
                    Surname = seller.Persons.Surname,
                    Patronymic = seller.Persons.Patronymic,
                }).ToList();

        public List<Sale> GetSales() =>
            _db.Sales
                .Select(sale => new Sale {
                    Id = sale.Id,
                    Good = sale.Purchases.Goods.Item,
                    Amount = sale.Amount,
                    SaleDate = sale.SaleDate,
                    Unit = sale.Units.Short,
                    PurchasePrice = sale.Purchases.Price,
                    SalePrice = sale.Price,
                    Seller = sale.Sellers.Persons.Surname + " " +
                    sale.Sellers.Persons.Name.Substring(0, 1) + ". " +
                    sale.Sellers.Persons.Patronymic.Substring(0, 1) + "."
                }).ToList();

        // Adding a product
        public void AddGoods(string item) { 
            _db.Goods.InsertOnSubmit(new Goods { Item = item });

            try {
                _db.SubmitChanges();
            } catch (Exception e) {
                Console.WriteLine(e);
            } // try-catch
        } // AddGoods

        // Editing a product
        public void EditGoods(int index, string item) {
            Goods goods = _db.Goods.ToArray()[index];

            goods.Item = item;

            try {
                _db.SubmitChanges();
            }
            catch (Exception e) {
                Console.WriteLine(e);
            } // try-catch
        } // EditGoods


        // 1. Left join query
        // Selects all sellers (display seller code, surname, and initials),
        // the amount and total of their sales over a given period, ordered by surname and initials
        public List<QueryViewModel> Query01(DateTime fromDate, DateTime toDate) =>
            (from seller in _db.Sellers
             join sale in _db.Sales.Where(x => x.SaleDate >= fromDate && x.SaleDate <= toDate) on seller.Id equals sale.IdSeller into group_join
             from subsale in group_join.DefaultIfEmpty()
             select new { 
                 seller.Id,
                 seller.Persons.Surname,
                 Name = seller.Persons.Name[0],
                 Patronymic = seller.Persons.Patronymic[0],
                 Price = subsale.Price == null? 0 : subsale.Price
             }).GroupBy(s => new { s.Id, s.Name, s.Patronymic, s.Surname },
                    (key, group) => new QueryViewModel {
                        Title = key.Surname + " " + key.Name + "." + key.Patronymic+ ".",
                        Id = key.Id,
                        SalesAmount = group.Count(x => x.Price != 0),
                        SalesTotal = group.Sum(x => x.Price)
                    }).OrderBy(x => x.Title).ToList();



        // 2. Left join query
        // Selects all goods, their quantity, and total sales for these goods.
        // Orders by descending sales total
        public List<QueryViewModel> Query02() =>
             (from good in _db.Goods
              join sale in _db.Sales on good.Id equals sale.Purchases.IdItem into group_join
              from subsale in group_join.DefaultIfEmpty()
              select new {
                  good.Id,
                  good.Item,
                  Price = subsale.Price == null ? 0 : subsale.Price
              }).GroupBy(s => new { s.Id, s.Item },
                    (key, group) => new QueryViewModel {
                        Title = key.Item,
                        Id = key.Id,
                        SalesAmount = group.Count(x => x.Price != 0),
                        SalesTotal = group.Sum(x => x.Price)
                    }).OrderBy(x => x.Title).ToList();
    } // QueriesController
}
