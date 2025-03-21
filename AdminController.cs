using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using kursach.Models;

[Authorize(Roles = "Admin")]
public class AdminController : Controller
{
    private readonly ApplicationDbContext _context;

    public AdminController(ApplicationDbContext context)
    {
        _context = context;
    }

    // Страница для просмотра и редактирования базы данных
    public IActionResult ManageDatabase()
    {
        // Получаем данные из базы данных и передаем их в представление
        ViewBag.Users = _context.Users.ToList();
        ViewBag.Services = _context.Services.ToList();
        ViewBag.Orders = _context.Orders.ToList();
        ViewBag.Reviews = _context.Reviews.ToList();

        return View();
    }

    // Редактирование услуги
    [HttpPost]
    public IActionResult EditService(int id, string name, string description, decimal price)
    {
        // Находим услугу по ID и обновляем ее данные
        var service = _context.Services.Find(id); // Используем Find для более эффективного поиска
        if (service != null)
        {
            service.Name = name;
            service.Description = description;
            service.Price = price;
            _context.SaveChanges();
        }

        return RedirectToAction(nameof(ManageDatabase)); // Используем nameof для безопасности при рефакторинге
    }

    // Удаление услуги
    [HttpPost]
    public IActionResult DeleteService(int id)
    {
        // Находим услугу по ID и удаляем ее из контекста
        var service = _context.Services.Find(id); // Используем Find для более эффективного поиска
        if (service != null)
        {
            _context.Services.Remove(service);
            _context.SaveChanges();
        }

        return RedirectToAction(nameof(ManageDatabase)); // Используем nameof для безопасности при рефакторинге
    }
}
