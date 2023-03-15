﻿using Microsoft.AspNetCore.Mvc;
using SushiProject.Models;
using System.Transactions;

namespace SushiProject.Controllers
{
    public class SalesTransactionController : Controller
    {
        private readonly ISalesTransactionRepository repo;

        public SalesTransactionController(ISalesTransactionRepository repo)
        {
            this.repo = repo;
        }

        public IActionResult Index()
        {
            var transactions = repo.GetAllSalesTransactionsSQL();
            return View(transactions);
        }

        public IActionResult ViewSalesTransaction(int transactionID)
        {
            var transaction = repo.GetSalesTransactionSQL(transactionID);
            return View(transaction);
        }

        public IActionResult UpdateSalesTransaction(int id)
        {
            SalesTransaction updateTransaction = repo.GetSalesTransactionSQL(id);

            var transaction = repo.CreateShellSalesTransaction();

            updateTransaction.OrderList = transaction.OrderList;
            updateTransaction.ServerList = transaction.ServerList;
            updateTransaction.RestaurantTableList = transaction.RestaurantTableList;

            if (updateTransaction == null)
            {
                return View("ProductNotFound");
            }
            return View(updateTransaction);
        }

        public IActionResult UpdateSalesTransactionToDatabase(SalesTransaction transactionToUpdate)
        {
            //var transaction = repo.CreateShellSalesTransaction();

            //transactionToUpdate.OrderList = transaction.OrderList;
            //transactionToUpdate.ServerList = transaction.ServerList;
            //transactionToUpdate.RestaurantTableList = transaction.RestaurantTableList;

            transactionToUpdate.FinalTransactionDateAndTime = DateTime.Now;

            transactionToUpdate.FinalTransactionAmount = repo.CalculateTotalSalesTransactionAmount(transactionToUpdate);

            repo.UpdateSalesTransactionSQL(transactionToUpdate);

            return RedirectToAction("ViewSalesTransaction", new { transactionID = transactionToUpdate.SalesTransactionID });
        }

        public IActionResult CreateSalesTransaction1()
        {
            var transaction = repo.AssignServerListSQL();
            return View("CreateSalesTransaction1View", transaction);
        }
        public IActionResult CreateSalesTransaction2(SalesTransaction transaction)
        {
            var tempTransaction = repo.AssignRestaurantTableListSQL(transaction.EmployeeID);
            transaction.RestaurantTableList = tempTransaction.RestaurantTableList;
            return View("CreateSalesTransaction2View", transaction);
        }
        //public IActionResult InsertSalesTransaction(SalesTransaction transaction)
        //{
        //    var transaction = repo.CreateShellSalesTransaction(id);

        //    return View(transaction);
        //}

        [HttpPost]
        public IActionResult InsertSalesTransactionToDatabase(SalesTransaction transactionToInsert)
        {
            //var transaction = repo.CreateShellSalesTransaction();

            //transactionToUpdate.OrderList = transaction.OrderList;
            //transactionToUpdate.ServerList = transaction.ServerList;
            //transactionToUpdate.RestaurantTableList = transaction.RestaurantTableList;

            transactionToInsert.FinalTransactionDateAndTime = DateTime.Now;

            transactionToInsert.FinalTransactionAmount = repo.CalculateTotalSalesTransactionAmount(transactionToInsert);

            repo.InsertSalesTransactionSQL(transactionToInsert);
            return RedirectToAction("Index");
        }


        public IActionResult DeleteSalesTransaction(SalesTransaction transaction)
        {
            repo.DeleteSalesTransactionSQL(transaction);
            return RedirectToAction("Index");
        }

        public IActionResult CompleteSalesTransaction(SalesTransaction transaction)
        {
            repo.CompleteSalesTransactionSQL(transaction);
            return RedirectToAction("Index");
        }

        public IActionResult SetupNewCustomer1()
        {
            var transaction = repo.AssignServerListSQL();
            return View("SetupNewCustomerView1", transaction);
        }
        public IActionResult SetupNewCustomer2(SalesTransaction transaction)
        {
            var tempTransaction = repo.AssignRestaurantTableListSQL(transaction.EmployeeID);
            transaction.RestaurantTableList = tempTransaction.RestaurantTableList;
            return View("SetupNewCustomerView2", transaction);
        }
        public IActionResult SetupNewCustomer3(SalesTransaction transaction)
        {
            var tempTransaction = repo.GetInitialSalesTransactionSQL(transaction);
            return View("SetupNewCustomerView3", tempTransaction);
        }
        public IActionResult CustomerHomePage(int transactionID)
        {
            var transaction = repo.GetSalesTransactionSQL(transactionID);
            return View("NewCustomerHomePage");
        }
    }
}
