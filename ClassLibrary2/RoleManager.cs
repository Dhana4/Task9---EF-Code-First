using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeConsoleEFCodeFirst.Models;
using EmployeeConsoleEFCodeFirst.Data.Models;
using EmployeeConsoleEFCodeFirst.Service.Intefaces;
using EmployeeConsoleEFCodeFirst.Data.Interfaces;
using AutoMapper;
namespace EmployeeConsoleEFCodeFirst.Service;
public class RoleManager: IRoleManager
{
    private readonly IRoleRepository roleRepository;
    private readonly IMapper mapper;

    public RoleManager(IRoleRepository roleRepository, IMapper mapper)
    {
        this.roleRepository = roleRepository;
        this.mapper = mapper;
    }
    public List<RoleDTO> GetAllRoles()
    {
        List<Role> roles = roleRepository.GetAllRoles();
        return mapper.Map<List<RoleDTO>>(roles);
    }
    public void AddRole(RoleDTO roleDTO)
    {
        Role role = mapper.Map<Role>(roleDTO);
        roleRepository.AddRole(role);
    }
    public RoleDTO GetRoleById(int roleId)
    {
        Role role = roleRepository.GetRoleById(roleId);
        return mapper.Map<RoleDTO>(role);
    }
    public void EditRole(RoleDTO updatedRole)
    {
        Role role = mapper.Map<Role>(updatedRole);
        roleRepository.EditRole(role);
    }
    public bool IsRoleIdValid(int roleId)
    {
        return roleRepository.IsRoleIdValid(roleId);
    }
}
