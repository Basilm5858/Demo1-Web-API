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
    public class CategoryController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ICategory repo;
        private readonly IMapper _mapper;
        public CategoryController(IUnitOfWork unitOfWork, ICategory repo, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.repo = repo;
            _mapper = mapper;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await repo.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            var res = _mapper.Map<CategoryDTO>(category);
            return Ok(res);
        }

        [HttpPost("EndPoint1")]
        public async Task<IActionResult> Create(CreateCategoryDTO dto)
        {
            var res = _mapper.Map<Category>(dto);

            await repo.AddAsync(res);
            await unitOfWork.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = res.Id }, res);

        }

        [HttpGet("EndPoint2")]
        public async Task<IActionResult> GetAll()
        {
            var categories = await repo.GetAllAsync();
            if (categories == null)
            {
                return NotFound();
            }
            var res = _mapper.Map<ICollection<CategoryDTO>>(categories);
            return Ok(res);
        }

        [HttpPut("EndPoint3")]
        public async Task<IActionResult> Update(int id, UpdateVehicleDTO dto)
        {
            var categories = await repo.GetByIdAsync(id);

            var res = _mapper.Map(dto, categories);
            await unitOfWork.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("EndPoint4")]
        public async Task<IActionResult> Delete(int id)
        {

            var categories = await repo.GetByIdAsync(id);
            if(categories.Vehicles.Count != 0)
            {
                return BadRequest("there is vehciles");
            }

            if (categories == null)
            {
                return NotFound();
            }

            repo.DeleteAsync(categories);

            await unitOfWork.SaveChangesAsync();

            return NoContent();
        }
    }
}
