using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeConsoleEFCodeFirst.Models;
namespace EmployeeConsoleEFCodeFirst.Service.Intefaces;
public interface IRoleManager
{
    List<RoleDTO> GetAllRoles();
    void AddRole(RoleDTO role);
    RoleDTO GetRoleById(int roleId);
    void EditRole(RoleDTO updatedRole);
    bool IsRoleIdValid(int roleId);
}
