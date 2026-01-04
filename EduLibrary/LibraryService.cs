using System;
using System.Collections.Generic;
using System.Linq;

namespace UniversityLibrary
{
    // Сервис для операций библиотечного обслуживания - реализует бизнес-логику
    public class LibraryService : ILibraryService
    {
        private readonly IItemRepository _repository; // Зависимость от репозитория

        // Конструктор с внедрением зависимости (Dependency Injection)
        public LibraryService(IItemRepository repository)
        {
            _repository = repository; // Принимаем репозиторий извне
        }

        // Отображение полного каталога всех материалов библиотеки
        public void DisplayAllItems()
        {
            Console.WriteLine("\nВСЕ МАТЕРИАЛЫ БИБЛИОТЕКИ");
            var items = _repository.GetAll(); // Получаем все материалы
            if (!items.Any()) // Проверяем есть ли материалы
            {
                Console.WriteLine("В библиотеке нет материалов.");
                return; // Выход если коллекция пуста
            }
            // Последовательный вывод информации о каждом материале
            foreach (var item in items)
            {
                item.DisplayInfo();
            }
        }

        // Отображение только доступных для выдачи материалов
        public void DisplayAvailableItems()
        {
            Console.WriteLine("\nДОСТУПНЫЕ МАТЕРИАЛЫ");
            var availableItems = _repository.GetAvailable(); // Получаем доступные материалы
            if (!availableItems.Any()) // Проверяем наличие доступных
            {
                Console.WriteLine("Нет доступных материалов.");
                return; // Выход если нет доступных
            }
            // Вывод информации о каждом доступном материале
            foreach (var item in availableItems)
            {
                item.DisplayInfo();
            }
        }

        // Отображение материалов, которые currently выданы читателям
        public void DisplayBorrowedItems()
        {
            Console.WriteLine("\nВЫДАННЫЕ МАТЕРИАЛЫ");
            var borrowedItems = _repository.GetBorrowed(); // Получаем выданные материалы
            if (!borrowedItems.Any()) // Проверяем наличие выданных
            {
                Console.WriteLine("Нет выданных материалов.");
                return; // Выход если нет выданных
            }
            // Вывод информации о каждом выданном материале
            foreach (var item in borrowedItems)
            {
                item.DisplayInfo();
            }
        }

        // Поиск и отображение материалов по автору
        public void SearchByAuthor(string author)
        {
            var results = _repository.FindByAuthor(author); // Поиск в репозитории
            if (results.Count > 0) // Проверка наличия результатов
            {
                Console.WriteLine($"\nНайдено {results.Count} материалов:");
                foreach (var item in results)
                    item.DisplayInfo(); // Вывод информации о найденных материалах
            }
            else
            {
                Console.WriteLine($"Материалы автора '{author}' не найдены."); // Сообщение об отсутствии результатов
            }
        }

        // Поиск и отображение материалов по названию
        public void SearchByTitle(string title)
        {
            var results = _repository.FindByTitle(title); // Поиск в репозитории
            if (results.Count > 0) // Проверка наличия результатов
            {
                Console.WriteLine($"\nНайдено {results.Count} материалов:");
                foreach (var item in results)
                    item.DisplayInfo(); // Вывод информации о найденных материалах
            }
            else
            {
                Console.WriteLine($"Материалы с названием '{title}' не найдены."); // Сообщение об отсутствии результатов
            }
        }

        // Операция выдачи материала читателю
        public void LendItem(string itemId, string borrowerId, DateTime dueDate)
        {
            var item = _repository.FindById(itemId); // Поиск материала по ID
            if (item != null)
            {
                item.Lend(borrowerId, dueDate); // Вызов метода выдачи у материала
            }
            else
            {
                Console.WriteLine($"Материал с ID {itemId} не найден."); // Сообщение об ошибке
            }
        }

        // Операция возврата материала в библиотеку
        public void ReturnItem(string itemId)
        {
            var item = _repository.FindById(itemId); // Поиск материала по ID
            if (item != null)
            {
                item.Return(); // Вызов метода возврата у материала
            }
            else
            {
                Console.WriteLine($"Материал с ID {itemId} не найден."); // Сообщение об ошибке
            }
        }

        // Отображение статистической информации о библиотеке
        public void DisplayStatistics()
        {
            Console.WriteLine("\nСТАТИСТИКА БИБЛИОТЕКИ");
            // Вывод основных количественных показателей
            Console.WriteLine($"Всего материалов: {_repository.GetTotalCount()}");
            Console.WriteLine($"Доступно: {_repository.GetAvailableCount()}");
            Console.WriteLine($"Выдано: {_repository.GetBorrowedCount()}");

            var items = _repository.GetAll(); // Получаем все материалы для анализа
            // Группировка материалов по типу для анализа распределения
            var itemsByType = items.GroupBy(item => item.GetType().Name)
                                  .Select(g => new { Type = g.Key, Count = g.Count() });

            Console.WriteLine("\nРаспределение по типам:");
            // Вывод количества материалов каждого типа
            foreach (var group in itemsByType)
            {
                Console.WriteLine($"  {group.Type}: {group.Count}");
            }
        }
    }
}
