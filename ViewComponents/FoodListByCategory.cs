using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Linq.Expressions;
using WebApp.Models;

namespace WebApp.ViewComponents
{
    public class FoodListByCategory:ViewComponent
    {
        Context c = new Context();

        public IViewComponentResult Invoke(int id)
        {
            id = 1;
            var degerler = c.Foods.ToList();
            return View(degerler);
        }
    }
}
