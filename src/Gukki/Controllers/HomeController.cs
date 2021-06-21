using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Gukki.Models;
using Uploader;

namespace Gukki.Controllers
{
    public class HomeController : Controller
    {
        private readonly GukkiDbContext _context;

        public HomeController(GukkiDbContext context)
        {
            // Через цей об'єкт додаток зв'язується з базою даних
            _context = context;
        }

        // Головна сторінка сайту (повертає список всіх товарів з бази на представлення)
        public async Task<IActionResult> Index()
        {
            return View(await _context.Products.AsNoTracking().ToListAsync());
        }

        // Цей метод повертає знайдений об'єкт з бази на представлення для редагування, 
        // Або створює новий (без інформації) для подальшого заповнення та збереження до бази
        // Створення Або редагування продукту (GET)
        public IActionResult AddOrEdit(int? id = 0)
        {
            // Якщо id дорівнює 0 - то це створення нового продукту
            if (id == 0)
            {
                ViewData["Title"] = "Додайте новий продукт";
                return View(new ProductModel());
            }
            // Інакше - редагування попередньо-створенного
            ViewData["Title"] = "Редагування продукту";
            return View(_context.Products.Find(id));
        }

        // Цей метод повертає на сервер заповнений або відредагований продукт для подальшого збереження
        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([FromForm] ProductModel product, IFormFile image)
        {
            if (ModelState.IsValid)
            {
                // Якщо було додане нове зображення - додати його до об'єкту 
                if (image != null)
                {
                    // Збереження отриманого файлу з форми у локальну папку проекту
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", "content");
                    var savedFileName = await Images.Upload(path, image);
                    product.ImageName = savedFileName;
                }
                // Якщо зображення не встановлено - встановити зображення "немає зображення"
                else if (image == null && String.IsNullOrEmpty(product.ImageName)){
                    product.ImageName = "noImage.jpg";
                }

                if (product.ID == 0)
                    _context.Add(product);
                else
                    _context.Update(product);

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(product);


        }

        // Метод видалення продукту з бази
        public async Task<IActionResult> Delete(int? id)
        {
            var product = await _context.Products.FindAsync(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
