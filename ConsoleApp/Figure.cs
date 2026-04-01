using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public abstract class Figure : ICostable
    {
        public string Color { get; set; }
        public string Name { get; set; }

        public abstract double GetArea();
        public abstract double GetPerimeter();

        public virtual string GetInfo()
        {
            return $"Цвет - {Color}, Имя - {Name}";
        }

        public double CalculateMaterialCost(double pricePerUnit)
        {
            return GetArea() * pricePerUnit;
        }

        public static bool operator >(Figure left, Figure right)
        {
            if (left is null || right is null) return false;
            return left.GetArea() > right.GetArea();
        }

        public static bool operator <(Figure left, Figure right)
        {
            if (left is null || right is null) return false;
            return left.GetArea() < right.GetArea();
        }

        public static double operator +(Figure left, Figure right)
        {
            if (left is null || right is null) return 0;
            return left.GetPerimeter() + right.GetPerimeter();
        }

        public static bool operator ==(Figure left, Figure right)
        {
            if (left is null && right is null) return true;
            if (left is null || right is null) return false;
            return Math.Abs(left.GetArea() - right.GetArea()) < 0.01;
        }

        public static bool operator !=(Figure left, Figure right)
        {
            return !(left == right);
        }
    }
}
