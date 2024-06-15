using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeConsoleEFCodeFirst.Models;

namespace EmployeeConsoleEFCodeFirst.Service.Intefaces;

public interface IDepartmentManager
{
    List<DepartmentDTO> GetAllDepartments();
    void AddDepartment(DepartmentDTO department);
    DepartmentDTO GetDepartmentById(int departmentId);
    void EditDepartment(DepartmentDTO updatedDepartment);
    bool IsDepartmentIdValid(int departmentId);
}
