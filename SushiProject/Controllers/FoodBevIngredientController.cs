﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SushiProject.Models;

namespace SushiProject.Controllers
{
    public class FoodBevIngredientController : Controller
    {
        private readonly IFoodBevIngredientRepository repo;

        public FoodBevIngredientController(IFoodBevIngredientRepository repo)
        {
            this.repo = repo;
        }

        public IActionResult Index()
        {
            var ingredients = repo.GetAllFoodBevIngredientsSQL();
            return View(ingredients);
        }

        public IActionResult ViewFoodBevIngredient(int id)
        {
            var ingredient = repo.GetFoodBevIngredientSQL(id);
            return View(ingredient);
        }

        public IActionResult UpdateFoodBevIngredient(int id)
        {
            var categories = repo.AssignFoodBevIngredientCategorySQL();
            FoodBevIngredient ingredient = repo.GetFoodBevIngredientSQL(id);
            if (ingredient == null)
            {
                return View("ProductNotFound");
            }
            ingredient.IngredientCategories = categories.IngredientCategories;
            return View(ingredient);
        }

        public IActionResult UpdateFoodBevIngredientToDatabase(FoodBevIngredient ingredient)
        {
            repo.UpdateFoodBevIngredientSQL(ingredient);

            return RedirectToAction("ViewFoodBevIngredient", new { id = ingredient.IngredientID });
        }

        public IActionResult InsertFoodBevIngredient()
        {
            var ingredient = repo.AssignFoodBevIngredientCategorySQL();
            return View(ingredient);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> InsertFoodBevIngredient([Bind("IngredientID,IngredientName,IngredientStockLevel,IngredientCost,IngredientCategoryName")]
        FoodBevIngredient foodBevIngredient)
        {
            if (ModelState.IsValid)
            {
                InsertFoodBevIngredientToDatabase(foodBevIngredient);
                return RedirectToAction("Index");
            }
            return View(foodBevIngredient);
        }

        public IActionResult InsertFoodBevIngredientToDatabase(FoodBevIngredient ingredientToInsert)
        {
            repo.InsertFoodBevIngredientSQL(ingredientToInsert);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteFoodBevIngredient(FoodBevIngredient ingredient)
        {
            repo.DeleteFoodBevIngredientSQL(ingredient);
            return RedirectToAction("Index");
        }
    }
}
