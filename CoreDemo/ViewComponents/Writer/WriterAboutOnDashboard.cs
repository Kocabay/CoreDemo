using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Writer
{

    public class WriterAboutOnDashboard : ViewComponent
    {
        WriterManager writermanager = new WriterManager(new EfWriterRepository());

        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            var usermail = User.Identity.Name;
            var WriterID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
            var values = writermanager.GetWriterByID(WriterID);
            return View(values);
        }
    }
}

