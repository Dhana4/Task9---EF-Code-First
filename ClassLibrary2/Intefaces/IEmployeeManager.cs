using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeConsoleEFCodeFirst.Models;
namespace EmployeeConsoleEFCodeFirst.Service.Intefaces;
public interface IEmployeeManager
{
    void AddEmployee(EmployeeDTO employee);
    List<EmployeeDTO> GetAllEmployees();
    EmployeeDTO? GetEmployeeById(int empId);
    void UpdateEmployee(EmployeeDTO employee);
    void DeleteEmployee(int empId);
    List<EmployeeDTO> GetEmployeesByRoleId(int roleId);
}
