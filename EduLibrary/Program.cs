using System;

namespace UniversityLibrary
{
    class Program
    {
        // Зависимости для работы программы
        private static ILibraryService _libraryService; // Сервис библиотечных операций
        private static IItemRepository _itemRepository; // Репозиторий для хранения данных

        static void Main(string[] args)
        {
            // Инициализация зависимостей (простая реализация без DI-контейнера)
            _itemRepository = new ItemRepository(); // Создаем репозиторий
            _libraryService = new LibraryService(_itemRepository); // Создаем сервис с передачей репозитория

            InitializeLibraryData(); // Заполняем библиотеку начальными данными
            bool exit = false; // Флаг для выхода из программы

            // Главный цикл программы - отображает меню до выбора выхода
            while (!exit)
            {
                DisplayMenu(); // Показываем меню пользователю
                string choice = Console.ReadLine(); // Читаем выбор пользователя

                // Обработка выбора пользователя из меню
                switch (choice)
                {
                    case "1": _libraryService.DisplayAllItems(); break; // Полный каталог
                    case "2": _libraryService.DisplayAvailableItems(); break; // Доступные материалы
                    case "3": _libraryService.DisplayBorrowedItems(); break; // Выданные материалы
                    case "4": SearchByAuthor(); break; // Поиск по автору
                    case "5": SearchByTitle(); break; // Поиск по названию
                    case "6": AddNewBook(); break; // Добавление художественной литературы
                    case "7": AddNewTextbook(); break; // Добавление учебного пособия
                    case "8": AddNewReference(); break; // Добавление справочной литературы
                    case "9": LendItem(); break; // Выдача материала читателю
                    case "10": ReturnItem(); break; // Возврат материала в библиотеку
                    case "11": RemoveItem(); break; // Удаление материала из каталога
                    case "12": _libraryService.DisplayStatistics(); break; // Общая статистика библиотеки
                    case "0": exit = true; Console.WriteLine("До свидания!"); break; // Завершение работы
                    default: Console.WriteLine("Неверный выбор. Попробуйте снова."); break; // Неправильный ввод
                }

                // Пауза для просмотра результатов перед возвратом в меню
                if (!exit)
                {
                    Console.WriteLine("\nНажмите любую клавишу для продолжения...");
                    Console.ReadKey(); // Ожидание нажатия любой клавиши
                }
            }
        }

        // Отображение основного меню управления библиотекой
        static void DisplayMenu()
        {
            Console.Clear(); // Очистка консоли перед выводом меню
            Console.WriteLine("БИБЛИОТЕКА УНИВЕРСИТЕТА");
            Console.WriteLine("1. Показать все материалы"); // Просмотр полного каталога
            Console.WriteLine("2. Показать доступные материалы"); // Фильтр по доступности
            Console.WriteLine("3. Показать выданные материалы"); // Фильтр по статусу "выдано"
            Console.WriteLine("4. Поиск по автору"); // Поиск по имени автора
            Console.WriteLine("5. Поиск по названию"); // Поиск по названию материала
            Console.WriteLine("6. Добавить книгу"); // Добавление художественной литературы
            Console.WriteLine("7. Добавить учебник"); // Добавление учебного пособия
            Console.WriteLine("8. Добавить справочник"); // Добавление справочной литературы
            Console.WriteLine("9. Выдать материал"); // Операция выдачи читателю
            Console.WriteLine("10. Вернуть материал"); // Операция возврата в библиотеку
            Console.WriteLine("11. Удалить материал"); // Удаление из каталога
            Console.WriteLine("12. Статистика библиотеки"); // Аналитика по коллекции
            Console.WriteLine("0. Выход"); // Завершение работы программы
            Console.Write("Выберите действие: "); // Приглашение к вводу
        }

        // Заполнение библиотеки начальными данными для демонстрации
        static void InitializeLibraryData()
        {
            // Создание демонстрационных экземпляров различных типов материалов
            Book book1 = new Book("Мастер и Маргарита", "Михаил Булгаков", 1967, "B001", "978-5-389-12345-1", 480);
            Book book2 = new Book("1984", "Джордж Оруэлл", 1949, "B002", "978-5-389-12345-2", 328);
            Textbook textbook1 = new Textbook("Основы программирования на C#", "Иванов А.В.", 2023, "T001", "978-5-389-12345-6", 420, "Информатика");
            Textbook textbook2 = new Textbook("Высшая математика", "Сидоров П.С.", 2022, "T002", "978-5-389-12345-7", 560, "Математика");
            Reference reference1 = new Reference("Справочник по математике", "Лебедев А.Н.", 2021, "R001", "978-5-389-12346-1", 620, "Математика");
            Reference reference2 = new Reference("Физический словарь", "Фролов И.П.", 2020, "R002", "978-5-389-12346-2", 780, "Физика");

            // Добавление созданных материалов в коллекцию библиотеки через репозиторий
            _itemRepository.Add(book1);
            _itemRepository.Add(book2);
            _itemRepository.Add(textbook1);
            _itemRepository.Add(textbook2);
            _itemRepository.Add(reference1);
            _itemRepository.Add(reference2);
        }

