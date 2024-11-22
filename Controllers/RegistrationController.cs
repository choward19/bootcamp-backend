using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RegistrationValidationApp.Data;
using System.Threading.Tasks;
using RegistrationValidationApp.Models;
 
namespace RegistrationValidationApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly AppDbContext _context;
 
        public RegistrationController(AppDbContext context)
        {
            _context = context;
        }
 
        [HttpGet("validate")]
        public async Task<IActionResult> ValidateRegistration(string registrationNumber)
        {
            var registrationExists = await _context.Registrations
                .AnyAsync(r => r.RegistrationNumber == registrationNumber);
 
            if (registrationExists)
            {
                return Ok(new { Message = "Registration number exists." });
            }
            else
            {
                return NotFound(new { Message = "Registration number not found." });
            }
        }
        [HttpGet("electrified")]
        public ActionResult<Vehicle> CheckElectrified(string registrationNumber)
        {
            var vehicle = _context.Registrations
                .FirstOrDefault(r => r.RegistrationNumber == registrationNumber.ToUpper());
 
            if (vehicle != null)
            {
                return Ok(vehicle.Electrified);
            }
            else
            {
                return NotFound(new { Message = "Registration number not found." });
            }
        }
        [HttpGet("vehicles")]
        public ActionResult<IEnumerable<Vehicle>> GetVehicles()
        { 
            return Ok(_context.Registrations);
        }

        // [HttpGet("{vrn}")]
        // public ActionResult<Vehicle> GetVehicle(string vrn)
        // {
        //     // find vehicle
        //     var vehicleToReturn = VehiclesDataStore.Current.Vehicles
        //         .FirstOrDefault(c => c.VRN.ToLower() == vrn.ToLower());

        //     if (vehicleToReturn == null)
        //     {
        //         return NotFound();
        //     }

        //     return Ok(vehicleToReturn);
        // }
    }
}