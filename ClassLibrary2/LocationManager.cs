using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeConsoleEFCodeFirst.Models;
using EmployeeConsoleEFCodeFirst.Service.Intefaces;
using EmployeeConsoleEFCodeFirst.Data.Interfaces;
using EmployeeConsoleEFCodeFirst.Data.Models;
using AutoMapper;
namespace EmployeeConsoleEFCodeFirst.Service;
public class LocationManager : ILocationManager
{
    private readonly ILocationRepository locationRepository;
    private readonly IMapper mapper;

    public LocationManager(ILocationRepository locationRepository, IMapper mapper)
    {
        this.locationRepository = locationRepository;
        this.mapper = mapper;
    }
    public void AddLocation(LocationDTO locationDTO)
    {
        Location location = mapper.Map<Location>(locationDTO);
        locationRepository.AddLocation(location);
    }

    public void EditLocation(LocationDTO updatedLocationDTO)
    {
        Location location = mapper.Map<Location>(updatedLocationDTO);
        locationRepository.EditLocation(location);
    }

    public List<LocationDTO> GetAllLocations()
    {
        List<Location> locations = locationRepository.GetAllLocations();
        return mapper.Map<List<LocationDTO>>(locations);
    }

    public LocationDTO GetLocationById(int locationId)
    {
        Location location = locationRepository.GetLocationById(locationId);
        return mapper.Map<LocationDTO>(location);
    }
    public bool IsLocationIdValid(int locationId)
    {
        return locationRepository.IsLocationIdValid(locationId);
    }
}
