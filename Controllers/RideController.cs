using System;
using GreenBridgeWebApi.Contracts;
using GreenBridgeWebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace GreenBridgeWebApi.Controllers
{
    [Route("/api/ride")]
    public class RideController : Controller
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;

        public RideController(ILoggerManager logger, IRepositoryWrapper repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAllRides()
        {
            try
            {
                var rides = _repository.Ride.GetAllRides();

                _logger.LogInfo("Returned all rides from database.");

                return Ok(rides);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllRides action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}", Name = "RideById")]
        public IActionResult GetRideById(int id)
        {
            try
            {
                var ride = _repository.Ride.GetRideById(id);

                if (ride == null)
                {
                    _logger.LogError($"Ride with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned ride with id: {id}");
                    return Ok(ride);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetUserById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult CreateRide([FromBody]Ride ride)
        {
            try
            {
                if (ride == null)
                {
                    _logger.LogError("Ride object sent from client is null.");
                    return BadRequest("Ride object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid ride object sent from client.");
                    return BadRequest("Invalid model object");
                }

                _repository.Ride.CreateRide(ride);

                return CreatedAtRoute("RideById", new { id = ride.RideId }, ride);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateRide action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            this._repository.Ride.Delete(id);
            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult UpdateRide(int id, [FromBody]Ride ride)
        {
            try
            {
                if (ride == null)
                {
                    _logger.LogError("Ride object sent from client is null.");
                    return BadRequest("Ride object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid ride object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var dbRide = _repository.Ride.GetRideById(id);
                if (dbRide.RideId == 0)
                {
                    _logger.LogError($"Ride with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _repository.Ride.UpdateRide(dbRide, ride);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateRide action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}