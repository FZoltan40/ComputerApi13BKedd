using Microsoft.EntityFrameworkCore;

namespace ComputerApi.Models;

public partial class ComputerContext : DbContext
{
    public ComputerContext()
    {
    }

    public ComputerContext(DbContextOptions<ComputerContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Comp> Computers { get; set; }

    public virtual DbSet<OSystem> OSystem { get; set; }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
