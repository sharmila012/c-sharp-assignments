using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_challenge_1
{
    class Program
    {
        static void Main(string[] args)
        {
            question1();
            Console.WriteLine("_______________________");
            question2();
            Console.WriteLine("_______________________");
            question3();
            Console.ReadLine();
        }
        static void question1()
        {
            Console.Write("Enter a string: ");
            string input = Console.ReadLine();
            Console.Write("Enter the position to remove (0 to " + (input.Length - 1) + "): ");
            int position = Convert.ToInt32(Console.ReadLine());
            if (position >= 0 && position < input.Length)
            {
                string result = input.Remove(position, 1);
                Console.WriteLine("Result: " + result);
            }
            else
            {
                Console.WriteLine("Invalid position.");
            }
        }
        static void question2()
        {
            Console.Write("Enter a string: ");
            string input = Console.ReadLine();
            string result = SwapFirstLast(input);
            Console.WriteLine("Result: " + result);
        }
        static string SwapFirstLast(string str)
        {
            if (str.Length <= 1)
                return str;
            char first = str[0];
            char last = str[str.Length - 1];
            string middle = str.Substring(1, str.Length - 2);
            return last + middle + first;
        }
        static void question3()
        {
            Console.Write("Enter first number: ");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter second number: ");
            int b = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter third number: ");
            int c = Convert.ToInt32(Console.ReadLine());
            int largest = (a > b) ? ((a > c) ? a : c) : ((b > c) ? b : c);
            Console.WriteLine("Largest number is: " + largest);
        }
    }
}
