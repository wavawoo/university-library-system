using System;

namespace UniversityLibrary
{
    // Абстрактный базовый класс для всех библиотечных материалов
    public abstract class LibraryItem : ILendable
    {
        // Основные свойства библиотечного материала
        public string Title { get; protected set; } // Название материала
        public string Author { get; protected set; } // Автор или создатель
        public int Year { get; protected set; } // Год издания
        public string ItemId { get; protected set; } // Уникальный идентификатор в системе
        public bool IsBorrowed { get; protected set; } // Флаг выдачи (true - выдан, false - доступен)
        public string CurrentBorrower { get; protected set; } // ID читателя, взявшего материал
        public DateTime? DueDate { get; protected set; } // Дата возврата (null если не выдан)

        // Базовый конструктор для инициализации общих свойств
        protected LibraryItem(string title, string author, int year, string itemId)
        {
            Title = title;
            Author = author;
            Year = year;
            ItemId = itemId;
            IsBorrowed = false; // При создании материал всегда доступен
            CurrentBorrower = null; // При создании никто не взял материал
            DueDate = null; // Дата возврата не установлена
        }

        // Абстрактный метод для отображения информации (должен быть реализован в наследниках)
        public abstract void DisplayInfo();

        // Реализация метода выдачи материала из интерфейса ILendable
        public virtual void Lend(string borrowerId, DateTime dueDate)
        {
            if (!IsBorrowed) // Проверка, что материал доступен для выдачи
            {
                IsBorrowed = true; // Устанавливаем флаг "выдано"
                CurrentBorrower = borrowerId; // Запоминаем читателя
                DueDate = dueDate; // Устанавливаем дату возврата
                Console.WriteLine($"{Title} выдан читателю {borrowerId}. Вернуть до: {dueDate:dd.MM.yyyy}");
            }
            else
            {
                // Сообщение если материал уже выдан
                Console.WriteLine($"{Title} уже выдан читателю {CurrentBorrower}.");
            }
        }

        // Реализация метода возврата материала из интерфейса ILendable
        public virtual void Return()
        {
            if (IsBorrowed) // Проверка, что материал был выдан
            {
                IsBorrowed = false; // Сбрасываем флаг выдачи
                Console.WriteLine($"{Title} возвращен в библиотеку.");
                CurrentBorrower = null; // Очищаем информацию о читателе
                DueDate = null; // Сбрасываем дату возврата
            }
            else
            {
                // Сообщение если материал уже в библиотеке
                Console.WriteLine($"{Title} уже в библиотеке.");
            }
        }

        // Реализация метода проверки доступности из интерфейса ILendable
        public virtual bool IsAvailable()
        {
            return !IsBorrowed; // Материал доступен если не выдан
        }
    }
}
