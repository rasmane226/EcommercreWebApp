using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.ViewComponents
{
    public class CategoryGetList : ViewComponent
    {
        Context c=new Context();
        public IViewComponentResult Invoke()
        {
            var degerler = c.Categories.ToList();
            return View(degerler);
        }
    }
}
