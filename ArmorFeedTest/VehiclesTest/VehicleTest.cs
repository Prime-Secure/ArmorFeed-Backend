using ArmorFeedApi.Enterprises.Domain.Repositories;
using ArmorFeedApi.Shared.Domain.Repositories;
using ArmorFeedApi.Vehicles.Domain.Models;
using ArmorFeedApi.Vehicles.Domain.Repositories;
using ArmorFeedApi.Vehicles.Services;
using Xunit;
using Moq;

namespace ArmorFeedTest.VehiclesTest;

public class VehicleTest
{
    
    [Fact]
    public void FreeVehicleTest()
    {
        var vehicleRepository = new Mock<IVehicleRepository>();
        var enterpriseRepository = new Mock<IEnterpriseRepository>();
        var unitOfWork = new Mock<IUnitOfWork>();
        
        var vehicle = new Vehicle
        {
            Id=1,
            Brand = "Msi",
            LicensePlate = "863321",
            Year = 2023,
            Model = "For",
            MaintenanceDate = "26-12-2023",
            VehicleType = "Free",
            EnterpriseId = 1,
        };
        
        vehicleRepository.Setup(repo => repo.FindByIdAsync(1)).ReturnsAsync(vehicle);
        
        var vehicleService = new VehicleService(vehicleRepository.Object, enterpriseRepository.Object, unitOfWork.Object);
        
        var result = vehicleService.FindByIdAsync(1).Result;
        
        Assert.Equal("Free", result.VehicleType);
        
        
    }
    
    
    
}