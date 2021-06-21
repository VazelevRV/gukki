using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Gukki.Models;
using System.Linq;

namespace Gukki.Controllers
{
    public class PlacesController : Controller
    {
        private readonly GukkiDbContext _context;

        public PlacesController(GukkiDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {       
            return View(await _context.Places.Include(p => p.Contacts).AsNoTracking().ToListAsync());
        }

        public async Task<IActionResult> AddOrEditPlace(int? id = 0)
        {
            // Якщо id дорівнює 0 - то це створення нового віділення
            if (id == 0)
            {
                ViewData["Title"] = "Додайте нове відділення";
                return View(new PlaceModel());
            }
            // Інакше - редагування попередньо-створенного
            ViewData["Title"] = "Редагування відділення";
            var place = await _context.Places.Include(p => p.Contacts).FirstOrDefaultAsync(p => p.Id == id);
            return View(place);
        }

        public async Task<IActionResult> AddOrEditContact(int? contactId = 0, int? placeId = 0)
        {
            // Якщо id дорівнює 0 - то це створення нового контакту
            if (contactId == 0)
            {
                var place = await _context.Places.FindAsync(placeId);
                ViewData["Title"] = "Додайте новий контакт";
                ViewData["placeId"] = placeId;
                return View(new ContactModel(){Place = place});
            }
            // Інакше - редагування попередньо-створенного
            ViewData["Title"] = "Редагування контакту";
            return View(await _context.Contacts.Include(c => c.Place).FirstOrDefaultAsync(c => c.Id == contactId));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEditPlace([FromForm] PlaceModel place)
        {
            if (ModelState.IsValid)
            {

                if (place.Id == 0)
                    _context.Add(place);
                else
                    _context.Update(place);                 

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(place);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEditContact([FromForm] ContactModel contact, [FromForm]int placeId)
        {
            if (ModelState.IsValid)
            {
                var place = await _context.Places.FindAsync(placeId);
                contact.Place = place;

                if (contact.Id == 0)
                    _context.Add(contact);
                else
                    _context.Update(contact);                 

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contact);
        }

        // Метод видалення відділення з бази
        public async Task<IActionResult> DeletePlace(int? id)
        {
            var place = await _context.Places.FindAsync(id);

            if(place == null)
                return View();

            var contacts = _context.Contacts.Where(c => c.Place.Id == id);

            if(contacts.Any())
                _context.RemoveRange(contacts);

            _context.Places.Remove(place);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // Метод видалення контакту з бази
        public async Task<IActionResult> DeleteContact(int? id)
        {
            var contact = await _context.Contacts.FindAsync(id);

            if(contact == null)
                return View();

            _context.Contacts.Remove(contact);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
