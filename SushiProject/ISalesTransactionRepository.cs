﻿using SushiProject.Models;
using System.Drawing;

namespace SushiProject
{
    public interface ISalesTransactionRepository
    {
        public IEnumerable<SalesTransaction> GetAllSalesTransactionsSQL();
        public IEnumerable<SalesTransaction> GetInitialSalesTransactionSQL(SalesTransaction transaction);
        public SalesTransaction GetSalesTransactionSQL(int salesTransactionID);
        public void UpdateSalesTransactionSQL(SalesTransaction salesTransactionToUpdate);
        public void InsertSalesTransactionSQL(SalesTransaction salesTransactionToInsert);
        public IEnumerable<FoodBevOrder> GetOrderListSQL();
        public SalesTransaction AssignOrderListSQL();
        public IEnumerable<Employee> GetServerListSQL();
        public SalesTransaction AssignServerListSQL();
        public IEnumerable<RestaurantTable> GetAllRestaurantTableListSQL();
        public SalesTransaction AssignAllRestaurantTableListSQL();
        public IEnumerable<RestaurantTable> GetRestaurantTableListSQL(int id);
        public SalesTransaction AssignRestaurantTableListSQL(int employeeID);
        public void DeleteSalesTransactionSQL(SalesTransaction salesTransactionToDelete);
        public void CompleteSalesTransactionSQL(SalesTransaction salesTransactionToComplete);
        public SalesTransaction CreateShellSalesTransaction();
        public decimal CalculateTotalSalesTransactionAmount(SalesTransaction transactionToCalculate);
        public decimal GetPerOrderPrice(int orderID);
    }
}
