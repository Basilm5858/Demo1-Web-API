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
        private readonly IVehicle vehicle;
        public VehicleController(IUnitOfWork unitOfWork, IVehicle vehicle)
        {
            this.unitOfWork = unitOfWork;
            this.vehicle = vehicle;
        }

        [HttpPost("EndPoint1")]
        public IActionResult EndPoint1()
        {

            return Ok("EndPoint1 called");
        }
    }
}
