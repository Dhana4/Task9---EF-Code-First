using EmployeeConsoleEFCodeFirst.Models;
using EmployeeConsoleEFCodeFirst.Service.Intefaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
namespace HelperMethods;
public class RoleHelper : IRoleHelper
{
    private readonly IRoleManager roleManager;
    private readonly ILocationManager locationManager;
    private readonly IDepartmentManager departmentManager;
    private readonly IDepartmentHelper departmentHelper;
    private readonly ILocationHelper locationHelper;
    public RoleHelper(IRoleManager roleManager, ILocationManager locationManager, IDepartmentManager departmentManager, IDepartmentHelper departmentHelper, ILocationHelper locationHelper)
    {
        this.roleManager = roleManager;
        this.locationManager = locationManager;
        this.departmentManager = departmentManager;
        this.departmentHelper = departmentHelper;
        this.locationHelper = locationHelper;
    }
    public bool DisplayAvailableRoles()
    {
        var roles = roleManager.GetAllRoles();
        if (roles.Count == 0)
        {
            Console.WriteLine("No Roles Exist. Please Add a role first");
            return false;
        }
        Console.WriteLine("Available Roles:");
        foreach (var role in roles)
        {
            Console.WriteLine("-------------------------------------");
            Console.WriteLine($"ID: {role.RoleId}\n, Role Name: {role.RoleName}\n Description: {role.Description}");
            LocationDTO locationDTO = locationManager.GetLocationById(role.LocationId);
            Console.WriteLine($"Location: {locationDTO.LocationName}");
            DepartmentDTO departmentDTO = departmentManager.GetDepartmentById(role.DepartmentId);
            Console.WriteLine($"Department: {departmentDTO.DepartmentName}\n");
        }
        return true;
    }
    public int ChooseRoleId()
    {
        int roleId = default;
        string roleIdString = string.Empty;
        bool roleIdEntered = false;
        while (!roleIdEntered)
        {
            Console.WriteLine("Enter Role ID:");
            roleIdString = Console.ReadLine() ?? string.Empty;
            if (int.TryParse(roleIdString, out roleId))
            {
                if (roleManager.IsRoleIdValid(roleId))
                {
                    roleIdEntered = true;
                }
                else
                {
                    Console.WriteLine("Invalid role ID! Please enter a valid ID from the available roles.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input! Please enter a valid integer value for Role ID.");
            }
        }
        return roleId;
    }
    public void AddRole()
    {
        Console.WriteLine("Enter Role Name");
        bool roleNameEntered = false;
        string roleName = string.Empty;
        while (!roleNameEntered)
        {
            roleName = Console.ReadLine() ?? string.Empty;
            if (!string.IsNullOrWhiteSpace(roleName) && Regex.IsMatch(roleName, "^[a-zA-Z ]+$"))
            {
                roleNameEntered = true;
            }
            else
            {
                Console.WriteLine("Invalid First Name! Please Enter again");
            }
        }
        Console.WriteLine("Choose  Department Id");
        bool IsDepartmentsAvailable = departmentHelper.DisplayAvailableDepartments();
        if (!IsDepartmentsAvailable)
        {
            Console.WriteLine("No Departments available");
            return;
        }
        bool roleDepartmentEntered = false;
        string roleDepartmentString = string.Empty;
        int roleDepartment = 0;
        while (!roleDepartmentEntered)
        {
            roleDepartmentString = Console.ReadLine() ?? string.Empty;
            if (int.TryParse(roleDepartmentString, out roleDepartment) && departmentManager.IsDepartmentIdValid(roleDepartment))
            {
                roleDepartmentEntered = true;
            }
            else
            {
                Console.WriteLine("Invalid Department! Please Enter again");
            }
        }
        Console.WriteLine("Enter Role Description(Press Enter to skip)");
        string? roleDescription = null;
        roleDescription = Console.ReadLine();
        Console.WriteLine("choose Location Id");
        bool IsLocationsAvailable = locationHelper.DisplayAvailableLocations();
        if (!IsLocationsAvailable)
        {
            Console.WriteLine("No Locations available");
            return;
        }
        bool locationEntered = false;
        string locationString = string.Empty;
        int location = 0;
        while (!locationEntered)
        {
            locationString = Console.ReadLine() ?? string.Empty;
            if (int.TryParse(locationString, out location) && locationManager.IsLocationIdValid(location))
            {
                locationEntered = true;
            }
            else
            {
                Console.WriteLine("Invalid Location! Please Enter again");
            }
        }

        var newRole = new RoleDTO
        {
            RoleName = roleName,
            DepartmentId = roleDepartment,
            Description = roleDescription,
            LocationId = location
        };
        roleManager.AddRole(newRole);
        Console.WriteLine("Role added successfully!");
    }
    public void EditRole()
    {

        DisplayAvailableRoles();
        int roleId = ChooseRoleId();
        RoleDTO role = roleManager.GetRoleById(roleId);
        Console.WriteLine("Do you want to edit Role Name(Y/N)");
        string roleNameToEdit = string.Empty;
        string roleNameOption = string.Empty;
        bool roleNameOptionEntered = false;
        bool roleNameToEditEntered = false;
        while (!roleNameOptionEntered)
        {
            roleNameOption = Console.ReadLine() ?? string.Empty;
            if (roleNameOption.ToLower()[0] == 'y' || roleNameOption.ToLower()[0] == 'n')
            {
                roleNameOptionEntered = true;
            }
            else
            {
                Console.WriteLine("Invalid Option entered! Please enter again");
            }
        }
        if (roleNameOption.ToLower()[0] == 'y')
        {
            Console.WriteLine("Enter Role Name to edit");
            while (!roleNameToEditEntered)
            {
                roleNameToEdit = Console.ReadLine() ?? string.Empty;
                if (Regex.IsMatch(roleNameToEdit, "^[a-zA-Z ]+$"))
                {
                    roleNameToEditEntered = true;
                }
                else
                {
                    Console.WriteLine("Invalid Role Name! Please Enter again");
                }
            }
        }
        else
        {
            roleNameToEdit = role.RoleName;
        }
        Console.WriteLine("Do you want to edit Department(Y/N)");
        string departmentIdToEditAsString = string.Empty;
        int departmentIdToEdit = 0;
        string departmentOption = string.Empty;
        bool departmentOptionEntered = false;
        bool departmentToEditEntered = false;
        while (!departmentOptionEntered)
        {
            departmentOption = Console.ReadLine() ?? string.Empty;
            if (departmentOption.ToLower()[0] == 'y' || departmentOption.ToLower()[0] == 'n')
            {
                departmentOptionEntered = true;
            }
            else
            {
                Console.WriteLine("Invalid Option entered! Please enter again");
            }
        }
        if (departmentOption.ToLower()[0] == 'y')
        {
            bool IsDepartmentsAvailable = departmentHelper.DisplayAvailableDepartments();
            if (!IsDepartmentsAvailable)
            {
                Console.WriteLine("No Departments available");
                return;
            }
            Console.WriteLine("choose department to edit");
            while (!departmentToEditEntered)
            {
                departmentIdToEditAsString = Console.ReadLine() ?? string.Empty;
                if (int.TryParse(departmentIdToEditAsString, out departmentIdToEdit) && departmentManager.IsDepartmentIdValid(departmentIdToEdit))
                {
                    departmentToEditEntered = true;
                }
                else
                {
                    Console.WriteLine("Invalid department! Please Enter again");
                }
            }
        }
        else
        {
            departmentIdToEdit = role.DepartmentId;
        }
        Console.WriteLine("Do you want to edit Description(Y/N)");
        string? descriptionToEdit = null;
        string descriptionOption = string.Empty;
        bool descriptionOptionEntered = false;
        while (!descriptionOptionEntered)
        {
            descriptionOption = Console.ReadLine() ?? string.Empty;
            if (descriptionOption.ToLower()[0] == 'y' || descriptionOption.ToLower()[0] == 'n')
            {
                descriptionOptionEntered = true;
            }
            else
            {
                Console.WriteLine("Invalid Option entered! Please enter again");
            }
        }
        if (descriptionOption.ToLower()[0] == 'y')
        {
            Console.WriteLine("Enter description to edit");
            descriptionToEdit = Console.ReadLine();
        }
        else
        {
            descriptionToEdit = role.Description;
        }
        Console.WriteLine("Do you want to edit Location(Y/N)");
        string locationIdToEditAsString = string.Empty;
        int locationIdToEdit = 0;
        string locationOption = string.Empty;
        bool locationOptionEntered = false;
        bool locationToEditEntered = false;
        while (!locationOptionEntered)
        {
            locationOption = Console.ReadLine() ?? string.Empty;
            if (locationOption.ToLower()[0] == 'y' || locationOption.ToLower()[0] == 'n')
            {
                locationOptionEntered = true;
            }
            else
            {
                Console.WriteLine("Invalid Option entered! Please enter again");
            }
        }
        if (locationOption.ToLower()[0] == 'y')
        {
            bool IsLocationsAvailable = locationHelper.DisplayAvailableLocations();
            if (!IsLocationsAvailable)
            {
                Console.WriteLine("No Locations available");
                return;
            }
            Console.WriteLine("Choose location to edit");
            while (!locationToEditEntered)
            {
                locationIdToEditAsString = Console.ReadLine() ?? string.Empty;
                if (int.TryParse(locationIdToEditAsString, out locationIdToEdit) && locationManager.IsLocationIdValid(locationIdToEdit))
                {
                    locationToEditEntered = true;
                }
                else
                {
                    Console.WriteLine("Invalid location! Please Enter again");
                }
            }
        }
        else
        {
            locationIdToEdit = role.LocationId;
        }
        var updatedRole = new RoleDTO()
        {
            RoleId = roleId,
            RoleName = roleNameToEdit,
            Description = descriptionToEdit,
            DepartmentId = departmentIdToEdit,
            LocationId = locationIdToEdit
        };
        roleManager.EditRole(updatedRole);
        Console.WriteLine("Role Updated successfully!");

    }
}
