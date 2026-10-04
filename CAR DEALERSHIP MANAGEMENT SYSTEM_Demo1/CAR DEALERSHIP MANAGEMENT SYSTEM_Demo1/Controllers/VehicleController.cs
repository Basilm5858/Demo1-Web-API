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
    public class VehicleController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IVehicle repo;
        private readonly IMapper _mapper;
        public VehicleController(IUnitOfWork unitOfWork, IVehicle repo, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.repo = repo;
            _mapper = mapper;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var vehicle = await repo.GetByIdAsync(id);
            if (vehicle == null)
            {
                return NotFound();
            }
            var res = _mapper.Map<VehicleDTO>(vehicle);
            return Ok(res);
        }

        [HttpPost("EndPoint1")]
        public async Task<IActionResult> Create(CreateVehicleDTO dto)
        {
            var res = _mapper.Map<Vehicle>(dto);

            await repo.AddAsync(res);
            await unitOfWork.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = res.Id }, res);

        }

        [HttpGet("EndPoint2")]
        public async Task<IActionResult> GetAll()
        {
            var vehicle = await repo.EndPoint2();
            if (vehicle == null)
            {
                return NotFound();
            }
            var res = _mapper.Map<ICollection<VehicleDTO>>(vehicle);
            return Ok(res);
        }

        [HttpPut("EndPoint3")]
        public async Task<IActionResult> Update(int id, UpdateVehicleDTO dto)
        {
            var vehicle = await repo.GetByIdAsync(id);

            var res = _mapper.Map(dto, vehicle);
            await unitOfWork.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("EndPoint4")]
        public async Task<IActionResult> Delete(int id)
        {
            var vehicle = await repo.GetByIdAsync(id);

            if (vehicle == null)
            {
                return NotFound();
            }
            repo.DeleteAsync(vehicle);

            await unitOfWork.SaveChangesAsync();

            return NoContent();
        }

    }
}
