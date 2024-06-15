using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeConsoleEFCodeFirst.Service.Intefaces;
using EmployeeConsoleEFCodeFirst.Data.Interfaces;
using EmployeeConsoleEFCodeFirst.Data.Models;
using AutoMapper;
using EmployeeConsoleEFCodeFirst.Models;
namespace EmployeeConsoleEFCodeFirst.Service;
public class DepartmentManager : IDepartmentManager
{
    private readonly IDepartmentRepository departmentRepository;
    private readonly IMapper mapper;

    public DepartmentManager(IDepartmentRepository departmentRepository, IMapper mapper)
    {
        this.departmentRepository = departmentRepository;
        this.mapper = mapper;
    }
    public void AddDepartment(DepartmentDTO departmentDTO)
    {
        Department department = mapper.Map<Department>(departmentDTO);
        departmentRepository.AddDepartment(department);
    }

    public void EditDepartment(DepartmentDTO updatedDepartmentDTO)
    {
        Department department = mapper.Map<Department>(updatedDepartmentDTO);
        departmentRepository.Editdepartment(department);
    }

    public List<DepartmentDTO> GetAllDepartments()
    {
        List<Department> departments = departmentRepository.GetAllDepartments();
        return mapper.Map<List<DepartmentDTO>>(departments);
    }

    public DepartmentDTO GetDepartmentById(int departmentId)
    {
        Department department = departmentRepository.GetDepartmentById(departmentId);
        return mapper.Map<DepartmentDTO>(department);
    }
    public bool IsDepartmentIdValid(int departmentId)
    {
        return departmentRepository.IsDepartmentIdValid(departmentId);
    }
}
