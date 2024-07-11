using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
	[AllowAnonymous]
	public class ChartController1 : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Index2()
        {
            return View();
        }
        public IActionResult VizualizeProductResult()
        {
            return Json(ProList());
        }
        public List<Class1> ProList()
        {
            List<Class1> cs = new List<Class1>();
            cs.Add(new Class1()
            {
                proname="Computer",
                stock= 150
                
            });
            cs.Add(new Class1()
            {
                proname = "Lcd",
                stock = 155

            });
            cs.Add(new Class1()
            {
                proname = "Usb disk",
                stock = 200

            });
            return cs;

        }
        public IActionResult Index3()
        {
            return View();
        }
        public IActionResult VisualizeProductResult2()
        {
            return Json(FoodList());
        }
        public List<Class2> FoodList()
        {
            List<Class2> cs2 = new List<Class2>();
            using(var c=new Context())
            {
                cs2 = c.Foods.Select(x => new Class2
                {
                    foodname= x.FoodName, 
                    stock= x.Stock
                }).ToList();
                return cs2;
            }
        }
        public IActionResult Statistics() 
        {
            Context c= new Context();
            var deger1 = c.Categories.Count();
            ViewBag.d1= deger1;

            var deger2 = c.Foods.Count();
            ViewBag.d2 = deger2;
            var fooid=c.Categories.Where(x=>x.CategoryName=="Fruit").Select(y=>y.CategoryID).FirstOrDefault();
            //ViewBag.d= fooid;
            var deger3 = c.Foods.Where(x=>x.CategoryID==fooid).Count();
            ViewBag.d3 = deger3;

            var deger4 = c.Foods.Where(x=>x.CategoryID== c.Categories.Where(x => x.CategoryName == "Fruit").Select(y => y.CategoryID).FirstOrDefault()).Count();
            ViewBag.d4 = deger4;

            var deger5 = c.Foods.Sum(x=>x.Stock);
            ViewBag.d5 = deger5;

            var deger6=c.Foods.OrderByDescending(x=>x.Stock).Select(y=>y.FoodName).FirstOrDefault();
            ViewBag.d6= deger6;


            var deger7 = c.Foods.OrderBy(x => x.Stock).Select(y => y.FoodName).FirstOrDefault();
            ViewBag.d7 = deger7;

            var deger8 =c.Foods.Average(x=>x.Price).ToString("0.00");
            ViewBag.d8 = deger8;
            return View();
        }
    }
}
