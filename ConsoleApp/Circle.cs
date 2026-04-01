using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Circle : Figure
    {
        public double Radius { get; set; }

        public Circle(string color, string name, double radius)
        {
            Color = color;
            Name = name;
            Radius = radius;
        }

        public override double GetArea()
        {
            return Math.PI * Radius * Radius;
        }

        public override double GetPerimeter()
        {
            return 2 * Math.PI * Radius;
        }

        public override string GetInfo()
        {
            return $"{base.GetInfo()}, Радиус - {Radius:F2}, Площадь - {GetArea():F2}, Периметр - {GetPerimeter():F2}";
        }
    }
}

