
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Gukki.Models
{
    // Клас представляє таблицу у базі (кожний атрибут класу - стовпчик у базі)
    public class ProductModel
    {
        // Display name - показує додатку як називати комірки при виведені їх на представлення 
        // (наприклад під час заповнення форма)
        // Назва - La Burgero
        // Ціна - 300
        // Якщо цих атрибутів (Display Name) не було б - ці поля отримали б назву їх змінної (Name, Price, About)
        public int ID { get; set; }

        [DisplayName("*Назва"), Required(ErrorMessage = "Це поле необхідно заповнити"), StringLength(100)]
        public string Name { get; set; }
        // Атрибут Range виконує валідацію ціни (встановлює неможливим поставити ціну меншу за 1)
        [DisplayName("*Ціна ₴"), Required(ErrorMessage = "Це поле необхідно заповнити"),
            Range(1, int.MaxValue, ErrorMessage = "Ціна повинна бути більша за 0")]
        public decimal Price { get; set; }
        [DisplayName("*Характеристики"), Required(ErrorMessage = "Це поле необхідно заповнити"),
            StringLength(1000, ErrorMessage = "Опис має бути максимум 1000 символів")]
        public string About { get; set; }
        // Зберігає Назву файлу зображення продукту для подальшого виводу на представлення
        public string ImageName { get; set; }
    }
}
