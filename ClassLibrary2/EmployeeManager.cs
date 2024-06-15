using EmployeeConsoleEFCodeFirst.Service.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeConsoleEFCodeFirst.Data.Interfaces;
using EmployeeConsoleEFCodeFirst.Models;
using AutoMapper;
using EmployeeConsoleEFCodeFirst.Data.Models;
namespace EmployeeConsoleEFCodeFirst.Service;

public class EmployeeManager : IEmployeeManager
{
    private readonly IEmployeeRepository employeeDataAccess;
    private readonly IMapper mapper;
    public EmployeeManager(IEmployeeRepository employeeDataAccess, IMapper mapper)
    {
        this.employeeDataAccess = employeeDataAccess;
        this.mapper = mapper;
    }
    public void AddEmployee(EmployeeDTO employeeDTO)
    {
        Employee employee = mapper.Map<Employee>(employeeDTO);
        employeeDataAccess.AddEmployee(employee);
    }

    public List<EmployeeDTO> GetAllEmployees()
    {
        List<Employee> employees =  employeeDataAccess.GetAllEmployees();
        return mapper.Map<List<EmployeeDTO>>(employees);
    }

    public EmployeeDTO? GetEmployeeById(int empId)
    {
        Employee employee = employeeDataAccess.GetEmployeeById(empId);
        return mapper.Map<EmployeeDTO>(employee);
    }

    public void UpdateEmployee(EmployeeDTO employeeDTO)
    {
        Employee employee = mapper.Map<Employee>(employeeDTO);
        employeeDataAccess.UpdateEmployee(employee);
    }

    public void DeleteEmployee(int empId)
    {
        employeeDataAccess.DeleteEmployee(empId);
    }

    public List<EmployeeDTO> GetEmployeesByRoleId(int roleId)
    {
        List<Employee> employees = employeeDataAccess.GetEmployeesByRoleId(roleId);
        return mapper.Map<List<EmployeeDTO>>(employees);
    }
}
