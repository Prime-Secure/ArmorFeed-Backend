using ArmorFeedApi.Shipments.Domain.Models;
using ArmorFeedApi.Shipments.Domain.Services;
using ArmorFeedApi.Shipments.Resources;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ArmorFeedApi.Shipments.Controllers;

public class ShipmentsVehicleController
{
    private readonly IShipmentService _shipmentService;
    private readonly IMapper _mapper;


    public ShipmentsVehicleController(IShipmentService shipmentService, IMapper mapper)
    {
        _shipmentService = shipmentService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<ShipmentResource>> GetAllByVehicleId(int vehicleId)
    {
        var shipments = await _shipmentService.ListByVehicleId(vehicleId);
        var resources = _mapper.Map<IEnumerable<Shipment>, IEnumerable<ShipmentResource>>(shipments);
        return resources;
    }
}