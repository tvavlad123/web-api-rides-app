using System.Collections.Generic;
using GreenBridgeWebApi.Models;

namespace GreenBridgeWebApi.Contracts
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        IEnumerable<User> GetAllUsers();
        User GetUserById(int userId);
        void CreateUser(User user);
        void Delete(int userId);
        void UpdateUser(User dbUser, User user);

        IEnumerable<Ride> GetRidesByUser(int userId);

        User Login(string mail, string password);


    }

}