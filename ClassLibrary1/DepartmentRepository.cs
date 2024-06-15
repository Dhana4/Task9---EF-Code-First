using EmployeeConsoleEFCodeFirst.Data.Interfaces;
using EmployeeConsoleEFCodeFirst.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeConsoleEFCodeFirst.Data;
public class DepartmentRepository : IDepartmentRepository
{
    private readonly EmployeeDBContext dbContext;

    public DepartmentRepository(EmployeeDBContext dbContext)
    {
        this.dbContext = dbContext;
    }
    public void AddDepartment(Department department)
    {
        dbContext.Departments.Add(department);
        dbContext.SaveChanges();
    }

    public void Editdepartment(Department updateddepartment)
    {
        var existingdepartment = dbContext.Departments.Find(updateddepartment.DepartmentId);
        if (existingdepartment != null)
        {
            dbContext.Entry(existingdepartment).State = EntityState.Detached;
            dbContext.Departments.Update(updateddepartment);
            dbContext.SaveChanges();
        }
    }

    public List<Department> GetAllDepartments()
    {
        return dbContext.Departments.ToList();
    }

    public Department GetDepartmentById(int departmentId)
    {
        return dbContext.Departments.Find(departmentId);
    }
    public bool IsDepartmentIdValid(int departmentId)
    {
        bool isDepartmentIdValid = false;
        List<Department> departments = GetAllDepartments();
        foreach (Department department in departments)
        {
            if (department.DepartmentId == departmentId)
            {
                isDepartmentIdValid = true;
            }
        }
        return isDepartmentIdValid;
    }
}
