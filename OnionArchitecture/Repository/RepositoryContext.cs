using Entities.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class RepositoryContext(DbContextOptions options) : IdentityDbContext<User>(options)
    {
    }
}
