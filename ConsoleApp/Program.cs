namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            FigureStorage storage = new FigureStorage();

            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("========================================");
                Console.WriteLine("     Добро пожаловать в GeoCalc Pro");
                Console.WriteLine("========================================");
                Console.WriteLine("1. Добавить фигуру");
                Console.WriteLine("2. Показать все фигуры");
                Console.WriteLine("3. Сравнить две фигуры");
                Console.WriteLine("4. Посчитать стоимость материалов");
                Console.WriteLine("5. Общая площадь всех фигур");
                Console.WriteLine("6. Выход");
                Console.WriteLine("========================================");
                Console.Write("Выберите пункт меню: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddFigure(storage);
                        break;
                    case "2":
                        ShowAllFigures(storage);
                        break;
                    case "3":
                        CompareFigures(storage);
                        break;
                    case "4":
                        CalculateMaterialCost(storage);
                        break;
                    case "5":
                        ShowTotalArea(storage);
                        break;
                    case "6":
                        exit = true;
                        Console.WriteLine("До свидания!");
                        break;
                    default:
                        Console.WriteLine("Неверный выбор! Попробуйте снова.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void AddFigure(FigureStorage storage)
        {
            Console.Clear();
            Console.WriteLine("Добавление новой фигуры");
            Console.WriteLine("-----------------------");
            Console.WriteLine("Выберите тип фигуры:");
            Console.WriteLine("1. Круг");
            Console.WriteLine("2. Прямоугольник");
            Console.WriteLine("3. Треугольник");
            Console.Write("Ваш выбор: ");

            string type = Console.ReadLine();

            Console.Write("Введите цвет фигуры: ");
            string color = Console.ReadLine();

            Console.Write("Введите название фигуры: ");
            string name = Console.ReadLine();

            Figure figure = null;

            switch (type)
            {
                case "1":
                    Console.Write("Введите радиус: ");
                    if (double.TryParse(Console.ReadLine(), out double radius) && radius > 0)
                    {
                        figure = new Circle(color, name, radius);
                    }
                    else
                    {
                        Console.WriteLine("Ошибка: Некорректный радиус!");
                    }
                    break;

                case "2":
                    Console.Write("Введите ширину: ");
                    if (double.TryParse(Console.ReadLine(), out double width) && width > 0)
                    {
                        Console.Write("Введите высоту: ");
                        if (double.TryParse(Console.ReadLine(), out double height) && height > 0)
                        {
                            figure = new Rectangle(color, name, width, height);
                        }
                        else
                        {
                            Console.WriteLine("Ошибка: Некорректная высота!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Ошибка: Некорректная ширина!");
                    }
                    break;

                case "3":
                    Console.Write("Введите сторону A: ");
                    if (double.TryParse(Console.ReadLine(), out double a) && a > 0)
                    {
                        Console.Write("Введите сторону B: ");
                        if (double.TryParse(Console.ReadLine(), out double b) && b > 0)
                        {
                            Console.Write("Введите сторону C: ");
                            if (double.TryParse(Console.ReadLine(), out double c) && c > 0)
                            {
                                figure = new Triangle(color, name, a, b, c);
                            }
                            else
                            {
                                Console.WriteLine("Ошибка: Некорректная сторона C!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Ошибка: Некорректная сторона B!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Ошибка: Некорректная сторона A!");
                    }
                    break;

                default:
                    Console.WriteLine("Неверный тип фигуры!");
                    break;
            }

            if (figure != null)
            {
                storage.AddFigure(figure);
            }

            Console.WriteLine("\nНажмите любую клавишу для продолжения...");
            Console.ReadKey();
        }

        static void ShowAllFigures(FigureStorage storage)
        {
            Console.Clear();
            Figure[] figures = storage.GetAll();

            if (figures.Length == 0)
            {
                Console.WriteLine("В хранилище нет фигур.");
            }
            else
            {
                Console.WriteLine("Список всех фигур:");
                Console.WriteLine("==================");
                for (int i = 0; i < figures.Length; i++)
                {
                    Console.WriteLine($"[{i}] {figures[i].GetInfo()}");
                }
            }

            Console.WriteLine("\nНажмите любую клавишу для продолжения...");
            Console.ReadKey();
        }

        static void CompareFigures(FigureStorage storage)
        {
            Console.Clear();
            Figure[] figures = storage.GetAll();

            if (figures.Length < 2)
            {
                Console.WriteLine("Недостаточно фигур для сравнения (нужно минимум 2).");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Сравнение двух фигур по площади");
            Console.WriteLine("================================");

            // Показываем список фигур с индексами
            for (int i = 0; i < figures.Length; i++)
            {
                Console.WriteLine($"[{i}] {figures[i].Name} ({figures[i].GetType().Name}) - Площадь: {figures[i].GetArea():F2}");
            }

            Console.Write("\nВведите индекс первой фигуры: ");
            if (int.TryParse(Console.ReadLine(), out int index1) && index1 >= 0 && index1 < figures.Length)
            {
                Console.Write("Введите индекс второй фигуры: ");
                if (int.TryParse(Console.ReadLine(), out int index2) && index2 >= 0 && index2 < figures.Length)
                {
                    Figure fig1 = figures[index1];
                    Figure fig2 = figures[index2];

                    Console.WriteLine($"\nФигура 1: {fig1.GetInfo()}");
                    Console.WriteLine($"Фигура 2: {fig2.GetInfo()}");
                    Console.WriteLine($"\nПлощадь фигуры 1: {fig1.GetArea():F2}");
                    Console.WriteLine($"Площадь фигуры 2: {fig2.GetArea():F2}");

                    // Используем перегруженные операторы
                    if (fig1 > fig2)
                    {
                        Console.WriteLine($"\nРезультат: Фигура '{fig1.Name}' имеет большую площадь, чем '{fig2.Name}'");
                    }
                    else if (fig1 < fig2)
                    {
                        Console.WriteLine($"\nРезультат: Фигура '{fig2.Name}' имеет большую площадь, чем '{fig1.Name}'");
                    }
                    else
                    {
                        Console.WriteLine($"\nРезультат: Площади фигур равны");
                    }

                    // Демонстрация оператора + (сложение периметров)
                    double totalPerimeter = fig1 + fig2;
                    Console.WriteLine($"\nСумма периметров двух фигур: {totalPerimeter:F2}");
                }
                else
                {
                    Console.WriteLine("Неверный индекс второй фигуры!");
                }
            }
            else
            {
                Console.WriteLine("Неверный индекс первой фигуры!");
            }

            Console.WriteLine("\nНажмите любую клавишу для продолжения...");
            Console.ReadKey();
        }

        static void CalculateMaterialCost(FigureStorage storage)
        {
            Console.Clear();
            Figure[] figures = storage.GetAll();

            if (figures.Length == 0)
            {
                Console.WriteLine("В хранилище нет фигур.");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Расчет стоимости материалов");
            Console.WriteLine("===========================");

            Console.Write("Введите цену за квадратный метр: ");
            if (double.TryParse(Console.ReadLine(), out double price) && price >= 0)
            {
                Console.WriteLine("\nРезультаты расчета:");
                Console.WriteLine("-------------------");

                double totalCost = 0;

                for (int i = 0; i < figures.Length; i++)
                {
                    // Используем метод интерфейса ICostable
                    double cost = figures[i].CalculateMaterialCost(price);
                    totalCost += cost;
                    Console.WriteLine($"{figures[i].Name}: Площадь = {figures[i].GetArea():F2} м², Стоимость = {cost:F2} руб.");
                }

                Console.WriteLine($"\nОбщая стоимость всех материалов: {totalCost:F2} руб.");
            }
            else
            {
                Console.WriteLine("Ошибка: Некорректная цена!");
            }

            Console.WriteLine("\nНажмите любую клавишу для продолжения...");
            Console.ReadKey();
        }

        static void ShowTotalArea(FigureStorage storage)
        {
            Console.Clear();
            double totalArea = storage.GetTotalArea();

            Console.WriteLine("Общая площадь всех фигур");
            Console.WriteLine("========================");
            Console.WriteLine($"Общая площадь: {totalArea:F2} м²");

            Console.WriteLine("\nНажмите любую клавишу для продолжения...");
            Console.ReadKey();
        }
    }
}
