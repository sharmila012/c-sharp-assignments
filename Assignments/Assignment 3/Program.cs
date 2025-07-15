using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_3
{
    class Program
    {
        static void Main(string[] args)
        {
            question1();
            Console.WriteLine("\n-------------------------------------\n");
            question2();
            Console.WriteLine("\n-------------------------------------\n");
            question3();
            Console.ReadLine();
        }
        static void question1()
        {
            Console.Write("Enter Account Number: ");
            string accNo = Console.ReadLine();
            Console.Write("Enter Customer Name: ");
            string custName = Console.ReadLine();
            Console.Write("Enter Account Type: ");
            string accType = Console.ReadLine();
            Console.Write("Enter Transaction Type (d/w): ");
            char transType = Convert.ToChar(Console.ReadLine());
            Console.Write("Enter Amount: ");
            int amt = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Initial Balance: ");
            int bal = Convert.ToInt32(Console.ReadLine());
            Accounts account = new Accounts(accNo, custName, accType, transType, amt, bal);
            account.UpdateBalance();
            account.ShowData();
        }
        static void question2()
        {
            Console.Write("Enter Roll No: ");
            int rollNo = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Year: ");
            string studentClass = Console.ReadLine();
            Console.Write("Enter Semester: ");
            int semester = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Branch: ");
            string branch = Console.ReadLine();
            Student student = new Student(rollNo, name, studentClass, semester, branch);
            student.GetMarks();
            student.DisplayData();
            student.DisplayResult();
        }
        static void question3()
        {

            Console.Write("Enter Sales No: ");
            int salesNo = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Product No: ");
            int productNo = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Price: ");
            double price = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter Quantity: ");
            int qty = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Date of Sale (dd-mm-yyyy): ");
            string dateOfSale = Console.ReadLine();
            Saledetails sale = new Saledetails(salesNo, productNo, price, qty, dateOfSale);
            Saledetails.ShowData(sale);
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
                Console.WriteLine("Insufficient balance.");
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
            Console.WriteLine("\nThe account sumamry is \n");
            Console.WriteLine($"Account No: {accountNo}");
            Console.WriteLine($"Customer Name: {customerName}");
            Console.WriteLine($"Account Type: {accountType}");
            Console.WriteLine($"Transaction Type: {transactionType}");
            Console.WriteLine($"Amount: {amount}");
            Console.WriteLine($"Balance: {balance}\n");
        }
    }
    class Student //question 2
    {
        private int rollNo;
        private string name;
        private string studentClass;
        private int semester;
        private string branch;
        private int[] marks = new int[5];
        public Student(int rollNo, string name, string studentClass, int semester, string branch)
        {
            this.rollNo = rollNo;
            this.name = name;
            this.studentClass = studentClass;
            this.semester = semester;
            this.branch = branch;
        }
        public void GetMarks()
        {
            Console.WriteLine("Enter marks for 5 subjects:");
            for (int i = 0; i < 5; i++)
            {
                Console.Write($"Subject {i + 1}: ");
                marks[i] = Convert.ToInt32(Console.ReadLine());
            }
        }
        public void DisplayResult()
        {
            int total = 0;
            bool hasFailedSubject = false;
            foreach (int mark in marks)
            {
                total += mark;
                if (mark < 35)
                {
                    hasFailedSubject = true;
                }
            }
            double average = total / 5.0;
            if (hasFailedSubject)
            {
                Console.WriteLine("Result: Failed (one or more subjects below 35)");
            }
            else if (average < 50)
            {
                Console.WriteLine("Result: Failed (average below 50)");
            }
            else
            {
                Console.WriteLine("Result: Passed");
            }
        }
        public void DisplayData()
        {
            Console.WriteLine("\n--- Student Details ---\n");
            Console.WriteLine($"Roll No: {rollNo}");
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Class: {studentClass}");
            Console.WriteLine($"Semester: {semester}");
            Console.WriteLine($"Branch: {branch}");
            Console.WriteLine("Marks: " + string.Join(", ", marks));
        }
    }
    class Saledetails //question 3
    {
        private int salesNo;
        private int productNo;
        private double price;
        private string dateOfSale;
        private int qty;
        private double totalAmount;
        public Saledetails(int salesNo, int productNo, double price, int qty, string dateOfSale)
        {
            this.salesNo = salesNo;
            this.productNo = productNo;
            this.price = price;
            this.qty = qty;
            this.dateOfSale = dateOfSale;
            Sales(); // Automatically calculate totalAmount
        }
        public void Sales()
        {
            totalAmount = qty * price;
        }
        public static void ShowData(Saledetails sale)
        {
            Console.WriteLine("\n--- Sale Details ---\n");
            Console.WriteLine($"Sales No: {sale.salesNo}");
            Console.WriteLine($"Product No: {sale.productNo}");
            Console.WriteLine($"Price: {sale.price}");
            Console.WriteLine($"Quantity: {sale.qty}");
            Console.WriteLine($"Date of Sale: {sale.dateOfSale}");
            Console.WriteLine($"Total Amount: {sale.totalAmount}");
        }
    }
}
