using ArmorFeedApi.Enterprises.Domain.Repositories;
using ArmorFeedApi.Shared.Domain.Repositories;
using ArmorFeedApi.Shipments.Domain.Models;
using ArmorFeedApi.Shipments.Domain.Repositories;
using ArmorFeedApi.Shipments.Services;
using ArmorFeedApi.Vehicles.Domain.Models;
using ArmorFeedApi.Vehicles.Domain.Repositories;
using ArmorFeedApi.Vehicles.Services;
using Moq;
using Xunit;

namespace ArmorFeedTest.ShipmentsTest;

public class ShipmentServiceTests
{
    [Fact]
    public void ShipmentStatusShouldBeFinalized()
    {
        var shipmentRepositoryMock = new Mock<IShipmentRepository>();
        var unitOfWorkMock = new Mock<IUnitOfWork>();

        var shipment = new Shipment
        {
            Id = 1,
            PickUpDate = "2023-8-10",
            DeliveryDate = "2023-8-11",
            Status = "Pendient",
            UserConfirmed = true,
            EnterpriseConfirmed = true,
            Origin = "Amazonas",
            OriginTypeAddress = "House",
            OriginAddress = "Jr. Junin",
            OriginUrbanization = "Urb. 2",
            Destiny = "Ancash",
            DestinyTypeAddress = "Deparment",
            DestinyAddress = "Jr. Olimpo",
            DestinyUrbanization = "Urb. 1",
            DestinyReference = "Frente a una gasolinera",
            EnterpriseId = 1,
            VehicleId = 1,
            CustomerId = 1 
        };

        shipmentRepositoryMock.Setup(repo => repo.FindByIdAsync(1)).ReturnsAsync(shipment);

        var shipmentService = new ShipmentService(shipmentRepositoryMock.Object, unitOfWorkMock.Object);

        shipmentService.UpdateStatusWhenConfirmed(shipment.Id, shipment);

        var result = shipmentService.GetByIdAsync(1).Result;

        Assert.Equal("Finalized", result.Status);
    }

    [Fact]
    public async Task AssigningVehicle()
    {
        var unitOfWork = new Mock<IUnitOfWork>();
        var vehicleRepository = new Mock<IVehicleRepository>();
        var enterpriseRepository = new Mock<IEnterpriseRepository>();
        var shipmentRepository = new Mock<IShipmentRepository>();
    
        var vehicle = new Vehicle
        {
            Id = 1,
            Brand = "Toyota",
            LicensePlate = "ABC123",
            Year = 2023,
            Model = "Corolla",
            MaintenanceDate = "26-12-2023",
            VehicleType = "Free",
            EnterpriseId = 1
        };
    
        var shipment = new Shipment
        {
            Id = 1,
            PickUpDate = "2023-8-10",
            DeliveryDate = "2023-8-11",
            Status = "Pendient",
            UserConfirmed = true,
            EnterpriseConfirmed = true,
            Origin = "Amazonas",
            OriginTypeAddress = "House",
            OriginAddress = "Jr. Junin",
            OriginUrbanization = "Urb. 2",
            Destiny = "Ancash",
            DestinyTypeAddress = "Department",
            DestinyAddress = "Jr. Olimpo",
            DestinyUrbanization = "Urb. 1",
            DestinyReference = "Frente a una gasolinera",
            EnterpriseId = 1,
            VehicleId = 0,
            CustomerId = 1
        };
    
        vehicleRepository.Setup(repo => repo.FindByIdAsync(1)).ReturnsAsync(vehicle);
        var vehicleService = new VehicleService(vehicleRepository.Object, enterpriseRepository.Object, unitOfWork.Object);
        var vehicleResult = vehicleService.FindByIdAsync(1).Result;
        
        shipmentRepository.Setup(repo => repo.FindByIdAsync(1)).ReturnsAsync(shipment);
        var shipmentService = new ShipmentService(shipmentRepository.Object, unitOfWork.Object);
        var shipmentResult = shipmentService.GetByIdAsync(1).Result;
        
        Assert.Equal(0, shipmentResult.VehicleId);
        Assert.Equal("Free", vehicleResult.VehicleType);
        
        shipment.VehicleId = vehicle.Id;
        shipment.Status = "In progress";
        await shipmentService.UpdateAsync(1, shipment);
        Assert.Equal(vehicle.Id, shipment.VehicleId);
    }
}
