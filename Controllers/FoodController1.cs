using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq.Expressions;
using WebApp.Models;
using X.PagedList;

namespace WebApp.Controllers
{
    public class FoodController1 : Controller
    {
        Context c = new Context();
        //[Authorize]
        public IActionResult Index(int page=1)
        {
            var degerler = c.Foods.ToList();
            return View(degerler.ToPagedList(page,3));
        }
        //public List<Food> FoodList()
        //{
        //    return c.Foods.ToList(); 
        //public void GetFood(int id)
        //{
        //    c.Foods.Find(id);
        //}
        [HttpGet]
        public IActionResult AddFood()
        {
            List<SelectListItem> values = (from x in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString(),
                                           }).ToList();
            ViewBag.V1 = values;
            return View();
        }
        [HttpPost]
        public IActionResult AddFood(Food f)
        {
            c.Foods.Add(f);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult DeleteFood(int id)
        {
            c.Foods.Remove(new Food {FoodID=id });
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult GetFood(int id)
        {
            var x = c.Foods.Find(id);

            List<SelectListItem> values = (from y in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = y.CategoryName,
                                               Value = y.CategoryID.ToString(),
                                           }).ToList();
            ViewBag.V1 = values;

            Food f = new Food()
            {
                FoodID = x.FoodID,
                FoodName=x.FoodName,
                Price=x.Price,
                Stock=x.Stock,
                FoodDescription=x.FoodDescription,  
                ImageUrl=x.ImageUrl,

            };
            return View(f);

        }

        [HttpPost]
        public IActionResult UpdateFood(Food p)
        {
            c.Foods.Update(p);
            c.SaveChanges();
            var x = c.Foods.Find(p.FoodID);
            x.FoodName = p.FoodName;
            x.Price = p.Price;
            x.Stock = p.Stock;
            x.ImageUrl = p.ImageUrl;
            x.FoodDescription = p.FoodDescription;
            x.CategoryID = p.CategoryID;
            return RedirectToAction("Index");
        }
       
    }
}
