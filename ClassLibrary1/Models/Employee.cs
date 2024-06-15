using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
namespace EmployeeConsoleEFCodeFirst.Data.Models;
public class Employee
{
    [Key]
    public int EmpId { get; set; }
    public string FirstName { get; set; }
    public string? LastName { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string Email { get; set; }
    public string? Mobile { get; set; }
    public DateTime JoiningDate { get; set; }
    public int RoleId { get; set; }
    public string? Manager { get; set; }
    public string? Project { get; set; }
    public virtual Role Role { get; set; }
}
