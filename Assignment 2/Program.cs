using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            question1();
            question2();
            question3();
            arrayquestion1();
            arrayquestion2();
            arrayquestion3();
            stringsquestion1();
            stringsquestion2();
            stringsquestion3();
        }
        static void question1() //swap of 2 numbers
        {
            Console.WriteLine("Question 1 - swap of 2 numbers\n");
            int n1, n2;
            Console.WriteLine("Enter a number : ");
            n1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter another number : ");
            n2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Initially n1 is {n1} and n2 is {n2}");
            n1 = n1 + n2;
            n2 = n1 - n2;
            n1 = n1 - n2;
            Console.WriteLine($"After swapping n1 is {n1} and n2 is {n2}");
        }
        static void question2() //printing numbers
        {
            Console.WriteLine("\nQuestion 2 - printing numbers\n");
            Console.Write("Enter a number : ");
            String num = Console.ReadLine();
            for (int i = 0; i < 4; i++)
            {
                Console.Write("{0} ", num);
            }
            Console.WriteLine();
            for (int i = 0; i < 4; i++)
            {
                Console.Write("{0}", num);
            }
            Console.WriteLine();
            for (int i = 0; i < 4; i++)
            {
                Console.Write("{0} ", num);
            }
            Console.WriteLine();
            for (int i = 0; i < 4; i++)
            {
                Console.Write("{0}", num);
            }
            Console.WriteLine();
        }
        enum DaysOfWeek
        {
            Monday = 1,
            Tuesday,
            Wednesday,
            Thursday,
            Friday,
            Saturday,
            Sunday
        }
        static void question3() //days of a week
        {
            Console.WriteLine("\nQuestion 3 - days of a week\n");
            Console.Write("Enter a day number (1 to 7): ");
            int dayNumber = Convert.ToInt32(Console.ReadLine());
            if (Enum.IsDefined(typeof(DaysOfWeek), dayNumber))
            {
                DaysOfWeek day = (DaysOfWeek)dayNumber;
                Console.WriteLine(day);
            }
            else
            {
                Console.WriteLine("Invalid day number. Please enter a number from 1 to 7.");
            }
        }
        static void arrayquestion1()
        {
            Console.WriteLine("\nArrays Question 1 - avg, min, max of given numbers\n");
            Console.WriteLine("Enter the size of the array : ");
            int n = Convert.ToInt32(Console.ReadLine());
            int[] nums = new int[n];
            Console.WriteLine($"Enter {n} integers : ");
            for (int i = 0; i < nums.Length; i++)
            {
                Console.Write($"Element {i + 1} : ");
                nums[i] = Convert.ToInt32(Console.ReadLine());
            }
            int sum = 0, min = nums[0], max = nums[0];
            foreach (int num in nums)
            {
                sum += num;
                if (num < min) min = num;
                if (num > max) max = num;
            }
            double average = (double)sum / nums.Length;
            Console.WriteLine($"\nAverage: {average}");
            Console.WriteLine($"Minimum: {min}");
            Console.WriteLine($"Maximum: {max}");
        }
        static void arrayquestion2()
        {
            Console.WriteLine("\nArrays Question 2 - Operations of marks\n");
            int[] marks = new int[10];
            Console.WriteLine("Enter 10 marks:");
            for (int i = 0; i < marks.Length; i++)
            {
                Console.Write($"Mark {i + 1}: ");
                marks[i] = Convert.ToInt32(Console.ReadLine());
            }
            int total = 0, min = marks[0], max = marks[0];
            for (int i = 0; i < marks.Length; i++)
            {
                total += marks[i];
                if (marks[i] < min) min = marks[i];
                if (marks[i] > max) max = marks[i];
            }
            double average = (double)total / marks.Length;
            Console.WriteLine($"\nTotal: {total}");
            Console.WriteLine($"Average: {average}");
            Console.WriteLine($"Minimum: {min}");
            Console.WriteLine($"Maximum: {max}");
            int[] asc = (int[])marks.Clone();
            BubbleSort(asc, true);
            Console.WriteLine("Marks in ascending order : " + string.Join(", ", asc));
            int[] desc = (int[])marks.Clone();
            BubbleSort(desc, false);
            Console.WriteLine("Marks in descending order : " + string.Join(", ", desc));            
        }
        static void BubbleSort(int[] arr, bool order) //function for sorting of marks
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = 0; j < arr.Length - i - 1; j++)
                {
                    if ((order && arr[j] > arr[j + 1]) || (!order && arr[j] < arr[j + 1]))
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
        }
        static void arrayquestion3()
        {
            Console.WriteLine("\nArrays Question 3 - Copy of an array\n");
            Console.Write("Enter number of elements: ");
            int size = Convert.ToInt32(Console.ReadLine());
            int[] sourceArray = new int[size];
            Console.WriteLine("Enter array elements:");
            for (int i = 0; i < size; i++)
            {
                Console.Write($"Element {i + 1}: ");
                sourceArray[i] = Convert.ToInt32(Console.ReadLine());
            }
            int[] target = new int[size];
            for(int i=0;i<size;i++)
            {
                target[i] = sourceArray[i];
            }
            Console.WriteLine("Copied array : " + string.Join(", ", target));
        }
        static void stringsquestion1()
        {
            Console.WriteLine("\nstrings Question 1 - length of a word\n");
            Console.WriteLine("Enter a word : ");
            string word = Console.ReadLine();
            Console.WriteLine("Length of the given word is " + word.Length);
        }
        static void stringsquestion2()
        {
            Console.WriteLine("\nstrings Question 2 - reverse of a word\n");
            Console.Write("Enter a word : ");
            string word = Console.ReadLine();
            char[] chararray = word.ToCharArray();
            Array.Reverse(chararray);
            string reversed = new string(chararray);
            Console.WriteLine("Reversed word is " + reversed);
        }
        static void stringsquestion3()
        {
            Console.WriteLine("\nstrings Question 3 - Similarity of 2 words\n");
            Console.WriteLine("Enter the first word : ");
            string word1 = Console.ReadLine();
            Console.WriteLine("Enter the second word : ");
            string word2 = Console.ReadLine();
            if(word1.Equals(word2, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Bothe the words are same.");
            }
            else
            {
                Console.WriteLine("The words are different.");
            }
            Console.ReadLine();
        }
    }
}
