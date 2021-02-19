using System;
using System.Numerics;
using System.Collections.Generic;
using Shapelibrary;
using System.Linq;
using System.Text.RegularExpressions;


namespace Lab2Csharp
{
    class Program
    {
        static void GenerateRandom()
        {
            
            List<Shape> shapes = new List<Shape>();


            for (int i = 0; i< 20; i++)
            {
                shapes.Add(Shape.GenerateShape());
            }
            float allTriangleCircumference = 0;
            float sumAreaAllShape = 0;
            float avgArea = 0;
            float biggestVolume = 0;
            
            foreach (Shape shape in shapes)
            {
                Console.WriteLine(shape);

                if (shape is Triangle)
                {
                    var triangle = shape as Triangle;
                    allTriangleCircumference += triangle.Circumference;
                }
                sumAreaAllShape += shape.Area;

            }

            biggestVolume = shapes.OfType<Shape3D>().Select(shape => shape.Volume).Max();
            avgArea = sumAreaAllShape / shapes.Count;

            Console.WriteLine($"\n---------------------------------------------------------");
            Console.WriteLine($"\nThe sum of the circumference of all the triangles is: { allTriangleCircumference:F1}");
            Console.WriteLine($"The average area of all shapes is: {avgArea:F1}");
            Console.WriteLine($"The biggest Volume of all the 3D shapes is: {biggestVolume:F1}");
            Console.WriteLine($"\n---------------------------------------------------------");
           
            Triangle t = new Triangle(Vector2.Zero, Vector2.One, new Vector2(2.0f, .5f));
            foreach(Vector2 v in t)
            {
                Console.WriteLine(v);
            }
        }
        static void GenerateRandomWithMidpoint()
        {
            List<Shape> shapes = new List<Shape>();

            string x, y, z;
            Console.WriteLine("Enter a number between (-1000) - 1000");
            Console.Write("Enter a number for X:");
            x = UserMidpoint();
            Console.Write("Enter a number for Y:");
            y = UserMidpoint();
            Console.Write("Enter a number for Z:");
            z = UserMidpoint();
            Console.Clear();

            Console.WriteLine($"The midpoint for the 2d shape will be @({x}, {y}, {z})\n");

            for (int i = 0; i < 20; i++)
            {
                shapes.Add(Shape.GenerateShape2(new Vector3((float)Convert.ToDouble(x), (float)Convert.ToDouble(y), (float)Convert.ToDouble(z))));
            }
            float allTriangleCircumference = 0;
            float sumAreaAllShape = 0;
            float avgArea = 0;
            float biggestVolume = 0;

            foreach (Shape shape in shapes)
            {
                Console.WriteLine(shape);

                if (shape is Triangle)
                {
                    var triangle = shape as Triangle;
                    allTriangleCircumference += triangle.Circumference;
                }
                sumAreaAllShape += shape.Area;

            }

            biggestVolume = shapes.OfType<Shape3D>().Select(shape => shape.Volume).Max();
            avgArea = sumAreaAllShape / shapes.Count;

            Console.WriteLine($"\n---------------------------------------------------------");
            Console.WriteLine($"\nThe sum of the circumference of all the triangles is: { allTriangleCircumference:F1}");
            Console.WriteLine($"The average area of all shapes is: {avgArea:F1}");
            Console.WriteLine($"The biggest Volume of all the 3D shapes is: {biggestVolume:F1}");
            Console.WriteLine($"\n---------------------------------------------------------");
            
            Triangle t = new Triangle(Vector2.Zero, Vector2.One, new Vector2(2.0f, .5f));
            foreach (Vector2 v in t)
            {
                Console.WriteLine(v);
            }
        }
        static int UserAnswer()
        {
            int answer;
            const int maxlength = 2;
            string choice;
            do
            {
                Console.Clear();
                Console.WriteLine("In this program you have 2 choices");
                Console.WriteLine("(0): generate 20 random shapes");
                Console.WriteLine("(1): generate 20 random shapes but you chose the midpoint for the 2D shapes");
                choice = Console.ReadLine();

                var checking = new Regex("^[0-1]");

                if (checking.IsMatch(choice))
                {
                    if(choice.Length< maxlength)
                    {
                        answer = Convert.ToInt32(choice);
                        break;
                    }
                }

            } while (true);
            return answer;

        }
        static string UserMidpoint()
        {
            float choice;
            do
            {
                while (!float.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("You entered an invalid number");
                    Console.Write("Try again!: ");
                }
                if (choice <= 1000 && choice >= -1000)
                {
                    break;
                }
                Console.Write("Try again!: ");
            } while (true);
           
            return Convert.ToString(choice);
        }
        static void Main(string[] args)
        {
            int temp = 1;
            do
            {
                switch (UserAnswer())
                {
                    case 0:
                        Console.Clear();
                        GenerateRandom();
                        temp = 0;
                        break;
                    case 1:
                        Console.Clear();
                        GenerateRandomWithMidpoint();
                        temp = 0;
                        break;
                    default:
                        Console.WriteLine("\nChose between 0 and 1\n");
                        break;
                }
            } while (temp == 1);
        }
    }
}
