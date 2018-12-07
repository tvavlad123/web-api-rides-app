using GreenBridgeWebApi.Contracts;
using GreenBridgeWebApi.Models;

namespace GreenBridgeWebApi.Repository
{
    public class RepositoryWrapper: IRepositoryWrapper
    {
        private RepositoryContext _repoContext;
        private ICarRepository _car;
        private IUserRepository _user;
        private IRideRepository _ride;
        private IUserRideRepository _userRide;
 
        public ICarRepository Car {
            get {
                if(_car == null)
                {
                    _car = new CarRepository(_repoContext);
                }
 
                return _car;
            }
        }

        public IUserRideRepository UserRide {
            get {
                if(_userRide == null)
                {
                    _userRide = new UserRideRepository(_repoContext);
                }
 
                return _userRide;
            }
        }

        public IRideRepository Ride {
            get {
                if(_ride == null)
                {
                    _ride = new RideRepository(_repoContext);
                }
 
                return _ride;
            }
        } 
        public IUserRepository User {
            get {
                if(_user == null)
                {
                    _user = new UserRepository(_repoContext);
                }
 
                return _user;
            }
        }
 
        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }
    }
}