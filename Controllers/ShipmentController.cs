using Microsoft.AspNetCore.Mvc;
using Tawsela.Entities;
using Tawsela.Services.Interfaces;

namespace Tawsela.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShipmentController : ControllerBase
    {
        private readonly IShipmentService _shipmentService;

        public ShipmentController(IShipmentService shipmentService)
        {
            _shipmentService = shipmentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var shipments = await _shipmentService.GetAllShipmentsAsync();
            return Ok(shipments);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var shipment = await _shipmentService.GetShipmentByIdAsync(id);
            if (shipment == null)
                return NotFound();
            return Ok(shipment);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Shipment shipment)
        {
            await _shipmentService.CreateShipmentAsync(shipment);
            return CreatedAtAction(nameof(GetById), new { id = shipment.Id }, shipment);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Shipment shipment)
        {
            if (id != shipment.Id)
                return BadRequest("Mismatched shipment ID.");

            await _shipmentService.UpdateShipmentAsync(shipment);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _shipmentService.DeleteShipmentAsync(id);
            return NoContent();
        }
    }

}
