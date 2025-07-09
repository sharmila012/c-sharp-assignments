using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Challenge_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" **** Question 1 Output ****");
            question1();
            Console.WriteLine("\n **** Question 2 Output ****");
            question2();
            Console.WriteLine("\n **** Question 3 Output ****");
            question3();
            Console.WriteLine("\n **** Question 4 Output ****");
            question4();
            Console.ReadLine();
        }
        public static void question1()
        {
            try
            {
                Console.Write("Enter number of matches played: ");
                int matches = int.Parse(Console.ReadLine());
                CricketTeam team = new CricketTeam();
                var result = team.PointsCalculation(matches);
                Console.WriteLine($"\nTotal Matches: {result.MatchCount}");
                Console.WriteLine($"Total Points: {result.TotalPoints}");
                Console.WriteLine($"Average Points: {result.AveragePoints:F2}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid format. Please enter a numeric value for number of matches.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        public static void question2()
        {
            try
            {
                Console.WriteLine("Enter dimensions for Box 1:");
                Console.Write("Length: ");
                double length1 = double.Parse(Console.ReadLine());
                Console.Write("Breadth: ");
                double breadth1 = double.Parse(Console.ReadLine());
                Console.WriteLine("\nEnter dimensions for Box 2:");
                Console.Write("Length: ");
                double length2 = double.Parse(Console.ReadLine());
                Console.Write("Breadth: ");
                double breadth2 = double.Parse(Console.ReadLine());
                Box box1 = new Box(length1, breadth1);
                Box box2 = new Box(length2, breadth2);
                Box box3 = Box.Add(box1, box2);
                Console.WriteLine("\nResulting Box after addition:");
                box3.Display();
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter numeric values.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        public static void question3()
        {
            string filePath = "Question3_file.txt"; 
            Console.Write("Enter text to append to the file : ");
            string userText = Console.ReadLine();
            try
            {               
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine(userText);
                }

                Console.WriteLine($"Text successfully appended to '{filePath}'.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        public delegate int CalcDelegate(int x, int y); //question4
        public static int PerformCalc(int a, int b, CalcDelegate operation)
        {
            return operation(a,b);
        }
        public static void question4()
        {

            while (true)
            {
                try
                {
                    Console.WriteLine("\n--- Calculator Menu ---");
                    Console.WriteLine("1. Addition");
                    Console.WriteLine("2. Subtraction");
                    Console.WriteLine("3. Multiplication");
                    Console.WriteLine("4. Exit");
                    Console.Write("Choose an option (1-4): ");
                    string choice = Console.ReadLine();

                    if (choice == "4")
                    {
                        Console.WriteLine("Exiting the calculator. Goodbye!");
                        break;
                    }

                    if (choice != "1" && choice != "2" && choice != "3")
                    {
                        Console.WriteLine("Invalid option. Please choose 1, 2, 3, or 4.");
                        continue;
                    }

                    Console.Write("Enter first number: ");
                    if (!int.TryParse(Console.ReadLine(), out int num1))
                    {
                        Console.WriteLine("Invalid input. Please enter a valid integer.");
                        continue;
                    }

                    Console.Write("Enter second number: ");
                    if (!int.TryParse(Console.ReadLine(), out int num2))
                    {
                        Console.WriteLine("Invalid input. Please enter a valid integer.");
                        continue;
                    }

                    CalcDelegate operation = null;

                    switch (choice)
                    {
                        case "1":
                            operation = (x, y) => x + y;
                            Console.WriteLine($"Addition Result: {PerformCalc(num1, num2, operation)}");
                            break;
                        case "2":
                            operation = (x, y) => x - y;
                            Console.WriteLine($"Subtraction Result: {PerformCalc(num1, num2, operation)}");
                            break;
                        case "3":
                            operation = (x, y) => x * y;
                            Console.WriteLine($"Multiplication Result: {PerformCalc(num1, num2, operation)}");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                }
            }
        }
    }
    class CricketTeam
    {
        public (int MatchCount, int TotalPoints, double AveragePoints) PointsCalculation(int no_of_matches)
        {
            List<int> scores = new List<int>();
            for (int i = 0; i < no_of_matches; i++)
            {
                while (true)
                {
                    Console.Write($"Enter score for match {i + 1}: ");
                    string input = Console.ReadLine();
                    if (int.TryParse(input, out int score))
                    {
                        scores.Add(score);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a numeric score.");
                    }
                }
            }
            int total = 0;
            foreach (int score in scores)
            {
                total += score;
            }
            double average = (double)total / no_of_matches;
            return (no_of_matches, total, average);
        }
    }
    public class Box //question 2
    {
        public double Length { get; set; }
        public double Breadth { get; set; }
        public Box(double length = 0, double breadth = 0)
        {
            Length = length;
            Breadth = breadth;
        }
        public static Box Add(Box b1, Box b2)
        {
            if (b1 == null || b2 == null)
            {
                throw new ArgumentNullException("Box objects cannot be null.");
            }

            return new Box(b1.Length + b2.Length, b1.Breadth + b2.Breadth);
        }
        public void Display()
        {
            Console.WriteLine($"Length: {Length}, Breadth: {Breadth}");
        }
    }
}
