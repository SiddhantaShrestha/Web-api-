using Microsoft.EntityFrameworkCore;
using web_api.Entities;

namespace web_api.Repo
{
    public class UserRepo: IUserRepo
    {
        private ApplicationDBContext _context;
        public UserRepo(ApplicationDBContext context) 
        {
            _context = context;
        }

        public void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void DeleteUser(User user)
        {
            var existingUser = _context.Users.Find(user.Id);
            if (existingUser != null)
            {
                _context.Users.Remove(existingUser);
                _context.SaveChanges();
            }
        }

        public void UpdateUser(User user)
        {
            var existingUser = _context.Users.FirstOrDefault(u => u.Email == user.Email);
            if (existingUser != null)
            {
                existingUser.Phone = user.Phone;
                existingUser.Name = user.Name;
                existingUser.Password = user.Password;
                existingUser.Username = user.Username;

                _context.SaveChanges();
            }
        }

        public User? GetUserByEmail(string email)
        {
            return _context.Users.FirstOrDefault(u => u.Email == email);
        }

        public void InsertUser(User newUser)
        {
            _context.Users.Add(newUser);
            _context.SaveChanges();
        }
    }
}
