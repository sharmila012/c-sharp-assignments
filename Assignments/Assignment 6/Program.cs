using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Assignment_6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("****Question 1 Output****");
            question1();
            Console.WriteLine("****Question 2 Output****");
            question2();
            Console.WriteLine("****Question 3 Output****");
            question3();
            Console.ReadLine();
        }
        public static void question1()
        {
            BookShelf shelf = new BookShelf();
            Console.WriteLine("Enter details for 5 books:\n");
            for (int i = 0; i < 5; i++)
            {
                Console.Write($"Enter name of book {i + 1}: ");
                string bookName = Console.ReadLine();
                Console.Write($"Enter author of book {i + 1}: ");
                string authorName = Console.ReadLine();
                shelf[i] = new Books(bookName, authorName);
                Console.WriteLine();
            }
            shelf.DisplayAllBooks();
        }
        public static void question2()
        {
            Console.Write("How many lines do you want to enter? ");
            int count = int.Parse(Console.ReadLine());
            string[] userLines = new string[count];
            for (int i = 0; i < count; i++)
            {
                Console.Write($"Enter line {i + 1}: ");
                userLines[i] = Console.ReadLine();
            }
            string filePath = "UserInput.txt";
            try
            {
                File.WriteAllLines(filePath, userLines);
                Console.WriteLine($"File '{filePath}' created and data written successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
        public static void question3()
        {
            string filePath = "UserInput.txt"; 
            try
            {
                if (File.Exists(filePath))
                {
                    int lineCount = File.ReadAllLines(filePath).Length;
                    Console.WriteLine($"The file '{filePath}' has {lineCount} lines.");
                }
                else
                {
                    Console.WriteLine($"File '{filePath}' does not exist.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading the file: " + ex.Message);
            }
        }
    }
    public class Books //question 1
    {
        public string BookName { get; set; }
        public string AuthorName { get; set; }
        public Books(string bookName, string authorName)
        {
            BookName = bookName;
            AuthorName = authorName;
        }
        public void Display()
        {
            Console.WriteLine($"Book Name: {BookName}, Author: {AuthorName}");
        }
    }
    public class BookShelf
    {
        private Books[] bookArray = new Books[5]; // Fixed size for 5 books
        public Books this[int index]
        {
            get
            {
                if (index >= 0 && index < bookArray.Length)
                    return bookArray[index];
                else
                    throw new IndexOutOfRangeException("Invalid index for bookshelf.");
            }
            set
            {
                if (index >= 0 && index < bookArray.Length)
                    bookArray[index] = value;
                else
                    throw new IndexOutOfRangeException("Invalid index for bookshelf.");
            }
        }
        public void DisplayAllBooks()
        {
            Console.WriteLine("\nBooks on the Shelf:");
            for (int i = 0; i < bookArray.Length; i++)
            {
                if (bookArray[i] != null)
                    bookArray[i].Display();
                else
                    Console.WriteLine($"Slot {i + 1}: Empty");
            }
        }
    }
}
