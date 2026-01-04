using System;

namespace UniversityLibrary
{
    // Класс справочника - наследует от Book
    public class Reference : Book
    {
        public string Subject { get; private set; } // Предметная область справочника

        // Конструктор справочника с дополнительным параметром предмета
        public Reference(string title, string author, int year, string itemId, string isbn, int pages, string subject)
            : base(title, author, year, itemId, isbn, pages) // Вызов конструктора Book
        {
            Subject = subject; // Инициализация предметной области
        }

        // Переопределение метода отображения информации для справочника
        public override void DisplayInfo()
        {
            Console.WriteLine($"Справочник: {Title}"); // Указание типа материала
            Console.WriteLine($"Автор: {Author}"); // Автор справочника
            Console.WriteLine($"Предмет: {Subject}"); // Предметная область
            Console.WriteLine($"Год: {Year}"); // Год издания
            Console.WriteLine($"ISBN: {ISBN}"); // Международный идентификатор
            Console.WriteLine($"Страниц: {Pages}"); // Объем справочника
            Console.WriteLine($"ID: {ItemId}"); // Внутренний идентификатор библиотеки
            Console.WriteLine($"Статус: {(IsAvailable() ? "Доступен" : "Выдан")}"); // Статус доступности
            if (!IsAvailable()) // Дополнительная информация если справочник выдан
            {
                Console.WriteLine($"Читатель: {CurrentBorrower}"); // ID читателя
                Console.WriteLine($"Вернуть до: {DueDate:dd.MM.yyyy}"); // Дата возврата
            }
            Console.WriteLine("-------------------"); // Визуальный разделитель между записями
        }
    }
}
