namespace kursach.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; }
        public string UserId { get; set; }
        public int OrderId { get; set; }

        // Навигационные свойства
        public User User { get; set; } // Пользователь, который оставил отзыв
        public Order Order { get; set; } // Заказ, к которому относится отзыв
    }
}
