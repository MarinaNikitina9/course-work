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

    // ������� ��������
    public IActionResult Index()
    {
        return View();
    }

    // �������� �����
    public IActionResult Services()
    {
        var services = _context.Services.ToList();
        return View(services);
    }

    // �������� ���������
    public IActionResult Contacts()
    {
        return View();
    }
}