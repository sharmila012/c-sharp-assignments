using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class InsufficientBalanceException : ApplicationException
{
    public InsufficientBalanceException(string message) : base(message)
    {
    }
}
public class InvalidMarksException : ApplicationException
{
    public InvalidMarksException(string message) : base(message)
    {
    }
}

namespace Assignment_5
{
    class Program
    {
        static void Main(string[] args)
        {
            question1();
            Console.WriteLine("________________________________");
            question2();
            Console.WriteLine("________________________________");
            question3();
            Console.WriteLine("________________________________");
            Console.ReadLine();
        }
        static void question1()
        {
            try
            {
                Console.Write("Enter Account Number: ");
                string accNo = Console.ReadLine();
                Console.Write("Enter Customer Name: ");
                string custName = Console.ReadLine();
                Console.Write("Enter Account Type: ");
                string accType = Console.ReadLine();
                Console.Write("Enter Transaction Type (d/w): ");
                char transType = Convert.ToChar(Console.ReadLine());
                if (transType != 'd' && transType != 'D' && transType != 'w' && transType != 'W')
                {
                    Console.WriteLine("Invalid transaction type!! Try again :)");
                    return; 
                }
                Console.Write("Enter Amount: ");
                int amt = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter Initial Balance: ");
                int bal = Convert.ToInt32(Console.ReadLine());
                Accounts account = new Accounts(accNo, custName, accType, transType, amt, bal);
                account.UpdateBalance();
                account.ShowData();
            }
            catch (InsufficientBalanceException ex)
            {
                Console.WriteLine($"Transaction failed: {ex.Message}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input format. Please enter correct data types.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
        }
        static void question2()
        {
            try
            {
                Console.Write("Enter Marks: ");
                int marks = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter Fees: ");
                double fees = Convert.ToDouble(Console.ReadLine());

                Scholarship s = new Scholarship();
                s.Merit(marks, fees);
            }
            catch (InvalidMarksException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input format. Please enter numeric values.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }
        }
        static void question3()
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
            Console.ReadLine();
        }
    }
    class Accounts //question 1
    {
        private string accountNo;
        private string customerName;
        private string accountType;
        private char transactionType;
        private int amount;
        private int balance;
        public Accounts(string accountNo, string customerName, string accountType, char transactionType, int amount, int balance)
        {
            this.accountNo = accountNo;
            this.customerName = customerName;
            this.accountType = accountType;
            this.transactionType = transactionType;
            this.amount = amount;
            this.balance = balance;
        }
        public void Credit(int amount)
        {
            balance += amount;
        }
        public void Debit(int amount)
        {
            if (amount <= balance)
            {
                balance -= amount;
            }
            else
            {
                throw new InsufficientBalanceException("Insufficient balance for withdrawal.");
            }
        }
        public void UpdateBalance()
        {
            if (transactionType == 'd' || transactionType == 'D')
            {
                Credit(amount);
            }
            else if (transactionType == 'w' || transactionType == 'W')
            {
                Debit(amount);
            }
            else
            {
                Console.WriteLine("Invalid transaction type.");
            }
        }
        public void ShowData()
        {
            Console.WriteLine("\nThe account summary is:\n");
            Console.WriteLine($"Account No: {accountNo}");
            Console.WriteLine($"Customer Name: {customerName}");
            Console.WriteLine($"Account Type: {accountType}");
            Console.WriteLine($"Transaction Type: {transactionType}");
            Console.WriteLine($"Amount: {amount}");
            Console.WriteLine($"Balance: {balance}\n");
        }
    }
    public class Scholarship //question 2
    {
        public void Merit(int marks, double fees)
        {
            double scholarshipAmount = 0;
            if (marks >= 70 && marks <= 80)
            {
                scholarshipAmount = fees * 0.20;
            }
            else if (marks > 80 && marks <= 90)
            {
                scholarshipAmount = fees * 0.30;
            }
            else if (marks > 90)
            {
                scholarshipAmount = fees * 0.50;
            }
            else
            {
                throw new InvalidMarksException("Marks are too low to qualify for a scholarship.");
            }
            Console.WriteLine($"Scholarship Amount: Rs.{scholarshipAmount}");
        }
    }
    public class Books //question 3
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
