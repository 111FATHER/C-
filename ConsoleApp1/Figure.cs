using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public abstract class Figure
    {
        public string Color { get; set; }
        public string Name { get; set; }
        public abstract double GetArea();
        public abstract double GetPerimeter();
        public virtual string GetInfo()
        {
            return $"Цвет - {Color}, Имя - {Name}";
        }
        public static bool operator >(Figure left, Figure right)
        {
            return left.GetArea() > right.GetArea();
        }
        public static bool operator <(Figure left, Figure right)
        {
            return left.GetArea() > right.GetArea();
        }
        public static double operator +(Figure left, Figure right)
        {
            return left.GetPerimeter() + right.GetPerimeter();
        }
        public static bool operator ==(Figure left, Figure right)
        {
            if (left.GetPerimeter() == right.GetPerimeter())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool operator !=(Figure left, Figure right)
        {
            return !(left == right);
        }
    }
}
