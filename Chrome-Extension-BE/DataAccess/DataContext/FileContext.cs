using Chrome_Extension_BE.Models;
using Microsoft.EntityFrameworkCore;

namespace Chrome_Extension_BE.DataAccess.DataContext
{
    public class FileContext : DbContext
    {
        public FileContext(DbContextOptions<FileContext> options) : base(options) 
        {
            
        }

        public DbSet<FileModel> Files { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
