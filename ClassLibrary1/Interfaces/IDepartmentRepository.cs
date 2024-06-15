using EmployeeConsoleEFCodeFirst.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeConsoleEFCodeFirst.Data.Interfaces;

public interface IDepartmentRepository
{
    List<Department> GetAllDepartments();
    void AddDepartment(Department department);
    Department GetDepartmentById(int departmentId);
    void Editdepartment(Department updateddepartment);
    bool IsDepartmentIdValid(int departmentId);
}
