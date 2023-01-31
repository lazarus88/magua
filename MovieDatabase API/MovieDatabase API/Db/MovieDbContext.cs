using Microsoft.EntityFrameworkCore;
using MovieDatabase_API.Db.Entities;

public class MovieDbContext : DbContext

{
    public DbSet<MovieEntity> Movies { get; set; }

    public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}