using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Triangle : Figure
    {
        public double A {  get; set; }
        public double B { get; set; }
        public double C { get; set; }
    }
    public Triangle(string color, string name, double a, double b, double c)
    {
            Color = color;
            Name = name;
            A = a;
            B = b;
            C = c;
    }
    public override double GetArea()
    {
        double s = (A + B + C) / 2;
        return Math.Sqrt(s * (s - A) * (s - B) * (s - C));
    }
    public override double GetPerimeter()
    {
        return A + B + C;     
    }
     
}
