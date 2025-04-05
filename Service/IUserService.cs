using web_api.DTO;
using web_api.Entities;

namespace web_api.Service
{
    public interface IUserService
    {
        bool AddUser(UserRegisterDTO user);
        bool UpdateUser(string email, UserRegisterDTO updatedUser);
        bool DeleteUser(string email);
        User? FindUser(string email);

    }
}