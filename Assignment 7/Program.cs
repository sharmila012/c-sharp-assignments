using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_7
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("**** Question 1 Output ****");
            //question1();
            //Console.WriteLine("**** Question 2 Output ****");
            //question2();
            //Console.WriteLine("**** Question 3 Output ****");
            //question3();
            Console.WriteLine("**** Question 4 Output ****");
            question4();
            Console.ReadLine();
        }
        public static void question1()
        {
            Console.Write("Enter the size of the list : ");
            int count = int.Parse(Console.ReadLine());
            List<int> numbers = new List<int>();
            for (int i = 0; i < count; i++)
            {
                Console.Write($"Enter number {i + 1}: ");
                int num = int.Parse(Console.ReadLine());
                numbers.Add(num);
            }
            Console.WriteLine("\nNumbers and their squares (only if square > 20) :");
            foreach (int number in numbers)
            {
                int square = number * number;
                if (square > 20)
                {
                    Console.WriteLine($"The square of {number} is {square}");
                }
            }
        }
        public static void question2()
        {
            List<string> words = new List<string>();
            Console.Write("Enter the size of the list : ");
            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                Console.Write($"Enter word {i + 1}: ");
                string word = Console.ReadLine().ToLower();
                words.Add(word);
            }
            Console.WriteLine("\nWords starting with 'a' and ending with 'm':");
            foreach (string word in words)
            {
                if (word.StartsWith("a") && word.EndsWith("m"))
                {
                    Console.WriteLine(word);
                }
            }
        }
        public static void question3()
        {
            List<Employee> employees = new List<Employee>();
            Console.Write("Enter number of employees: ");
            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"\nEnter details for Employee {i + 1} :");
                Console.Write("Employee Id : ");
                int id = int.Parse(Console.ReadLine());
                Console.Write("Employee Name : ");
                string name = Console.ReadLine();
                Console.Write("Employee City : ");
                string city = Console.ReadLine();
                Console.Write("Employee Salary : ");
                double salary = double.Parse(Console.ReadLine());
                employees.Add(new Employee { EmpId = id, EmpName = name, EmpCity = city, EmpSalary = salary });
            }
            Console.WriteLine("\n(a) All Employees :");
            foreach (var emp in employees)
                emp.Display();
            Console.WriteLine("\n(b) Employees with Salary > 45000 :");
            foreach (var emp in employees.Where(e => e.EmpSalary > 45000))
                emp.Display();
            Console.WriteLine("\n(c) Employees from Bangalore :");
            foreach (var emp in employees.Where(e => e.EmpCity.Equals("Bangalore", StringComparison.OrdinalIgnoreCase)))
                emp.Display();
            Console.WriteLine("\n(d) Employees sorted by Name (Ascending) :");
            foreach (var emp in employees.OrderBy(e => e.EmpName))
                emp.Display();
        }
        public static void question4()
        {
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();
            Console.Write("Enter your age: ");
            int age = int.Parse(Console.ReadLine());
            string result = Program_2.CalculateConcession(age);
            Console.WriteLine($"\nHello {name}, {result}");
        }
    }
    class Employee //question 3
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public string EmpCity { get; set; }
        public double EmpSalary { get; set; }
        public void Display()
        {
            Console.WriteLine($"ID: {EmpId}, Name: {EmpName}, City: {EmpCity}, Salary: {EmpSalary}");
        }
    }
    class Program_2 //question 4
    {
        const double TotalFare = 500.0;
        public static string CalculateConcession(int age)
        {
            if (age <= 5)
            {
                return "Little Champs - Free Ticket";
            }
            else if (age > 60)
            {
                double concessionFare = TotalFare * 0.7; // 30% discount
                return $"Senior Citizen - Fare after concession: {concessionFare}";
            }
            else
            {
                return $"Ticket Booked - Fare: {TotalFare}";
            }
        }
    }
}