        // Вспомогательный метод для поиска материалов по автору
        static void SearchByAuthor()
        {
            Console.Write("Введите имя автора для поиска: ");
            string author = Console.ReadLine(); // Чтение запроса пользователя
            _libraryService.SearchByAuthor(author); // Вызов сервиса для выполнения поиска
        }

        // Вспомогательный метод для поиска материалов по названию
        static void SearchByTitle()
        {
            Console.Write("Введите название для поиска: ");
            string title = Console.ReadLine(); // Чтение запроса пользователя
            _libraryService.SearchByTitle(title); // Вызов сервиса для выполнения поиска
        }

        // Добавление новой книги в коллекцию библиотеки
        static void AddNewBook()
        {
            try
            {
                Console.WriteLine("Добавление новой книги:");
                Console.Write("Название: "); string title = Console.ReadLine();
                Console.Write("Автор: "); string author = Console.ReadLine();
                Console.Write("Год: "); int year = int.Parse(Console.ReadLine());
                Console.Write("ID: "); string itemId = Console.ReadLine();
                Console.Write("ISBN: "); string isbn = Console.ReadLine();
                Console.Write("Страниц: "); int pages = int.Parse(Console.ReadLine());

                // Создание нового экземпляра книги
                Book newBook = new Book(title, author, year, itemId, isbn, pages);
                _itemRepository.Add(newBook); // Добавление через репозиторий
                Console.WriteLine("Книга успешно добавлена!");
            }
            catch (Exception ex) // Обработка возможных ошибок ввода
            {
                Console.WriteLine($"Ошибка при добавлении книги: {ex.Message}");
            }
        }

        // Добавление нового учебника с указанием учебного курса
        static void AddNewTextbook()
        {
            try
            {
                Console.WriteLine("Добавление нового учебника:");
                Console.Write("Название: "); string title = Console.ReadLine();
                Console.Write("Автор: "); string author = Console.ReadLine();
                Console.Write("Год: "); int year = int.Parse(Console.ReadLine());
                Console.Write("ID: "); string itemId = Console.ReadLine();
                Console.Write("ISBN: "); string isbn = Console.ReadLine();
                Console.Write("Страниц: "); int pages = int.Parse(Console.ReadLine());
                Console.Write("Курс: "); string course = Console.ReadLine();

                // Создание нового экземпляра учебника
                Textbook newTextbook = new Textbook(title, author, year, itemId, isbn, pages, course);
                _itemRepository.Add(newTextbook); // Добавление через репозиторий
                Console.WriteLine("Учебник успешно добавлен!");
            }
            catch (Exception ex) // Обработка возможных ошибок ввода
            {
                Console.WriteLine($"Ошибка при добавлении учебника: {ex.Message}");
            }
        }

        // Добавление нового справочника с указанием предметной области
        static void AddNewReference()
        {
            try
            {
                Console.WriteLine("Добавление нового справочника:");
                Console.Write("Название: "); string title = Console.ReadLine();
                Console.Write("Автор: "); string author = Console.ReadLine();
                Console.Write("Год: "); int year = int.Parse(Console.ReadLine());
                Console.Write("ID: "); string itemId = Console.ReadLine();
                Console.Write("ISBN: "); string isbn = Console.ReadLine();
                Console.Write("Страниц: "); int pages = int.Parse(Console.ReadLine());
                Console.Write("Предмет: "); string subject = Console.ReadLine();

                // Создание нового экземпляра справочника
                Reference newReference = new Reference(title, author, year, itemId, isbn, pages, subject);
                _itemRepository.Add(newReference); // Добавление через репозиторий
                Console.WriteLine("Справочник успешно добавлен!");
            }
            catch (Exception ex) // Обработка возможных ошибок ввода
            {
                Console.WriteLine($"Ошибка при добавлении справочника: {ex.Message}");
            }
        }

        // Операция выдачи материала читателю с установкой срока возврата
        static void LendItem()
        {
            Console.Write("Введите ID материала для выдачи: ");
            string itemId = Console.ReadLine(); // Чтение ID материала
            Console.Write("Введите ID читателя: ");
            string borrowerId = Console.ReadLine(); // Чтение ID читателя
            Console.Write("Введите количество дней на выдачу: ");
            int days = int.Parse(Console.ReadLine()); // Чтение срока выдачи

            // Вызов сервиса для выполнения операции выдачи
            _libraryService.LendItem(itemId, borrowerId, DateTime.Now.AddDays(days));
        }

        // Операция возврата материала в библиотеку
        static void ReturnItem()
        {
            Console.Write("Введите ID материала для возврата: ");
            string itemId = Console.ReadLine(); // Чтение ID материала
            _libraryService.ReturnItem(itemId); // Вызов сервиса для выполнения возврата
        }

        // Удаление материала из каталога библиотеки по идентификатору
        static void RemoveItem()
        {
            Console.Write("Введите ID материала для удаления: ");
            string itemId = Console.ReadLine(); // Чтение ID материала
            _itemRepository.Remove(itemId); // Вызов репозитория для удаления
        }
    }
}
