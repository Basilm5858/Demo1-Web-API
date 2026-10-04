using AutoMapper;
using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo1.DTOs;
using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo1.Models;
using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo1.Repo.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ISales repo;
        private readonly IMapper _mapper;
        public SaleController(IUnitOfWork unitOfWork, ISales repo, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.repo = repo;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var employee = await repo.GetByIdAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            var res = _mapper.Map<SalesDTO>(employee);

            return Ok(res);
        }

        [HttpPost("EndPoint1")]
        public async Task<IActionResult> Create(CreateSaleDTO dto)
        {
            var sale = _mapper.Map<Sale>(dto);

            await repo.AddAsync(sale);
            await unitOfWork.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = sale.Id }, sale);
        }

        [HttpGet("EndPoint2")]
        public async Task<IActionResult> GetAll()
        {
            var employee = await repo.GetSalesGroupedByEmployee();
            if (employee == null)
            {
                return NotFound();
            }

            var res = _mapper.Map<ICollection<EmployeeWithSalesDto>>(employee);

            return Ok(res);
        }

        [HttpPut("EndPoint3")]
        public async Task<IActionResult> Update(int id, UpdateSaleDTO dto)
        {
            var sale = await repo.GetByIdAsync(id);
            if (sale == null)
            {
                return NotFound();
            }
            var res = _mapper.Map(dto, sale);
            await unitOfWork.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("EndPoint4")]
        public async Task<IActionResult> Delete(int id)
        {
            var sale = await repo.GetByIdAsync(id);

            if (sale == null)
            {
                return NotFound();
            }

            repo.DeleteAsync(sale);

            await unitOfWork.SaveChangesAsync();

            return NoContent();
        }
    }
}
