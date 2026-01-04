using System;

namespace UniversityLibrary
{
    // Класс книги - наследует от LibraryItem
    public class Book : LibraryItem
    {
        // Специфичные для книги свойства
        public string ISBN { get; private set; } // Международный стандартный книжный номер
        public int Pages { get; private set; } // Количество страниц

        // Конструктор книги с расширенными параметрами
        public Book(string title, string author, int year, string itemId, string isbn, int pages)
            : base(title, author, year, itemId) // Вызов базового конструктора
        {
            ISBN = isbn;
            Pages = pages;
        }

        // Реализация абстрактного метода для отображения информации о книге
        public override void DisplayInfo()
        {
            Console.WriteLine($"Книга: {Title}"); // Заголовок с указанием типа
            Console.WriteLine($"Автор: {Author}"); // Информация об авторе
            Console.WriteLine($"Год: {Year}"); // Год издания
            Console.WriteLine($"ISBN: {ISBN}"); // Уникальный идентификатор издания
            Console.WriteLine($"Страниц: {Pages}"); // Объем книги
            Console.WriteLine($"ID: {ItemId}"); // Внутренний идентификатор библиотеки
            Console.WriteLine($"Статус: {(IsAvailable() ? "Доступна" : "Выдана")}"); // Текущий статус
            if (!IsAvailable()) // Дополнительная информация если книга выдана
            {
                Console.WriteLine($"Читатель: {CurrentBorrower}"); // Кто взял книгу
                Console.WriteLine($"Вернуть до: {DueDate:dd.MM.yyyy}"); // Когда вернуть
            }
            Console.WriteLine("-------------------"); // Разделитель для читаемости
        }
    }
}
