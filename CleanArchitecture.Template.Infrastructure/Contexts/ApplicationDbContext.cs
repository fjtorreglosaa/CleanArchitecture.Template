using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Template.Infrastructure.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }
    }
}
