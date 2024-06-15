using EmployeeConsoleEFCodeFirst.Service;
using EmployeeConsoleEFCodeFirst.Service.Intefaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeConsoleEFCodeFirst.Models;
namespace HelperMethods;
public class DepartmentHelper : IDepartmentHelper
{
    private readonly IDepartmentManager departmentManager;
    public DepartmentHelper(IDepartmentManager departmentManager)
    {
        this.departmentManager = departmentManager;
    }
    public bool DisplayAvailableDepartments()
    {
        List<DepartmentDTO> departments = departmentManager.GetAllDepartments();
        if (departments.Count == 0)
        {
            return false;
        }
        foreach (DepartmentDTO department in departments)
        {
            Console.WriteLine($"Department Id: {department.DepartmentId}\nDepartment Name: {department.DepartmentName}");
        }
        return true;
    }
}
