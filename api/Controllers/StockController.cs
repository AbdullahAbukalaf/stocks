using api.Data;
using api.DTO.Stock;
using api.Interfaces.StockServices;
using api.Mapper;
using api.Models;
using api.Validation;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IStockServices _stockServices;
        private readonly IValidator<CreateStockDTO> _createValidate;
        private readonly IValidator<UpdateStockDTO> _updateValidate;
        private readonly ILogger<StockController> _logger;
        public StockController(IStockServices stockServices,
            IValidator<CreateStockDTO> createValidate,
            IValidator<UpdateStockDTO> updateValidate,
            ILogger<StockController> logger)
        {
            _stockServices = stockServices;
            _createValidate = createValidate;
            _updateValidate = updateValidate;
            _logger = logger;
        }


        [HttpGet]
        public async Task<IActionResult> GetStocks()
        {
            try
            {
                var stocks = await _stockServices.GetStocks();
                return Ok(stocks);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while retrieving stocks: " + ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetStock([FromRoute] int id, CancellationToken ct = default)
        {
            try
            {
                var stock = await _stockServices.GetStock(id, ct);
                if (stock == null)
                {
                    return NotFound($"Stock with ID {id} not found.");
                }
                return Ok(stock);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while retrieving the stock: " + ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateStock([FromBody] CreateStockDTO stockDto, CancellationToken ct = default)
        {
            try
            {
                var validationResult = await _createValidate.ValidateAsync(stockDto, ct);
                if (!validationResult.IsValid) return BadRequest(validationResult.Errors);
                var createdStock = await _stockServices.CreateStock(stockDto, ct);
                return CreatedAtAction(nameof(GetStock), new { id = createdStock.Id }, createdStock);

            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while creating the stock: " + ex.Message);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateStock([FromRoute] int id, [FromBody] UpdateStockDTO stockDto, CancellationToken ct = default)
        {
            try
            {
                var validationResult = await _updateValidate.ValidateAsync(stockDto, ct);
                if (!validationResult.IsValid) return BadRequest(validationResult.Errors);
                var updatedStock = await _stockServices.UpdateStock(id, stockDto, ct);
                return updatedStock is null ? NotFound($"Stock with ID {id} not found.") : Ok(updatedStock);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while updating the stock: " + ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> SoftDeleteStock([FromRoute] int id, CancellationToken ct = default)
        {
            try
            {
                var result = await _stockServices.SoftDeleteStock(id, ct);
                if (!result) return NotFound($"Stock with ID {id} not found.");
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while deleting the stock: " + ex.Message);
            }
        }
    }
}
