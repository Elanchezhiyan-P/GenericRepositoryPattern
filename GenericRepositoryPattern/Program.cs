using DataCollectorLibrary.Enums;
using DataCollectorLibrary.Persistences.Context;
using DataCollectorLibrary.Persistences.Entity;
using DataCollectorLibrary.Persistences.Repository.Employee;
using Microsoft.DotNet.Cli.Utils;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepositoryPattern
{
    internal class Program
    {

        static void Main(string[] args)
        {

            //DbMigrator helps in updating the database to the latest migrations
            DbMigrator migrator = new DbMigrator(new DataCollectorLibrary.Migrations.Employee.Configuration());

            if (migrator.GetPendingMigrations().Any())
                migrator.Update();

            //Initializes the database
            IEmployeeUnitOfWork _employeeUnitOfWork = new EmployeeUnitOfWork(new EmployeeContext());

            Employee employee = new Employee()
            {
                FirstName = "Demo",
                LastName = "User",
                Gender = Gender.Male,
                DOB = ParseDateString("30-11-1997"),
                Email = "DemoUser@gmail.com",
                IsActive = true,
                IsDeleted = false,
                CreatedBy = "Admin",
                CreatedDate = DateTime.Now,
                LastModifiedBy = "Admin",
                LastModifiedDate = DateTime.Now,
            };

            //Adds the data to the database
            _employeeUnitOfWork.Employee.Add(employee);
            _employeeUnitOfWork.Complete();

            Console.WriteLine("Data added to the database successfully!\n");

            IEnumerable<Employee> employeeData = _employeeUnitOfWork.Employee.GetAll();
            Console.WriteLine("All the employee data:\n**************************\n");
            foreach (var item in employeeData)
            {
                Console.WriteLine($"Name: {item.FirstName} {item.LastName}");
                Console.WriteLine($"Age: {item.Age}");
                Console.WriteLine($"Email: {item.Email}");
                Console.WriteLine($"Active: {item.IsActive}");
                Console.WriteLine($"**************************\n");
            }

            IEnumerable<Employee> activeEmployeeData = _employeeUnitOfWork.Employee.GetAll(x => x.IsActive);
            Console.WriteLine("Active employee data:\n**************************\n");
            foreach (var item in activeEmployeeData)
            {
                Console.WriteLine($"Name: {item.FirstName} {item.LastName}");
                Console.WriteLine($"Age: {item.Age}");
                Console.WriteLine($"Email: {item.Email}");
                Console.WriteLine($"**************************\n");
            }

            Console.ReadLine();
        }

        //DateConversion function
        static DateTime ParseDateString(string input)
        {
            if (DateTime.TryParseExact(input, "dd-MM-yyyy", null, DateTimeStyles.None, out DateTime parsedDate))
            {
                return parsedDate;
            }

            return DateTime.MinValue;
        }
    }
}
