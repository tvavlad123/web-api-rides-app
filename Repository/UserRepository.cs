using System.Collections.Generic;
using System.Linq;
using GreenBridgeWebApi.Contracts;
using GreenBridgeWebApi.Extensions;
using GreenBridgeWebApi.Models;
using Repository;
using Microsoft.EntityFrameworkCore;

namespace GreenBridgeWebApi.Repository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public IEnumerable<User> GetAllUsers()
        {
            return FindAll()
                .OrderBy(us => us.FirstName);
        }

        public User GetUserById(int userId)
        {
            return FindByCondition(user => user.Id.Equals(userId))
                    .DefaultIfEmpty(new User())
                    .FirstOrDefault();
        }

        public void CreateUser(User user)
        {
            Create(user);
            Save();
        }

        public void Delete(int userId)
        {
            var target = FindByCondition(user => user.Id.Equals(userId)).FirstOrDefault();
            Delete(target);
            Save();
        }

        public void UpdateUser(User dbUser, User user)
        {
            dbUser.Map(user);
            Update(dbUser);
            Save();
        }

        public User Login(string mail, string password)
        {
            var target = FindByCondition(x => x.Mail.Equals(mail) && x.Password.Equals(password)).FirstOrDefault();
            if (target != null) return target;
            return null;
        }
    }
}