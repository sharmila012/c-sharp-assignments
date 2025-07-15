using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Challenge_2
{
    class Program
    {
        static void Main(string[] args)
        {
            question1();
            Console.WriteLine("----------------------------");
            question2();
            Console.WriteLine("----------------------------");
            question3();
            Console.WriteLine("----------------------------");
            Console.ReadLine();
        }
        public static void question1()
        {
            Console.WriteLine("**** Question 1 ****");
            Console.Write("Enter Student Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Student ID: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Grade: ");
            double grade = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter Student Type (UG for Undergraduate / G for Graduate): ");
            string type = Console.ReadLine();
            Student student;
            if (type.ToUpper() == "UG")
            {
                student = new UnderGraduate(name, id, grade);
            }
            else if (type.ToUpper() == "G")
            {
                student = new Graduate(name, id, grade);
            }
            else
            {
                Console.WriteLine("Invalid student type.");
                return;
            }
            Console.WriteLine($"\nStudent Name: {student.Name}");
            Console.WriteLine($"Student ID: {student.StudentId}");
            Console.WriteLine($"Grade: {student.Grade}");
            Console.WriteLine($"Passed: {student.IsPassed(student.Grade)}");
        }
        public static void question2()
        {
            Console.WriteLine("**** Question 2 ****");
            List<Products> productList = new List<Products>();
            Console.WriteLine("Enter details for 10 products:\n");
            for (int i = 0; i < 10; i++)
            {
                Console.Write($"Enter Product ID for product {i + 1}: ");
                int id = Convert.ToInt32(Console.ReadLine());
                Console.Write($"Enter Product Name for product {i + 1}: ");
                string name = Console.ReadLine();
                Console.Write($"Enter Price for product {i + 1}: ");
                double price = Convert.ToDouble(Console.ReadLine());
                productList.Add(new Products(id, name, price));
                Console.WriteLine();
            }           
            var sortedProducts = productList.OrderBy(p => p.Price).ToList();
            Console.WriteLine("\nSorted Products by Price in ascending order :\n");
            foreach (var product in sortedProducts)
            {
                product.Display();
            }
        }
        public static void question3()
        {
            Console.WriteLine("\n**** Question 2 ****");
            try
            {
                Console.Write("Enter an integer: ");
                int input = Convert.ToInt32(Console.ReadLine());
                CheckNumber(input);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input type. Please enter a valid integer.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }
        }
        static void CheckNumber(int number) //question 3
        {
            if (number < 0)
            {
                throw new ArgumentException("Number cannot be negative. Try again!!");
            }
            else if(number == 0)
            {
                Console.WriteLine("Zero is neither positive nor negative");
            }
            else
            {
                Console.WriteLine($"You entered a valid number: {number}");
            }
        }
    }
    public abstract class Student //question 1
    {
        public string Name { get; set; }
        public int StudentId { get; set; }
        public double Grade { get; set; }
        public Student(string name, int studentId, double grade)
        {
            Name = name;
            StudentId = studentId;
            Grade = grade;
        }
        public abstract bool IsPassed(double grade);
    }
    public class UnderGraduate : Student
    {
        public UnderGraduate(string name, int studentId, double grade)
            : base(name, studentId, grade) { }
        public override bool IsPassed(double grade)
        {
            return grade > 70.0;
        }
    }
    public class Graduate : Student
    {
        public Graduate(string name, int studentId, double grade)
            : base(name,studentId, grade) { }
        public override bool IsPassed(double grade)
        {
            return grade > 80.0;
        }
    }

    public class Products //question 2
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public Products(int productId, string productName, double price)
        {
            ProductId = productId;
            ProductName = productName;
            Price = price;
        }
        public void Display()
        {
            Console.WriteLine($"Product ID: {ProductId}, Name: {ProductName}, Price: Rs.{Price}");
        }
    }
}
