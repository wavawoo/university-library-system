using System;
using System.Collections.Generic;

namespace UniversityLibrary
{
    // Интерфейс репозитория для работы с коллекцией библиотечных материалов
    public interface IItemRepository
    {
        void Add(LibraryItem item); // Добавление нового материала в коллекцию
        bool Remove(string itemId); // Удаление материала по идентификатору
        LibraryItem FindById(string itemId); // Поиск материала по ID
        List<LibraryItem> FindByTitle(string title); // Поиск материалов по названию
        List<LibraryItem> FindByAuthor(string author); // Поиск материалов по автору
        List<LibraryItem> GetAll(); // Получение всех материалов
        List<LibraryItem> GetAvailable(); // Получение доступных материалов
        List<LibraryItem> GetBorrowed(); // Получение выданных материалов
        int GetTotalCount(); // Общее количество материалов
        int GetAvailableCount(); // Количество доступных материалов
        int GetBorrowedCount(); // Количество выданных материалов
    }
}
