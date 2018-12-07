using System;
using GreenBridgeWebApi.Contracts;
using GreenBridgeWebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace GreenBridgeWebApi.Controllers
{
    [Route("/api/car")]
    public class CarController : Controller
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;

        public CarController(ILoggerManager logger, IRepositoryWrapper repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAllCars()
        {
            try
            {
                var cars = _repository.Car.GetAllCars();

                _logger.LogInfo("Returned all cars from database.");

                return Ok(cars);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllCars action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}", Name = "CarById")]
        public IActionResult GetCarById(int id)
        {
            try
            {
                var car = _repository.Car.GetCarById(id);

                if (car == null)
                {
                    _logger.LogError($"Car with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned car with id: {id}");
                    return Ok(car);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetCarById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult CreateCar([FromBody]Car car)
        {
            try
            {
                if (car == null)
                {
                    _logger.LogError("Car object sent from client is null.");
                    return BadRequest("Car object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid car object sent from client.");
                    return BadRequest("Invalid model object");
                }

                _repository.Car.CreateCar(car);

                return CreatedAtRoute("CarById", new { id = car.Idcar }, car);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateUser action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            this._repository.Car.Delete(id);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCar(int id, [FromBody]Car car)
        {
            try
            {
                if (car == null)
                {
                    _logger.LogError("Car object sent from client is null.");
                    return BadRequest("Car object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid car object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var dbCar = _repository.Car.GetCarById(id);
                if (dbCar.Idcar == 0)
                {
                    _logger.LogError($"Car with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _repository.Car.UpdateCar(dbCar, car);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateCar action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}