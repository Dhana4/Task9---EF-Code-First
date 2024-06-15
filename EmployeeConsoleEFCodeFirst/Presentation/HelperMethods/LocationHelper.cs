using EmployeeConsoleEFCodeFirst.Models;
using EmployeeConsoleEFCodeFirst.Service.Intefaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace HelperMethods;
public class LocationHelper : ILocationHelper
{
    private readonly ILocationManager locationManager;
    public LocationHelper(ILocationManager locationManager)
    {
        this.locationManager = locationManager;
    }
    public bool DisplayAvailableLocations()
    {
        List<LocationDTO> locations = locationManager.GetAllLocations();
        if (locations.Count == 0)
        {
            return false;
        }
        foreach (LocationDTO location in locations)
        {
            Console.WriteLine($"Location Id: {location.LocationId}\nLocation Name: {location.LocationName}");
        }
        return true;
    }
}
