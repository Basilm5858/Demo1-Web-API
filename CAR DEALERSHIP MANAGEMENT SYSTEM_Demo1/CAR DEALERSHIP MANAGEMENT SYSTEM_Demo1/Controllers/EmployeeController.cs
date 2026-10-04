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
    public class EmployeeController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IEmployee repo;
        private readonly IMapper _mapper;
        public EmployeeController(IUnitOfWork unitOfWork, IEmployee repo, IMapper mapper)
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
            var res = _mapper.Map<EmployeeDTO>(employee);

            return Ok(res);
        }

        [HttpPost("EndPoint1")]
        public async Task<IActionResult> Create(CreateEmployeeDTO dto)
        {
            var employee = _mapper.Map<Employee>(dto);

            await repo.AddAsync(employee);
            await unitOfWork.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = employee.Id }, employee);
        }

        [HttpGet("EndPoint2")]
        public async Task<IActionResult> GetAll()
        {
            var employee = await repo.EndPoint2();
            if (employee == null)
            {
                return NotFound();
            }

            var res = _mapper.Map<ICollection<EmployeeDTO>>(employee);

            return Ok(res);
        }

        [HttpPut("EndPoint3")]
        public async Task<IActionResult> Update(int id, UpdateEmployeeDTO dto)
        {
            var employee = await repo.GetByIdAsync(id);
            if(employee == null)
            {
                return NotFound();
            }
            var res = _mapper.Map(dto, employee);
            await unitOfWork.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("EndPoint4")]
        public async Task<IActionResult> Delete(int id)
        {
            var employee = await repo.GetByIdAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            repo.DeleteAsync(employee);

            await unitOfWork.SaveChangesAsync();

            return NoContent();
        }
    }
}
