using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO_Assignment_1
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public DateTime DOB { get; set; }
        public DateTime DOJ { get; set; }
        public string City { get; set; }


        public static List<Employee> empList = new List<Employee>
        {
            new Employee { EmployeeID = 1001, FirstName = "Malcolm", LastName = "Daruwalla", Title = "Manager", DOB = DateTime.Parse("16/11/1984"), DOJ = DateTime.Parse("8/6/2011"), City = "Mumbai" },
            new Employee { EmployeeID = 1002, FirstName = "Asdin", LastName = "Dhalla", Title = "AsstManager", DOB = DateTime.Parse("20/08/1984"), DOJ = DateTime.Parse("7/7/2012"), City = "Mumbai" },
            new Employee { EmployeeID = 1003, FirstName = "Madhavi", LastName = "Oza", Title = "Consultant", DOB = DateTime.Parse("14/11/1987"), DOJ = DateTime.Parse("12/4/2015"), City = "Pune" },
            new Employee { EmployeeID = 1004, FirstName = "Saba", LastName = "Shaikh", Title = "SE", DOB = DateTime.Parse("3/6/1990"), DOJ = DateTime.Parse("2/2/2016"), City = "Pune" },
            new Employee { EmployeeID = 1005, FirstName = "Nazia", LastName = "Shaikh", Title = "SE", DOB = DateTime.Parse("8/3/1991"), DOJ = DateTime.Parse("2/2/2016"), City = "Mumbai" },
            new Employee { EmployeeID = 1006, FirstName = "Amit", LastName = "Pathak", Title = "Consultant", DOB = DateTime.Parse("7/11/1989"), DOJ = DateTime.Parse("8/8/2014"), City = "Chennai" },
            new Employee { EmployeeID = 1007, FirstName = "Vijay", LastName = "Natrajan", Title = "Consultant", DOB = DateTime.Parse("2/12/1989"), DOJ = DateTime.Parse("1/6/2015"), City = "Mumbai" },
            new Employee { EmployeeID = 1008, FirstName = "Rahul", LastName = "Dubey", Title = "Associate", DOB = DateTime.Parse("11/11/1993"), DOJ = DateTime.Parse("6/11/2014"), City = "Chennai" },
            new Employee { EmployeeID = 1009, FirstName = "Suresh", LastName = "Mistry", Title = "Associate", DOB = DateTime.Parse("12/8/1992"), DOJ = DateTime.Parse("3/12/2014"), City = "Chennai" },
            new Employee { EmployeeID = 1010, FirstName = "Sumit", LastName = "Shah", Title = "Manager", DOB = DateTime.Parse("12/4/1991"), DOJ = DateTime.Parse("2/1/2016"), City = "Pune" }
        };

    }
    class Program
    {
        static void Main(string[] args)
        {
            // 1.Display a list of all the employee who have joined before 1 / 1 / 2015
            var emp = Employee.empList.Where(e => e.DOJ < new DateTime(2015, 1, 1));
            Console.WriteLine("1.Employees who joined before 1/1/2015 : ");
            foreach(var n in emp)
            {
                Console.WriteLine($"{n.FirstName}\t{n.LastName}");
            }

            //2.Display a list of all the employee whose date of birth is after 1 / 1 / 1990
            emp = Employee.empList.Where(e => e.DOB > new DateTime(1990, 1, 1));
            Console.WriteLine("\n2.Employees whose DOB is after 1/1/1990 :  ");
            foreach(var n in emp)
            {
                Console.WriteLine($"{n.FirstName}\t{n.LastName}");
            }

            //3.Display a list of all the employee whose designation is Consultant and Associate
            emp = Employee.empList.Where(e => e.Title == "Consultant" || e.Title == "Associate");
            Console.WriteLine("\n3.Employees who are Consultants and Associates are :");
            foreach(var n in emp)
            {
                Console.WriteLine($"{n.FirstName}\t{n.LastName}");
            }

            //4.Display total number of employees
            Console.WriteLine($"\n4.Total number of employees : {Employee.empList.Count}");

            //5.Display total number of employees belonging to “Chennai”
            emp = Employee.empList.Where(e => e.City == "Chennai");
            Console.WriteLine($"\n5.Total number of employees belonging to Chennai : {Employee.empList.Count(e => e.City == "Chennai")}");
            Console.WriteLine("Employees who belong to Chennai are :");
            foreach (var n in emp)
            {
                Console.WriteLine($"{n.FirstName}\t{n.LastName}");
            }

            //6.Display highest employee id from the list
            Console.WriteLine($"\n6.Highest employee ID : {Employee.empList.Max(e => e.EmployeeID)}");

            //7.Display total number of employee who have joined after 1 / 1 / 2015
            emp = Employee.empList.Where(e => e.DOJ > new DateTime(2015, 1, 1));
            Console.WriteLine($"\n7.Total number of employee who have joined after 1/1/2015 : {Employee.empList.Count(e=>e.DOJ>new DateTime(2015,1,1))}");
            Console.WriteLine("Employees who joined after 1/1/2015 : ");
            foreach (var n in emp)
            {
                Console.WriteLine($"{n.FirstName}\t{n.LastName}");
            }

            //8.Display total number of employee whose designation is not “Associate”
            emp = Employee.empList.Where(e => e.Title != "Associate");
            Console.WriteLine($"\n8.Total number of employees whose designation is not Associate : {Employee.empList.Count(e => e.Title != "Associate")}");
            Console.WriteLine("Employees whose designation is not Associate :");
            foreach (var n in emp)
            {
                Console.WriteLine($"{n.FirstName}\t{n.LastName}");
            }

            //9.Display total number of employee based on City
            var empCity = Employee.empList.GroupBy(e => e.City);
            Console.WriteLine("\n9.Employees grouped by City:");
            foreach(var n in empCity)
            {
                Console.WriteLine($"{n.Key} : {n.Count()}");
            }

            //10.Display total number of employee based on city and title
            var emp1 = Employee.empList.GroupJoin(Employee.empList,
                o => new { o.City, o.Title },
                i => new { i.City, i.Title },
                (key, gr) => new { city = key.City, title = key.Title, count = gr.Count() }
                ).Distinct().OrderBy(e => e.city).ThenBy(e => e.title);

            Console.WriteLine("\n10.Employees grouped by City and Title:");
            foreach (var n in emp1)
            {
                Console.WriteLine($"{n.city} - {n.title} : {n.count}");
            }

            //11.Display total number of employee who is youngest in the list
            var young = Employee.empList.OrderByDescending(e => e.DOB).First();
            Console.WriteLine($"\n11.Youngest Employee: {young.FirstName} " +
                $"{young.LastName}, DOB: {young.DOB}");

            Console.ReadLine();
        }
    }
}
