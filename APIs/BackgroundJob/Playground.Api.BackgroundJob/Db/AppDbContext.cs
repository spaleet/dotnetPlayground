using Microsoft.EntityFrameworkCore;

namespace Playground.Api.BackgroundJob.Db;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
}
