using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class CategoryController1 : Controller
    {
        Context c=new Context();

        public IActionResult Index()
        {
            var degerler=c.Categories.ToList();
            return View(degerler);
        }
        //public List<Category> CategoryList()
        //{
        //    return c.Categories.ToList();
        //}
        //public void GetCategory(int id)
        //{
        //    c.Categories.Find(id);
        //}

        [HttpGet]
        public IActionResult AddCategory() 
        {
           
            return View();
        }
        [HttpPost]
        public IActionResult AddCategory( Category p)
        {
            if (!ModelState.IsValid) 
            {
                return View();
            }
            c.Categories.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult GetCategory(int id) 
        { 
           var x= c.Categories.Find(id);
            Category ct = new Category()
            {
                CategoryID = x.CategoryID,
                CategoryName = x.CategoryName,
                CategoryDescription = x.CategoryDescription,


            };
            return View(ct);
           
        }
        [HttpPost]
        public IActionResult UpdateCategory(Category cat)
        {
            c.Categories.Update(cat);
            c.SaveChanges();
            var x = c.Categories.Find(cat.CategoryID);
            x.CategoryName= cat.CategoryName;
            x.CategoryDescription= cat.CategoryDescription;
            return RedirectToAction("Index");
        }
        public IActionResult DeleteCategory(int id)
        {
            var x = c.Categories.Find(id);
            c.Categories.Remove(x);
            c.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}
