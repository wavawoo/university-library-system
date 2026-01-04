using System;
using System.Collections.Generic;
using System.Linq;

namespace UniversityLibrary
{
    // Реализация репозитория для управления коллекцией библиотечных материалов
    public class ItemRepository : IItemRepository
    {
        private List<LibraryItem> _items; // Основная коллекция для хранения материалов

        // Конструктор - инициализирует пустую коллекцию
        public ItemRepository()
        {
            _items = new List<LibraryItem>();
        }

        // Добавление нового материала в коллекцию
        public void Add(LibraryItem item)
        {
            _items.Add(item);
            Console.WriteLine($"Добавлен: {item.GetType().Name} - {item.Title}"); // Подтверждение добавления
        }

        // Удаление материала из коллекции по идентификатору
        public bool Remove(string itemId)
        {
            var item = FindById(itemId); // Поиск материала по ID
            if (item != null)
            {
                _items.Remove(item); // Удаление из коллекции
                Console.WriteLine($"Материал '{item.Title}' (ID: {itemId}) удален."); // Подтверждение удаления
                return true; // Успешное выполнение
            }
            else
            {
                Console.WriteLine($"Материал с ID {itemId} не найден."); // Сообщение об ошибке
                return false; // Неудачное выполнение
            }
        }

        // Поиск материала по уникальному идентификатору
        public LibraryItem FindById(string itemId)
        {
            return _items.Find(item => item.ItemId == itemId); // Линейный поиск по коллекции
        }

        // Поиск материалов по частичному совпадению названия
        public List<LibraryItem> FindByTitle(string title)
        {
            return _items.FindAll(item =>
                item.Title.Contains(title, StringComparison.OrdinalIgnoreCase)); // Поиск без учета регистра
        }

        // Поиск материалов по частичному совпадению имени автора
        public List<LibraryItem> FindByAuthor(string author)
        {
            return _items.FindAll(item =>
                item.Author.Contains(author, StringComparison.OrdinalIgnoreCase)); // Поиск без учета регистра
        }

        // Получение полной копии коллекции всех материалов
        public List<LibraryItem> GetAll()
        {
            return new List<LibraryItem>(_items); // Возвращаем копию для защиты исходной коллекции
        }

        // Получение списка доступных материалов
        public List<LibraryItem> GetAvailable()
        {
            return _items.Where(item => item.IsAvailable()).ToList(); // Фильтрация по статусу доступности
        }

        // Получение списка выданных материалов
        public List<LibraryItem> GetBorrowed()
        {
            return _items.Where(item => !item.IsAvailable()).ToList(); // Фильтрация по статусу "выдано"
        }

        // Получение общего количества материалов в библиотеке
        public int GetTotalCount()
        {
            return _items.Count; // Простое возвращение размера коллекции
        }

        // Получение количества доступных материалов
        public int GetAvailableCount()
        {
            return _items.Count(item => item.IsAvailable()); // Подсчет с условием доступности
        }

        // Получение количества выданных материалов
        public int GetBorrowedCount()
        {
            return _items.Count(item => !item.IsAvailable()); // Подсчет с условием "выдано"
        }
    }
}
