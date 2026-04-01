using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class FigureStorage
    {
        private Figure[] _figures;

        // Конструктор: инициализирует массив фиксированным размером (10 элементов)
        public FigureStorage()
        {
            _figures = new Figure[10];
        }

        // Метод AddFigure: добавляет фигуру в первую свободную ячейку
        public void AddFigure(Figure f)
        {
            for (int i = 0; i < _figures.Length; i++)
            {
                if (_figures[i] == null)
                {
                    _figures[i] = f;
                    Console.WriteLine("Фигура успешно добавлена!");
                    return;
                }
            }
            Console.WriteLine("Ошибка: Хранилище заполнено! Нельзя добавить новую фигуру.");
        }

        // Метод GetAll: возвращает массив всех добавленных фигур (без null элементов)
        public Figure[] GetAll()
        {
            // Считаем количество не-null элементов
            int count = 0;
            for (int i = 0; i < _figures.Length; i++)
            {
                if (_figures[i] != null)
                {
                    count++;
                }
            }

            // Создаем массив нужного размера и заполняем
            Figure[] result = new Figure[count];
            int index = 0;
            for (int i = 0; i < _figures.Length; i++)
            {
                if (_figures[i] != null)
                {
                    result[index] = _figures[i];
                    index++;
                }
            }
            return result;
        }

        // Метод GetTotalArea: считает суммарную площадь всех фигур
        public double GetTotalArea()
        {
            double total = 0;
            for (int i = 0; i < _figures.Length; i++)
            {
                if (_figures[i] != null)
                {
                    total += _figures[i].GetArea();
                }
            }
            return total;
        }
    }
}
