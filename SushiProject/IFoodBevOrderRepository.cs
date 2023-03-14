﻿using SushiProject.Models;

namespace SushiProject
{
    public interface IFoodBevOrderRepository
    {
        public IEnumerable<FoodBevOrder> GetAllFoodBevOrdersSQL();
        public FoodBevOrder GetFoodBevOrderSQL(int foodBevOrderID);
        public void UpdateFoodBevOrderSQL(FoodBevOrder foodBevOrderToUpdate);
        public void InsertFoodBevOrderSQL(FoodBevOrder foodBevOrderToInsert);
        public IEnumerable<MenuItem> GetMenuItemListSQL();
        public FoodBevOrder AssignMenuItemListSQL();
        public IEnumerable<Employee> GetServerListSQL();
        public FoodBevOrder AssignServerListSQL();
        public IEnumerable<RestaurantTable> GetRestaurantTableListSQL();
        public FoodBevOrder AssignRestaurantTableListSQL();
        public void DeleteFoodBevOrderSQL(FoodBevOrder foodBevOrderToDelete);
        public void FulfillFoodBevOrder(int foodBevOrderID);

        //public FoodBevOrder IngredientSetNullValues(FoodBevOrder item);
    }
}
