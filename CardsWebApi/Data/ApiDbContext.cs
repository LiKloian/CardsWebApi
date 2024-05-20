using CardsWebApi.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CardsWebApi.Data
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {

        }
        public DbSet<Card> Cards { get; set; }
    }
}
