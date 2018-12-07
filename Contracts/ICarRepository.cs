using System.Collections.Generic;
using GreenBridgeWebApi.Models;

namespace GreenBridgeWebApi.Contracts
{
    public interface ICarRepository : IRepositoryBase<Car>
    {
        IEnumerable<Car> GetAllCars();
        Car GetCarById(int carId);



        void Delete(int carId);

        void CreateCar(Car car);
        void UpdateCar(Car dbCar, Car car);

    }

}