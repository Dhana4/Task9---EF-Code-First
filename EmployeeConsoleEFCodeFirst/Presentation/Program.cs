using System.IO;
using System;
using System.ComponentModel.Design;
using System.Data.SqlClient;
using System.Reflection;
using System.Text.RegularExpressions;
using Castle.Core.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using EmployeeConsoleEFCodeFirst.Service.Intefaces;
using EmployeeConsoleEFCodeFirst.Service;
using EmployeeConsoleEFCodeFirst.Data.Interfaces;
using EmployeeConsoleEFCodeFirst.Data;
using EmployeeConsoleEFCodeFirst.Data.Models;
using HelperMethods;
class Program
{
    private static IServiceProvider serviceProvider;
    static void Main(string[] args)
    {
        RegisterServices();
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("Main Menu");
            Console.WriteLine("1. Employee Management");
            Console.WriteLine("2. Role Management");
            Console.WriteLine("3. View all Employees in a particular Role");
            Console.WriteLine("4. Exit");
            int choice = default;
            string choiceString = string.Empty;
            bool choiceEntered = false;
            while (!choiceEntered)
            {
                choiceString = Console.ReadLine() ?? string.Empty;
                if (int.TryParse(choiceString, out choice))
                {
                    choiceEntered = true;
                }
                else
                {
                    Console.WriteLine("Invalid Choice! Enter again");
                }
            }
            switch (choice)
            {
                case 1:
                    EmployeeManagementMenu();
                    break;
                case 2:
                    RoleManagementMenu();
                    break;
                case 3:
                    var employeeHelper = serviceProvider.GetService<IEmployeeHelper>();
                    employeeHelper.ViewAllEmpInRole();
                    break;
                case 4:
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid Choice! Enter again");
                    break;
            }
        }
        DisposeServices();
    }
    static void EmployeeManagementMenu()
    {
        bool goBack = false;
        var employeeHelper = serviceProvider.GetService<IEmployeeHelper>();
        while (!goBack)
        {
            Console.WriteLine("Employee Management Menu");
            Console.WriteLine("1. Add Employee");
            Console.WriteLine("2. Display All");
            Console.WriteLine("3. Display One");
            Console.WriteLine("4. Edit Employee");
            Console.WriteLine("5. Delete Employee");
            Console.WriteLine("6. Go Back");
            int choice = default;
            string choiceString = string.Empty;
            bool choiceEntered = false;
            while (!choiceEntered)
            {
                choiceString = Console.ReadLine() ?? string.Empty;
                if (int.TryParse(choiceString, out choice))
                {
                    choiceEntered = true;
                }
                else
                {
                    Console.WriteLine("Invalid Choice! Enter again");
                }
            }
            switch (choice)
            {
                case 1:
                    employeeHelper.AddEmployee();
                    break;
                case 2:
                    employeeHelper.DisplayAllEmployees();
                    break;
                case 3:
                    employeeHelper.DisplayOneEmployee();
                    break;
                case 4:
                    employeeHelper.EditEmployee();
                    break;
                case 5:
                    employeeHelper.DeleteEmployee();
                    break;
                case 6:
                    goBack = true;
                    break;
                default:
                    Console.WriteLine("Invalid Choice! Enter again");
                    break;
            }
        }
    }
    static void RoleManagementMenu()
    {
        var roleHelper = serviceProvider.GetService<IRoleHelper>();
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("Role Management Menu");
            Console.WriteLine("1. Add Role");
            Console.WriteLine("2. Edit Role");
            Console.WriteLine("3. Back to Main Menu");
            int choice = default;
            bool choiceEntered = false;
            while (!choiceEntered)
            {
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    choiceEntered = true;
                }
                else
                {
                    Console.WriteLine("Invalid Choice! Enter again");
                }
            }
            switch (choice)
            {
                case 1:
                    roleHelper.AddRole();
                    break;
                case 2:
                    roleHelper.EditRole();
                    break;
                case 3:
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid Choice! Enter again");
                    break;
            }
        }
    }
    public static void RegisterServices()
    {
        var services = new ServiceCollection();
        IConfigurationRoot configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("C:\\Users\\lakshmi.m\\source\\repos\\EmployeeConsoleEFCodeFirst\\EmployeeConsoleEFCodeFirst\\Presentation\\AppSettings.json")
        .Build();
        services.AddDbContext<EmployeeDBContext>(options =>
            options.UseLazyLoadingProxies().UseSqlServer(configuration.GetConnectionString("EmployeeDataBase")));  
        services.AddTransient<IEmployeeManager, EmployeeManager>();
        services.AddTransient<IRoleManager, RoleManager>();
        services.AddTransient<IDepartmentManager, DepartmentManager>();
        services.AddTransient<ILocationManager, LocationManager>();
        services.AddTransient<IEmployeeRepository, EmployeeRepository>();
        services.AddTransient<IRoleRepository, RoleRepository>();
        services.AddTransient<IDepartmentRepository, DepartmentRepository>();
        services.AddTransient<ILocationRepository, LocationRepository>();
        services.AddTransient<IEmployeeHelper, EmployeeHelper>();
        services.AddTransient<IRoleHelper, RoleHelper>();
        services.AddTransient<ILocationHelper, LocationHelper>();
        services.AddTransient<IDepartmentHelper, DepartmentHelper>();
        services.AddAutoMapper(typeof(MappingProfile).Assembly);
        serviceProvider = services.BuildServiceProvider();
    }
    public static void DisposeServices()
    {
        if (serviceProvider == null)
        {
            return;
        }
        if (serviceProvider is IDisposable)
        {
            ((IDisposable)serviceProvider).Dispose();
        }
    }
}