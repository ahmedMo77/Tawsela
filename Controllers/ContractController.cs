using Microsoft.AspNetCore.Mvc;
using Tawsela.Services.Interfaces;
using Tawsela.Entities;

namespace Tawsela.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContractController : ControllerBase
    {
        private readonly IContractService _contractService;

        public ContractController(IContractService contractService)
        {
            _contractService = contractService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var contracts = await _contractService.GetAllContractsAsync();
            return Ok(contracts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var contract = await _contractService.GetContractByIdAsync(id);
            if (contract == null)
                return NotFound();
            return Ok(contract);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Contract contract)
        {
            await _contractService.CreateContractAsync(contract);
            return CreatedAtAction(nameof(GetById), new { id = contract.Id }, contract);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Contract contract)
        {
            if (id != contract.Id)
                return BadRequest("Mismatched contract ID.");

            await _contractService.UpdateContractAsync(contract);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _contractService.DeleteContractAsync(id);
            return NoContent();
        }
    }

}
