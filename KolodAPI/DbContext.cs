using KolodAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace KolodAPI
{
    public class DatabaseContext : DbContext
    {
        public DbSet<DeckModel> DecksTable { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }
    }
}
