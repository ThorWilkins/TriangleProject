using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Policy;
using System.Reflection.Emit;

namespace FinalFinalTriangleProject
{

    

    internal class Program
    {
        

        static void Main(string[] args)
        {
            Console.Title = "Triangle Program";
            Triangle triangle = null;

            bool isValid;
            string fileName = "TriangleInformation.txt";
            


            //Welcomes the user
            Console.WriteLine("Welcome to my triangle program!");
            //Instructs the user about what the program will do
            Console.WriteLine("This program will do many things like show you what type of triangle the sides you entered created.");
            //Using a blank statement to create a line gap
            Console.WriteLine("");


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
                        do
                        {
                            triangle.ValidateInput();
                            isValid = triangle.IsValidTriangle();
                        }
                        while (!isValid);
                        break;
                    case 2:
                        Console.Clear();
                        if (triangle != null)
                        {
                            Console.WriteLine($"The perimeter of this triangle is {triangle.CalculatePerimeter()} and the area is {triangle.CalculateArea()}");
                        }
                        else
                        {
                            Console.WriteLine("You dont have a triangle please create a triangle!");
                        }
                        break;
                    case 3:
                        Console.Clear();
                        if (triangle != null)
                        {
                            Console.WriteLine($"This triangle is {triangle.ClassifyTriangle()}");
                        }
                        else
                        {
                            Console.WriteLine("You dont have a triangle please create a triangle!");
                        }
                        break;
                    case 4:
                        Console.Clear();
                        triangle = new Triangle();
                        break;
                    case 5:
                        using (StreamWriter sWriter = File.AppendText(fileName))
                        {
                            if (triangle != null)
                            {
                                DateTime today = DateTime.Now;
                                sWriter.WriteLine($"This triangle was made {today.ToString("dd/MM/yyyy")}");
                                sWriter.WriteLine($"The three sides of the triangle are the following A = {triangle.SideA} B = {triangle.SideB} C = {triangle.SideC}");
                                sWriter.WriteLine($"This triangle is {triangle.ClassifyTriangle()}");
                                sWriter.WriteLine($"The perimeter of this triangle is {triangle.CalculatePerimeter()} and the area is {triangle.CalculateArea()}");
                                sWriter.WriteLine("These calculations were done in The Triangle Program");
                                sWriter.Close(); // Close the file
                            }
                            else
                            {
                                Console.WriteLine("You dont have a triangle please create a triangle!");
                            }
                        }
                        break;
                    case 6:
                        using (StreamReader readText = new StreamReader(fileName))
                        {
                            string text = readText.ReadToEnd();
                            Console.WriteLine(text);
                        }
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
