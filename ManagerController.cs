using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using kursach.Models;

[Authorize(Roles = "Manager")]
public class ManagerController : Controller
{
    private readonly ApplicationDbContext _context;

    public ManagerController(ApplicationDbContext context)
    {
        _context = context;
    }

    // Страница для управления услугами
    public IActionResult ManageServices()
    {
        var services = _context.Services.ToList();
        return View(services);
    }

    // Редактирование услуги
    [HttpPost]
    public IActionResult EditService(int id, string name, string description, decimal price)
    {
        var service = _context.Services.FirstOrDefault(s => s.Id == id);
        if (service != null)
        {
            service.Name = name;
            service.Description = description;
            service.Price = price;
            _context.SaveChanges();
        }

        return RedirectToAction("ManageServices");
    }

    // Страница для управления заказами
    public IActionResult ManageOrders()
    {
        var orders = _context.Orders.ToList();
        return View(orders);
    }

}