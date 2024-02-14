using Microsoft.AspNetCore.Mvc;

namespace CPRO2211_Assign2.Controllers
{
    public class HomeController : Controller
    {
        private ContactContext Context { get; set; }

        //Constructor accepts DB context object that's enabled by DI
        public HomeController(ContactContext ctx)
        {
            Context = ctx;
        }


        public IActionResult Index()
        {
            var contacts = Context.Contacts.OrderBy(c => c.FirstName).ToList();
            return View(contacts);
        }

    }
}
