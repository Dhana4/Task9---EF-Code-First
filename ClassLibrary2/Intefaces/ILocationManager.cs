using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeConsoleEFCodeFirst.Models;
namespace EmployeeConsoleEFCodeFirst.Service.Intefaces;

public interface ILocationManager
{
    List<LocationDTO> GetAllLocations();
    void AddLocation(LocationDTO location);
    LocationDTO GetLocationById(int locationId);
    void EditLocation(LocationDTO updatedLocation);
    bool IsLocationIdValid(int locationId);
}
