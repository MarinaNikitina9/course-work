using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using kursach.Models;

[Authorize(Roles = "Client")]
public class ClientController : Controller
{
    private readonly ApplicationDbContext _context;

    public ClientController(ApplicationDbContext context)
    {
        _context = context;
    }

    // Страница для просмотра услуг
    public IActionResult ViewServices()
    {
        var services = _context.Services.ToList();
        return View(services);
    }

    // Страница для создания заказа
    [HttpPost]
    public IActionResult CreateOrder(int serviceId)
    {
        var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier).Value; // Изменено на string
        var order = new Order
        {
            UserId = userId, // Для UserId теперь строка
            ServiceId = serviceId,
            OrderDate = DateTime.Now,
        };

        _context.Orders.Add(order);
        _context.SaveChanges();

        return RedirectToAction("ViewOrders");
    }

    // Страница для просмотра заказов клиента
    public IActionResult ViewOrders()
    {
        var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier).Value; // Изменено на string
        var orders = _context.Orders.Where(o => o.UserId == userId).ToList();
        return View(orders);
    }

    // Страница для оставления отзыва
    [HttpPost]
    public IActionResult AddReview(int orderId, string comment, int rating)
    {
        var review = new Review
        {
            UserId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier).Value, // Изменено на string
            OrderId = orderId,
            Comment = comment,
            Rating = rating
        };

        _context.Reviews.Add(review);
        _context.SaveChanges();

        return RedirectToAction("ViewOrders");
    }
}