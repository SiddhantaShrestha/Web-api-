using web_api.Entities;

namespace web_api.Repo
{
    
        public interface IUserRepo
        {
        void AddUser(User user);
        void DeleteUser(User user);
        void UpdateUser(User user);
        User? GetUserByEmail(string email);
    }
    
}
