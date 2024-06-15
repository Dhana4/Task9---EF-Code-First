using EmployeeConsoleEFCodeFirst.Data.Interfaces;
using EmployeeConsoleEFCodeFirst.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeConsoleEFCodeFirst.Data;

public class LocationRepository : ILocationRepository
{
    private readonly EmployeeDBContext dbContext;

    public LocationRepository(EmployeeDBContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public void AddLocation(Location location)
    {
        dbContext.Locations.Add(location);
        dbContext.SaveChanges();
    }

    public void EditLocation(Location updatedLocation)
    {
        Location existingLocation = dbContext.Locations.Find(updatedLocation.LocationId);
        if (existingLocation != null)
        {
            dbContext.Entry(existingLocation).State = EntityState.Detached;
            dbContext.Locations.Update(updatedLocation);
            dbContext.SaveChanges();
        }
    }

    public List<Location> GetAllLocations()
    {
        return dbContext.Locations.ToList();
    }

    public Location GetLocationById(int locationId)
    {
        return dbContext.Locations.Find(locationId);
    }
    public bool IsLocationIdValid(int locationId)
    {
        bool isLocationIdValid = false;
        List<Location> locations = GetAllLocations();
        foreach (Location location in locations)
        {
            if (location.LocationId == locationId)
            {
                isLocationIdValid = true;
            }
        }
        return isLocationIdValid;
    }
}
