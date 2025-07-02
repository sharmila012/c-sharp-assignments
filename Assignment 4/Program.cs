using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_4
{
    class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public double Salary { get; set; }
    }
    class Program
    {
        static List<Employee> employees = new List<Employee>();
        static void Main(string[] args)
        {
            int choice;
            do
            {
                Console.WriteLine("\n===== Employee Management Menu =====");
                Console.WriteLine("1. Add New Employee");
                Console.WriteLine("2. View All Employees");
                Console.WriteLine("3. Search Employee by ID");
                Console.WriteLine("4. Update Employee Details");
                Console.WriteLine("5. Delete Employee");
                Console.WriteLine("6. Exit");
                Console.WriteLine("====================================");
                Console.Write("Enter your choice: ");
                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            AddEmployee();
                            break;
                        case 2:
                            ViewAllEmployees();
                            break;
                        case 3:
                            SearchEmployee();
                            break;
                        case 4:
                            UpdateEmployee();
                            break;
                        case 5:
                            DeleteEmployee();
                            break;
                        case 6:
                            Console.WriteLine("Exiting program. Goodbye!");
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please enter a number between 1 and 6.");
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                    choice = 0;
                }

            } while (choice != 6);
            Console.WriteLine("________________________");
            Console.WriteLine("question 2 output");
            question2();
        }
        public static void question2()
        {
            MobilePhone phone = new MobilePhone();
            // Create subscriber instances
            RingtonePlayer ringtone = new RingtonePlayer();
            ScreenDisplay screen = new ScreenDisplay();
            VibrationMotor vibration = new VibrationMotor();
            // Subscribe to the OnRing event
            phone.OnRing += ringtone.PlayRingtone;
            phone.OnRing += screen.ShowCallerInfo;
            phone.OnRing += vibration.Vibrate;
            // Simulate incoming call
            phone.ReceiveCall();
            Console.ReadLine();
        }
        static void AddEmployee()
        {
            try
            {
                Console.Write("Enter Employee ID: ");
                int id = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter Name: ");
                string name = Console.ReadLine();
                Console.Write("Enter Department: ");
                string dept = Console.ReadLine();
                Console.Write("Enter Salary: ");
                double salary = Convert.ToDouble(Console.ReadLine());
                employees.Add(new Employee { Id = id, Name = name, Department = dept, Salary = salary });
                Console.WriteLine("Employee added successfully.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter correct data types.");
            }
        }
        static void ViewAllEmployees()
        {
            if (employees.Count == 0)
            {
                Console.WriteLine("No employees to display.");
                return;
            }
            Console.WriteLine("\n--- Employee List ---");
            foreach (var emp in employees)
            {
                Console.WriteLine($"ID: {emp.Id}, Name: {emp.Name}, Department: {emp.Department}, Salary: Rs.{emp.Salary}");
            }
        }
        static void SearchEmployee()
        {
            Console.Write("Enter Employee ID to search: ");
            try
            {
                int id = Convert.ToInt32(Console.ReadLine());
                var emp = employees.Find(e => e.Id == id);
                if (emp != null)
                {
                    Console.WriteLine($"ID: {emp.Id}, Name: {emp.Name}, Department: {emp.Department}, Salary: Rs.{emp.Salary}");
                }
                else
                {
                    Console.WriteLine("Employee not found.");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid ID format.");
            }
        }
        static void UpdateEmployee()
        {
            Console.Write("Enter Employee ID to update: ");
            try
            {
                int id = Convert.ToInt32(Console.ReadLine());
                var emp = employees.Find(e => e.Id == id);
                if (emp != null)
                {
                    Console.Write("Enter new Name (leave blank to keep current): ");
                    string name = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(name)) emp.Name = name;
                    Console.Write("Enter new Department (leave blank to keep current): ");
                    string dept = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(dept)) emp.Department = dept;
                    Console.Write("Enter new Salary (leave blank to keep current): ");
                    string salaryInput = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(salaryInput))
                    {
                        emp.Salary = Convert.ToDouble(salaryInput);
                    }
                    Console.WriteLine("Employee details updated.");
                }
                else
                {
                    Console.WriteLine("Employee not found.");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input format.");
            }
        }
        static void DeleteEmployee()
        {
            Console.Write("Enter Employee ID to delete: ");
            try
            {
                int id = Convert.ToInt32(Console.ReadLine());
                var emp = employees.Find(e => e.Id == id);
                if (emp != null)
                {
                    employees.Remove(emp);
                    Console.WriteLine("Employee deleted successfully.");
                }
                else
                {
                    Console.WriteLine("Employee not found.");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid ID format.");
            }
        }
    }
    public class MobilePhone
    {
        // Delegate definition
        public delegate void RingEventHandler();
        // Event declaration
        public event RingEventHandler OnRing;
        // Method to simulate receiving a call
        public void ReceiveCall()
        {
            Console.WriteLine("Incoming call...");
            OnRing?.Invoke(); // Trigger the event
        }
    }
    // 2. Subscriber classes
    public class RingtonePlayer
    {
        public void PlayRingtone()
        {
            Console.WriteLine("Playing ringtone...");
        }
    }
    public class ScreenDisplay
    {
        public void ShowCallerInfo()
        {
            Console.WriteLine("Displaying caller information...");
        }
    }
    public class VibrationMotor
    {
        public void Vibrate()
        {
            Console.WriteLine("Phone is vibrating...");
        }
    }
}
