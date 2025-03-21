namespace kursach.Models
{
    public class Service
    {
        public int Id { get; set; } // Уникальный идентификатор услуги
        public string Name { get; set; } // Название услуги
        public string Description { get; set; } // Описание услуги
        public decimal Price { get; set; } // Цена услуги

        // Навигационные свойства
        public ICollection<Order> Orders { get; set; } = new List<Order>(); 
    }
}


