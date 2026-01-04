using System;

namespace UniversityLibrary
{
    // Класс учебника - наследует от Book
    public class Textbook : Book
    {
        public string Course { get; private set; } // Учебный курс, для которого предназначен учебник

        // Конструктор учебника с дополнительным параметром курса
        public Textbook(string title, string author, int year, string itemId, string isbn, int pages, string course)
            : base(title, author, year, itemId, isbn, pages) // Вызов конструктора родителя
        {
            Course = course; // Инициализация специфичного свойства
        }

        // Переопределение метода отображения информации для учебника
        public override void DisplayInfo()
        {
            Console.WriteLine($"Учебник: {Title}"); // Указание типа материала
            Console.WriteLine($"Автор: {Author}"); // Автор учебника
            Console.WriteLine($"Курс: {Course}"); // Для какого курса предназначен
            Console.WriteLine($"Год: {Year}"); // Год издания (важно для актуальности)
            Console.WriteLine($"ISBN: {ISBN}"); // Международный идентификатор
            Console.WriteLine($"Страниц: {Pages}"); // Объем учебного материала
            Console.WriteLine($"ID: {ItemId}"); // Внутренний идентификатор библиотеки
            Console.WriteLine($"Статус: {(IsAvailable() ? "Доступен" : "Выдан")}"); // Статус доступности
            if (!IsAvailable()) // Дополнительная информация если учебник выдан
            {
                Console.WriteLine($"Читатель: {CurrentBorrower}"); // ID читателя
                Console.WriteLine($"Вернуть до: {DueDate:dd.MM.yyyy}"); // Дата возврата
            }
            Console.WriteLine("-------------------"); // Визуальный разделитель
        }
    }
}
