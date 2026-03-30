using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Rectangle : Figure
    {
        public double Width { get; set; }
        public double Height { get; set; }
        public Rectangle(string color, string name, double width, double height)
        {
            Color = color;
            Name = name;
            Width = width;
            Height = height;
        }
        public override double GetArea()
        {
            return (Width * Height);
        }
        public override double GetPerimeter()
        {
            return 2 * (Width * Height);
        }
        public override string GetInfo()
        {
            return $"{base.GetInfo()}, Ширина - {Width}, Высота - {Height}, Площадь - {GetArea()}, Периметр - {GetPerimeter()},";
        }
    }
}
