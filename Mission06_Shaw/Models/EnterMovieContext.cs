using Microsoft.EntityFrameworkCore;

namespace Mission06_Shaw.Models
{
    public class EnterMovie
    {
        public class EnterMovieContext : DbContext
        {
            public EnterMovieContext(DbContextOptions<EnterMovieContext> options) : base(options)
            {
            }

            public DbSet<Movie> Movies { get; set; }

            public DbSet<Category> Categories { get; set; }

        }
    }
}
