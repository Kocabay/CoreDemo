using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CoreDemo.Controllers
{
   
    public class BlogContoller : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());
        BlogManager bm = new BlogManager(new EfBlogRepository());
        Context c = new Context();

        public IActionResult Index()
        {
            var values = bm.GetBlogListWithCategory();
            return View(values);
        }
        public IActionResult BlogReadAll(int id)
        {
            ViewBag.i = id;
            var values = bm.GetBlogByID;
            return View(values);
        }
        public IActionResult BlogListByWriter()
        {
             
            var usermail = User.Identity.Name;
            var WriterID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
            var values = bm.GetListWithCategoryByWriterBm(WriterID);
            return View(values);
        }
        [HttpGet]
        public IActionResult BlogAdd()
        {
    
            List<SelectListItem> categoryvalues = (from x in cm.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString(),
                                                   }).ToList();
            ViewBag.cv = categoryvalues;
            return View();
        }


        [HttpPost]
        public IActionResult BlogAdd(Blog p)
        {
           
            var usermail = User.Identity.Name;
            var WriterID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
            BlogValidator bv = new BlogValidator();
            ValidationResult result = bv.Validate(p);
            if (result.IsValid)
            {

                p.BlogStatus = true;
                p.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                p.WriterID = WriterID;
                bm.TAdd(p);
                return RedirectToAction("BlogListByWriter", "Blog");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        public IActionResult DeleteBlog(int id )
        {
            var blogvalue = bm.TGetById(id);
            bm.TDelete(blogvalue);
            return RedirectToAction("BlogListByWriter");
        }

        [HttpGet]
        public IActionResult EditBlog(int id)
        {
            var blogvalue= bm.TGetById(id);
            List<SelectListItem> categoryvalues = (from x in cm.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString(),
                                                   }).ToList();
            ViewBag.cv = categoryvalues;
       
            return View(blogvalue);
        }

        [HttpPost]
        public IActionResult EditBlog(Blog p)
        {
            var usermail = User.Identity.Name;
            var WriterID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
            p.WriterID = WriterID;
            p.BlogCreateDate= DateTime.Parse(DateTime.Now.ToShortDateString());
            p.BlogStatus = true;
            bm.TUpdate(p);
            return RedirectToAction("BlogListByWriter");
        }
    }
}
