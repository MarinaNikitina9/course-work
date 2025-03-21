using Microsoft.AspNetCore.Mvc;
using System.Linq;
using kursach.Models;

public class HomeController : Controller
{
    private readonly ApplicationDbContext _context;

    public HomeController(ApplicationDbContext context)
    {
        _context = context;
    }

    // Главная страница
    public IActionResult Index()
    {
        return View();
    }

    // Просмотр услуг
    public IActionResult Services()
    {
        var services = _context.Services.ToList();
        return View(services);
    }

    // Страница контактов
    public IActionResult Contacts()
    {
        return View();
    }
}