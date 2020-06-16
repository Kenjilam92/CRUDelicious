using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CRUDelicious.Models;

namespace CRUDelicious.Controllers
{
    public class HomeController : Controller
    {
        private Context context {get;set;} 
        public HomeController(Context databases)
        {
            context = databases;
        }
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {   
            ViewBag.Dishes= context.Dishes.ToList();
            return View();
        }
        [Route("new")]
        public IActionResult New()
        {
            return View();
        }
        [Route("{id}")]
        public IActionResult Dish(int id)
        {   
            ViewBag.Dish = context.Dishes
                            .FirstOrDefault(d => d.DishId == id);
            return View();
        }
        [Route("{id}/delete")]
        public IActionResult delete(int id)
        {
            context.Dishes.Remove(
                context.Dishes.FirstOrDefault(d => d.DishId == id)
            );
            context.SaveChanges();
            return Redirect("/");
        }
        [Route("edit/{id}")]
        public IActionResult Edit(int id)
        {   
            Dish a = context.Dishes.FirstOrDefault(d => d.DishId == id);
            return View(a);
        }

        [HttpPost]
        [Route("add")]
        public IActionResult Create(Dish newdish)
        {
            if (ModelState.IsValid)
            {   
                context.Dishes.Add(newdish);
                context.SaveChanges();
                return Redirect("/");
            }
            else 
            {
                // return RedirectToAction("New"); this doesn't work
                // Redirect()
                return View("new"); // this need to be RENDER, not redirect;
            }
        }
        // public IActionResult Privacy()
        // {
        //     return View();
        // }
        [Route("update/{id}")]
        public IActionResult Update(int id, Dish updatedDish)
        {   
            if (ModelState.IsValid)
            {       
                Dish SelectedDish = context.Dishes.FirstOrDefault(d => d.DishId == id);
                SelectedDish.Chef = updatedDish.Chef;
                SelectedDish.Name = updatedDish.Name;
                SelectedDish.Calories = updatedDish.Calories;
                SelectedDish.Tastiness = updatedDish.Tastiness;
                SelectedDish.UpdatedAt = updatedDish.UpdatedAt;
                SelectedDish.Description = updatedDish.Description;
                context.SaveChanges();
                return Redirect($"/{id}");
            }
            else 
            {   
                updatedDish.DishId = id; //need this one to repeat the ID. If not the ID on url will lost
                return View("Edit",updatedDish); // this need to be RENDER, not redirect;
            }
        }
        // [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        // public IActionResult Error()
        // {
        //     return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        // }
    }
}
