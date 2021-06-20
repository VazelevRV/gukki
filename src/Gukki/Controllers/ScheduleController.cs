using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;
using Gukki.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Gukki.Controllers
{
    public class ScheduleController : Controller
    {
        private readonly GukkiDbContext _context;
        
        public ScheduleController(GukkiDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult> Index(CancellationToken cancellationToken)
        {
            var schedule = await _context
                .Schedule
                .AsNoTracking()
                .OrderBy(s => s.OrderIndex)
                .ToListAsync(cancellationToken);
            return View(schedule);
        }

        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            var scheduleToDelete = await _context
                .Schedule
                .AsNoTracking()
                .FirstOrDefaultAsync(d => d.Id == id, cancellationToken);

            if (scheduleToDelete == null)
                return RedirectToAction(nameof(Index));

            _context.Remove(scheduleToDelete);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult AddOrEdit(int? id = 0)
        {
            // Якщо id дорівнює 0 - то це створення нового продукту
            if (id == 0)
            {
                ViewData["Title"] = "Додайте новий день";
                return View(new Schedule());
            }
            // Інакше - редагування попередньо-створенного
            ViewData["Title"] = "Редагування дня розкладу";
            return View(_context.Schedule.Find(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("Id,OrderIndex,WeekdayName,OpenTime,CloseTime")] Schedule schedule,
            CancellationToken cancellationToken)
        {
            if(ModelState.IsValid)
            {
                if(schedule.Id == 0)
                {
                    _context.Schedule.Add(schedule);
                    await _context.SaveChangesAsync(cancellationToken);
                }
                else
                {
                    _context.Schedule.Update(schedule);
                    await _context.SaveChangesAsync(cancellationToken);
                }

                return RedirectToAction(nameof(Index));
            }
            return View(schedule);
        }
    }
}