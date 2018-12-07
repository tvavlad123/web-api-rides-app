using GreenBridgeWebApi.Models;

namespace GreenBridgeWebApi.Extensions
{
    public static class CarExtensions
    {
        public static void Map(this Car dbCar, Car car)
        {
            dbCar.Iduser = car.Iduser;
            dbCar.CarNumber = car.CarNumber;
            dbCar.Model = car.Model;
            dbCar.Colour = car.Colour;
        }
    }
}