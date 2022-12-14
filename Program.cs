using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Policy;

namespace FinalFinalTriangleProject
{

    

    internal class Program
    {
        

        static void Main(string[] args)
        {
            Triangle triangle = new Triangle();

            //Welcomes the user
            Console.WriteLine("Welcome to my triangle program!");
            //Instructs the user about what the program will do
            Console.WriteLine("This program will do many things like show you what type of triangle the sides you entered created.");
            //Using a blank statement to create a line gap
            Console.WriteLine("");

            if(triangle.SideA == 0 || triangle.SideB == 0 || triangle.SideC == 0)
            {
                Console.WriteLine("automatically creating a new triangle since you dont have one already");
                triangle.ValidateInput();
            }

            do
            {
                //Displays the menu of things the program can do
                Console.WriteLine("Heres a menu of the things you can do");
                string menuString = string.Format((" 1. Create a new triangle.\n 2. Display area and perimeter.\n 3. Classify triangle.\n 4. Reset triangle.\n 5. Save triangle to file.\n 6. Display file.\n 7. Exit"));
                Console.WriteLine(menuString);

                //Allows the user to select what they would like to do
                Console.Write("Please select the number corresponding with what you would like to do:");

                int userSelection = 0;
                //Gets the input from the user and checks if its valid if not makes them select again
                while (!int.TryParse(Console.ReadLine(), out userSelection)) // Execute while input is invalid
                {
                    Console.Clear();
                    Console.WriteLine("That was not a number!");
                    Console.Write("please enter a number that corresponds with the thing you would like to do: ");
                }

                

                switch (userSelection)
                {
                    case 1:
                        triangle = new Triangle();
                        Console.Clear();
                        triangle.ValidateInput();
                        break;
                    case 2:
                        Console.Clear();
                        if (triangle.SideA != 0 || triangle.SideB != 0 || triangle.SideC != 0)
                        {
                            Console.WriteLine($"The perimeter of this triangle is {triangle.CalculatePerimeter()} and the area is {triangle.CalculateArea()}");
                        }
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine($"This triangle is {triangle.ClassifyTriangle()}");
                        break;
                    case 4:
                        Console.Clear();
                        triangle = new Triangle();
                        break;
                    case 5:
                        triangle.DisplayTriangle();
                        Console.Clear();
                        break;
                    case 6:
                        Console.Clear();
                        triangle.ReadFile();
                        break;
                    case 7:
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }
            }
            while (true);
        }
    }
}
