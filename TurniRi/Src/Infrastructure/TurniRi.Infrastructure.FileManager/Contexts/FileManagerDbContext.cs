using Microsoft.EntityFrameworkCore;
using TurniRi.Infrastructure.FileManager.Models;

namespace TurniRi.Infrastructure.FileManager.Contexts
{
    public class FileManagerDbContext(DbContextOptions<FileManagerDbContext> options) : DbContext(options)
    {
        public DbSet<FileEntity> Files { get; set; }
    }
}
