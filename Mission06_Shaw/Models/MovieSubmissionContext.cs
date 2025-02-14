using Microsoft.EntityFrameworkCore;

namespace Mission06_Shaw.Models
{
    public class MovieSubmissionContext : DbContext
    {
        public MovieSubmissionContext(DbContextOptions<MovieSubmissionContext> options) : base (options) //Constructor
        { 
        }

        //Creates Database and Table in DataBase
        public DbSet<Movie> Movies { get; set; }
    }
}
