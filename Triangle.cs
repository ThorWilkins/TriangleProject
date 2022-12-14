using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalFinalTriangleProject
{

    internal class Triangle
    {
        double sideA, sideB, sideC, area, perimeter;
        string triangleType;
        public Triangle()
        {

        }

        public Triangle(double sideA, double sideB, double sideC)
        {
            this.sideA = sideA;
            this.sideB = sideB;
            this.sideC = sideC;
        }

        public double SideA
        {
            get { return sideA; }
            set { sideA = value; }
        }

        public double SideB
        {
            get { return sideB; }
            set { sideB = value; }
        }

        public double SideC
        {
            get { return sideC; }
            set { sideC = value; }
        }

        public void ValidateInput()
        {
            
            double sideA;
            //Gets side A
            Console.Write("Please enter side A of your triangle:");
            while (!Double.TryParse(Console.ReadLine(), out sideA)) // Execute while input is invalid
            {
                Console.Clear();
                Console.WriteLine("That was not a number!");
                Console.Write("please enter a number for the length of side A: ");
            }

            double sideB;
            //Gets side B
            Console.Write("Please enter side B of your triangle:");
            while (!Double.TryParse(Console.ReadLine(), out sideB)) // Execute while input is invalid
            {
                Console.Clear();
                Console.WriteLine("That was not a number!");
                Console.Write("please enter a number for the length of side B:");
            }

            double sideC;
            //Gets side C
            Console.Write("Please enter side C of your triangle:");
            while (!Double.TryParse(Console.ReadLine(), out sideC)) // Execute while input is invalid
            {
                Console.Clear();
                Console.WriteLine("That was not a number!");
                Console.Write("please enter a number for the length of side C:");
            }

            this.sideC = sideC;
            this.sideB = sideB;
            this.sideA = sideA;
        }

        //Checks if the triangle is valid based on the triangle inequality theorem
        public bool IsValidTriangle()
        {
            bool isValid = false;
            if (sideA > 0 && sideB > 0 && sideC > 0)
            {

                //Checks if the triangle is valid based on the Triangle Inequality Theorem  
                if (sideA + sideB > sideC && sideA + sideC > sideB && sideB + sideC > sideA)
                {
                    isValid = true;
                }
                else
                {

                    isValid = false;

                }
                
            }

            return isValid;
        }

        //calculates the area
        public double CalculatePerimeter()
        {
            double perimeter = sideA + sideB + sideC;

            this.perimeter = perimeter;
            return perimeter;
        }

        //calculates the perimeter
        public double CalculateArea()
        {
            double semiPerimeter = perimeter / 2;
            double areaOfTriangle = Math.Sqrt(semiPerimeter * (semiPerimeter - this.sideA) * (semiPerimeter - this.sideB) * (semiPerimeter - this.sideC));

            this.area = areaOfTriangle;
            return areaOfTriangle;
        }

        //Classifies what type of triangle was entered
        public string ClassifyTriangle()
        {
            string triangleType;
            //Checks if the triangle is Equilateral
            if (this.sideA == this.sideB && this.sideB == this.sideC)
            {
                triangleType = "Equilateral";
            }
            //Checkcs if the triangle is Isosceles
            else if (this.sideA == this.sideB || this.sideA == sideC || this.sideB == this.sideC)
            {
                triangleType = "Isosceles";
            }
            //If its neither of those you can use logic to know that it has to be Scalene
            else
            {
                triangleType = "Scalene";
            }

            this.triangleType = triangleType;
            return triangleType;
        }

        
        public void DisplayTriangle()
        {
            string fileName = "text.txt";
            //Command that gets the current date
            DateTime today = DateTime.Today;
            ClassifyTriangle();
            CalculatePerimeter();
            CalculateArea();
            string[] triangleInformation = new String[4];
            triangleInformation[0] = $"This triangle was made {today.ToString("dd/MM/yyyy")}";
            triangleInformation[1] = $"Ths sides of the triangle are the following A = {sideA} B = {sideB} C = {sideC}";
            triangleInformation[2] = $"The perimeter of this triangle is {perimeter.ToString("0.##")} and the area is {area.ToString("0.##")}";
            triangleInformation[3] = $"This triangle is {triangleType}";
            File.WriteAllLines(fileName, triangleInformation);
        }

        public void ReadFile()
        {
            string fileName = "text.txt";
            string[] lines = File.ReadAllLines(fileName);
            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }
        }
    }
}
