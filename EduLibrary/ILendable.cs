using System;

namespace UniversityLibrary
{
    // Интерфейс для объектов, которые можно выдавать и возвращать в библиотеке
    public interface ILendable
    {
        void Lend(string borrowerId, DateTime dueDate); // Метод для выдачи материала читателю
        void Return(); // Метод для возврата материала в библиотеку
        bool IsAvailable(); // Проверка доступности материала для выдачи
    }
}
