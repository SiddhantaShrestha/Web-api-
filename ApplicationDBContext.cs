using Microsoft.EntityFrameworkCore; // Importing the Entity Framework Core library to use DbContext and other EF features
using web_api.Entities; // Importing the namespace where the User entity is defined

namespace web_api // Defining the namespace for the application
{
    public class ApplicationDBContext : DbContext // Creating a database context class that inherits from DbContext
    {
        // Constructor for ApplicationDBContext that takes DbContextOptions and passes it to the base DbContext constructor
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }

        // Defining a DbSet property for the User entity, which represents a database table in EF Core
        public DbSet<User> Users { get; set; }
    }
}
