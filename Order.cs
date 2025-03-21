namespace kursach.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public string UserId { get; set; }
        public int ServiceId { get; set; }

        // Навигационные свойства
        public User User { get; set; } // Пользователь, создавший заказ
        public Service Service { get; set; } // Связанный сервис

        // Коллекция отзывов, связанных с этим заказом
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
    }
}