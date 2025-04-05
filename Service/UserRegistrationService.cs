using web_api.DTO;
using System.Collections.Generic;
using System.Linq;
using web_api.Repo;
using web_api.Entities; // Import User entity
using web_api.Service;

namespace web_api.Service
{
    public class UserRegistrationService: IUserService
    {
        // Temporary in-memory list to store users (Replace with DB in production)
        private static List<UserRegisterDTO> users = new List<UserRegisterDTO>();

        private readonly IUserRepo _userRepo;

        public UserRegistrationService(IUserRepo userRepo) 
        {
            _userRepo = userRepo;
        }

        public bool FindUser(string email)
        {
            return users.Any(user => user.Email == email);
        }

        public bool AddUser(UserRegisterDTO user)
        {
            // Check if user already exists in the database
            if (_userRepo.GetUserByEmail(user.Email) != null)
            {
                return false; // User already exists
            }

            // Create new User entity object
            var newUser = new User
            {
                Email = user.Email,
                Phone = user.Phone,
                Name = user.UserName,
                Password = user.Password,
                Username = user.UserName
            };

            // Save to the database
            _userRepo.AddUser(newUser); // Ensures it's stored persistently
            return true;
        }

        public bool DeleteUser(string email)
        {

            email = email.Trim().ToLower(); 
            var existingUser = _userRepo.GetUserByEmail(email);
            if (existingUser != null)
            {
                _userRepo.DeleteUser(existingUser);
                return true;
            }
            return false;
        }

       public bool UpdateUser(string email, UserRegisterDTO updatedUser)
{
    var existingUser = _userRepo.GetUserByEmail(email);
    if (existingUser != null)
    {
        // Update the user properties
        existingUser.Email = updatedUser.Email;
        existingUser.Phone = updatedUser.Phone;
        existingUser.Name = updatedUser.UserName;
        existingUser.Password = updatedUser.Password;
        existingUser.Username = updatedUser.UserName;

        // Save the updated user back to the repository
        _userRepo.UpdateUser(existingUser);

        return true;
    }
    return false;
}

     
    }
}
