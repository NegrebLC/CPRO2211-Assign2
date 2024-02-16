using Microsoft.AspNetCore.Mvc;
using CPRO2211_Assign2.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CPRO2211_Assign2.Controllers
{
    public class ContactsController : Controller
    {
        private ContactContext context { get; set; }

        public ContactsController(ContactContext ctx)
        {
            context = ctx;
        }

        // Mapping for the adding a new contact screen
        [HttpGet]
        public IActionResult Add()
        {
            ViewData["CategoryId"] = new SelectList(context.Categories, "Id", "Name");
            ViewBag.Action = "Add";
            return View("Edit", new Contact());
        }

        // Mapping for the modifying a contact screen
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            ViewData["CategoryId"] = new SelectList(context.Categories, "Id", "Name");
            ViewBag.Action = "Edit";
            var contact = context.Contacts.Find(id);
            return View(contact);
        }

        // Mapping for the details screen
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            ViewBag.Action = "Details";
            var contact = await context.Contacts
                                       .Include(c => c.Category)
                                       .FirstOrDefaultAsync(c => c.Id == id);

            if (contact == null)
            {
                return NotFound();
            }

            return View(contact);
        }

        // Mapping for updating the database with a new or modified contact
        [HttpPost]
        public IActionResult Edit(Contact contact)
        {
            ViewBag.ContactJson = System.Text.Json.JsonSerializer.Serialize(contact);
            if (ModelState.IsValid)
            {
                if (contact.Id == 0)
                    context.Contacts.Add(contact);
                else
                    context.Contacts.Update(contact);
                context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.ContactJson = System.Text.Json.JsonSerializer.Serialize(contact);
                ViewData["CategoryId"] = new SelectList(context.Categories, "Id", "Name", contact.CategoryId);
                ViewBag.Action = (contact.Id == 0) ? "Add" : "Edit";
                return View(contact);
            }
        }

        // Mapping to delete screen
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var contact = await context.Contacts
                                       .Include(c => c.Category)
                                       .FirstOrDefaultAsync(c => c.Id == id);

            if (contact == null)
            {
                return NotFound();
            }

            return View(contact);
        }

        // Mapping to delete action
        [HttpPost]
        public IActionResult Delete(Contact contact)
        {
            context.Contacts.Remove(contact);
            context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

    }
}
