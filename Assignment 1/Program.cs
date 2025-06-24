using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1
{
    class Program
    {
        static void Main(string[] args)
        {
            question1();
            question2();
            question3();
            question4();
            question5();
            Console.ReadLine();
        }
        static void question1()
        {
            int n1, n2;
            Console.WriteLine("Enter a number : ");
            n1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter another number : ");
            n2 = Convert.ToInt32(Console.ReadLine());
            if (n1 == n2)
                Console.WriteLine($"{n1} and {n2} are equal");
            else
                Console.WriteLine($"{n1} and {n2} are not equal");
        }
        static void question2()
        {
            int num;
            Console.WriteLine("Enter a number : ");
            num = Convert.ToInt32(Console.ReadLine());
            if (num > 0)
                Console.WriteLine($"{num} is a positive number");
            else if (num < 0)
                Console.WriteLine($"{num} is a negative number");
            else
                Console.WriteLine("Zero is neither positive nor negative");
        }
        static void question3()
        {
            int n1, n2, res = 0;
            char sym;
            Console.WriteLine("Enter a number : ");
            n1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter another number : ");
            n2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the operand : ");
            sym = Convert.ToChar(Console.ReadLine());
            bool a = true;
            switch (sym)
            {
                case '+':
                    res = n1 + n2;
                    break;
                case '-':
                    res = n1 - n2;
                    break;
                case '*':
                    res = n1 * n2;
                    break;
                case '/':
                    if (n2 != 0)
                        res = n1 / n2;
                    else
                    {
                        Console.WriteLine("Cannot divide by zero");
                        a = false;
                    }
                    break;
                default:
                    Console.WriteLine("Invalid operation");
                    a = false;
                    break;
            }
            if (a)
                Console.WriteLine($"{n1} {sym} {n2} = {res}");
        }
        static void question4()
        {
            int num;
            Console.WriteLine("Enter a number : ");
            num = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Multiplication Table for {num} : ");
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine($"{num} * {i} = {num * i}");
            }
        }
        static void question5()
        {
            int n1, n2;
            Console.WriteLine("Enter a number : ");
            n1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter another number : ");
            n2 = Convert.ToInt32(Console.ReadLine());
            int res = 0;
            if (n1 == n2)
            {
                res = 3 * (n1 + n2);
                Console.WriteLine(res);
            }
            else
            {
                res = n1 + n2;
                Console.WriteLine(res);
            }
        }
    }
}
