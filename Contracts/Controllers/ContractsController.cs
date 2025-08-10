using Microsoft.AspNetCore.Mvc;
using Contracts.Models;
using ContractService.Services;

namespace ContractsService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContractController : ControllerBase
    {
        private readonly ContractServices _service;
        public ContractController(ContractServices service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contract>>> GetAll()
        {
            var contracts = await _service.GetAllAsync();
            return Ok(contracts);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Contract>> GetById(int id)
        {
            var contract = await _service.GetByIdAsync(id);
            return contract == null ? NotFound() : Ok(contract);
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(Contract contract)
        {
            var createdContract = await _service.AddAsync(contract);
            return CreatedAtAction(nameof(GetById), new { id = createdContract.Id }, createdContract);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Contract contract)
        {
               if (id != contract.Id)
                    return BadRequest();

                var updated = await _service.UpdateAsync(contract);
                if (!updated)
                    return NotFound();

                return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteByIdAsync(id);
            
            return NoContent();
        }
    }
}