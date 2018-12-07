namespace GreenBridgeWebApi.Contracts
{
     public interface IRepositoryWrapper
    {
        ICarRepository Car { get; }
        IUserRepository User { get; }
        IRideRepository Ride { get; }
        IUserRideRepository UserRide { get; }
    }
}