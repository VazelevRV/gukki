using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Gukki.Models;

namespace Gukki.Controllers
{
    public class ContactsController : Controller
    {
        private readonly GukkiDbContext _context;

        public ContactsController(GukkiDbContext context)
        {
            // Через цей об'єкт додаток зв'язується з базою даних
            _context = context;
        }

        // Головна сторінка контролеру (повертає список всіх контактів з бази на представлення)
        public async Task<IActionResult> Index()
        {
            return View(await _context.Contacts.AsNoTracking().ToListAsync());
        }

        // Цей метод повертає знайдений об'єкт з бази на представлення для редагування, 
        // Або створює новий (без інформації) для подальшого заповнення та збереження до бази
        // Створення Або редагування контакту (GET)
        public IActionResult AddOrEdit(int? id = 0)
        {
            // Якщо id дорівнює 0 - то це створення нового контакту
            if (id == 0)
            {
                ViewData["Title"] = "Додайте новий контакт";
                return View(new ContactModel());
            }
            // Інакше - редагування попередньо-створенного
            ViewData["Title"] = "Редагування контакту";
            return View(_context.Contacts.Find(id));
        }

        // Цей метод повертає на сервер заповнений або відредагований контакт для подальшого збереження
        // POST: Contacts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("Id,ContactName,ContactText")] ContactModel contact)
        {
            if (ModelState.IsValid)
            {

                if (contact.Id == 0)
                    _context.Add(contact);
                else
                    _context.Update(contact);

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contact);


        }

        // Метод видалення контакту з бази
        public async Task<IActionResult> Delete(int? id)
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
