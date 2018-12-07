using System.Collections.Generic;
using System.Linq;
using GreenBridgeWebApi.Contracts;
using GreenBridgeWebApi.Extensions;
using GreenBridgeWebApi.Models;
using Repository;

namespace GreenBridgeWebApi.Repository
{
    public class CarRepository : RepositoryBase<Car>, ICarRepository
    {
        public CarRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }


        public IEnumerable<Car> GetAllCars()
        {
            return FindAll()
                .OrderBy(car => car.CarNumber);
        }

        public Car GetCarById(int carId)
        {
            return FindByCondition(car => car.Idcar.Equals(carId))
                    .DefaultIfEmpty(new Car())
                    .FirstOrDefault();
        }

        public void Delete(int carId)
        {
            var target = FindByCondition(car => car.Idcar.Equals(carId)).FirstOrDefault();
            Delete(target);
        }
        public void CreateCar(Car car)
        {
            Create(car);
            Save();
        }

        public void UpdateCar(Car dbCar, Car car)
        {
            dbCar.Map(car);
            Update(dbCar);
            Save();
        }
    }
}