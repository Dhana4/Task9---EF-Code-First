using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeConsoleEFCodeFirst.Data.Models;

public class Location
{
    [Key]
    public int LocationId { get; set; }
    public string LocationName { get; set; } = string.Empty;
    public virtual ICollection<Role> Roles { get; set; }
}
