using GreenBridgeWebApi.DTO;
using GreenBridgeWebApi.Models;

namespace GreenBridgeWebApi.Extensions
{
    public static class UserExtensions
    {
        public static void Map(this User dbUser, User user)
        {
            dbUser.FirstName = user.FirstName;
            dbUser.LastName = user.LastName;
            dbUser.Mail = user.Mail;
            dbUser.Password = user.Password;
            dbUser.Age = user.Age;
            dbUser.Gender = user.Gender;
            dbUser.PhoneNumber = user.PhoneNumber;
        }

        public static void Map(this UserDto userDto, User user)
        {
            if (user == null) return;
            userDto.Id = user.Id;
            userDto.FirstName = user.FirstName;
            userDto.LastName = user.LastName;
            userDto.Mail = user.Mail;
            userDto.Password = user.Password;
            userDto.Age = user.Age;
            userDto.Gender = user.Gender;
            userDto.PhoneNumber = user.PhoneNumber;
        }
    }
}