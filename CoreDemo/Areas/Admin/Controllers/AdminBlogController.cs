using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Areas.Admin.Controllers
{
    public class AdminBlogController : Controller
    {
        [Area("Admin")]
        public IActionResult Index()
        {
            BlogManager blogManager = new BlogManager(new EfBlogRepository());
            var values = blogManager.GetBlogListWithCategory();
            return View(values);
        }
    }
}
