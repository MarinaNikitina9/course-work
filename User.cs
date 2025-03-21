using Microsoft.AspNetCore.Identity;

namespace kursach.Models
{
    public class User : IdentityUser
    {
        // Удалите Id, Username и Password, так как они уже есть в IdentityUser

        public string Role { get; set; } // Роли: "Admin", "Manager", "Client"

        // Связь один-ко-многим с заказами
        public ICollection<Order> Orders { get; set; } = new List<Order>();

        // Связь один-ко-многим с отзывами
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
    }
}
