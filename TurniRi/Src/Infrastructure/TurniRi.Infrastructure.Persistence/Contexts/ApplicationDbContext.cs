using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TurniRi.Application.Interfaces;
using TurniRi.Domain.Products.Entities;
using TurniRi.Infrastructure.Persistence.Extensions;

namespace TurniRi.Infrastructure.Persistence.Contexts
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IAuthenticatedUserService authenticatedUser) : DbContext(options)
    {
        public DbSet<Product> Products { get; set; }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
        {
            ChangeTracker.ApplyAuditing(authenticatedUser);

            return base.SaveChangesAsync(cancellationToken);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            this.ConfigureDecimalProperties(builder);

            base.OnModelCreating(builder);
        }
    }
}