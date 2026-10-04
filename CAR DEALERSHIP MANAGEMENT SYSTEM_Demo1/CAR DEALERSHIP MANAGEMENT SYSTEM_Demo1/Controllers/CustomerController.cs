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
    public class CustomerController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ICustomer repo;
        private readonly IMapper _mapper;
        public CustomerController(IUnitOfWork unitOfWork, ICustomer repo, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.repo = repo;
            _mapper = mapper;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var customer = await repo.GetByIdAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            var res = _mapper.Map<CustomerDTO>(customer);
            return Ok(res);
        }
        [HttpPost("EndPoint1")]
        public async Task<IActionResult> Create(CreateCustomerDTO dto)
        {
            var customer = _mapper.Map<Customer>(dto);

            await repo.AddAsync(customer);
            await unitOfWork.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = customer.Id }, customer);
        }
        [HttpGet("EndPoint2")]
        public async Task<IActionResult> GetAll()
        {
            var customer = await repo.EndPoint2();
            if (customer == null)
            {
                return NotFound();
            }
            var res = _mapper.Map<ICollection<CustomerDetailDto>>(customer);

            return Ok(res);
        }
        [HttpPut("EndPoint3")]
        public async Task<IActionResult> Update(int id, UpdateCustomerDTO dto)
        {
            var customer = await repo.GetByIdAsync(id);

            var res = _mapper.Map(dto, customer);
            await unitOfWork.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("EndPoint4")]
        public async Task<IActionResult> Delete(int id)
        {
            var customer = await repo.GetByIdAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            repo.DeleteAsync(customer);

            await unitOfWork.SaveChangesAsync();

            return NoContent();
        }
    }
}
