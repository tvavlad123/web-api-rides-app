using GreenBridgeWebApi.Contracts;
using GreenBridgeWebApi.Models;
using Repository;

namespace GreenBridgeWebApi.Repository
{
    public class UserRideRepository: RepositoryBase<UserRide>, IUserRideRepository
    {
        public UserRideRepository(RepositoryContext repositoryContext)
            :base(repositoryContext)
        {
        }
    }
}