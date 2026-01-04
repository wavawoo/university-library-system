using System;
using System.Collections.Generic;

namespace UniversityLibrary
{
    // Интерфейс сервиса для операций библиотечного обслуживания
    public interface ILibraryService
    {
        void DisplayAllItems(); // Отображение полного каталога
        void DisplayAvailableItems(); // Отображение доступных материалов
        void DisplayBorrowedItems(); // Отображение выданных материалов
        void SearchByAuthor(string author); // Поиск по автору
        void SearchByTitle(string title); // Поиск по названию
        void LendItem(string itemId, string borrowerId, DateTime dueDate); // Выдача материала
        void ReturnItem(string itemId); // Возврат материала
        void DisplayStatistics(); // Отображение статистики библиотеки
    }
}
