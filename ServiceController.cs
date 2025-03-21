using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using kursach.Models;
using System.Linq;
using System.Threading.Tasks;

[Authorize(Roles = "Manager")] // Доступ только для менеджера
public class ServiceController : Controller
{
    private readonly ApplicationDbContext _context;

    public ServiceController(ApplicationDbContext context)
    {
        _context = context;
    }

    // Отображение списка услуг
    public async Task<IActionResult> Index()
    {
        var services = await _context.Services.ToListAsync();
        return View(services);
    }

    // Форма для добавления новой услуги
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    // Добавление новой услуги
    [HttpPost]
    public async Task<IActionResult> Create(Service service)
    {
        if (ModelState.IsValid)
        {
            _context.Services.Add(service);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(service);
    }

    // Форма для редактирования услуги
    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var service = await _context.Services.FindAsync(id);
        if (service == null)
        {
            return NotFound();
        }
        return View(service);
    }

    // Обновление услуги
    [HttpPost]
    public async Task<IActionResult> Edit(int id, Service service)
    {
        if (id != service.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(service);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceExists(service.Id)) // Проверка, существует ли услуга
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(service);
    }

    // Удаление услуги
    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        var service = await _context.Services.FindAsync(id);
        if (service != null)
        {
            _context.Services.Remove(service);
            await _context.SaveChangesAsync();
        }
        return RedirectToAction(nameof(Index));
    }

    // Проверка, существует ли услуга
    private bool ServiceExists(int id)
    {
        return _context.Services.Any(e => e.Id == id);
    }
}
