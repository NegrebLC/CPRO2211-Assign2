using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CPRO2211_Assign2.Controllers
{
    public class HomeController : Controller
    {
        private ContactContext context { get; set; }

        //Constructor accepts DB context object that's enabled by DI
        public HomeController(ContactContext ctx)
        {
            context = ctx;
        }


        public IActionResult Index()
        {
            var contacts = context.Contacts
                          .Include(c => c.Category)
                          .OrderBy(c => c.FirstName)
                          .ToList();
            return View(contacts);
        }

    }
}
