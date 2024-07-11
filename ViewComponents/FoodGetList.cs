using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.ViewComponents
{
    public class FoodGetList:ViewComponent
    {
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            var degerler = c.Foods.ToList();
            return View(degerler);
        }

    }
}
