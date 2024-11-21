using Microsoft.EntityFrameworkCore;
using StaffFlow.Models;


namespace Farmtech.Core.Data.Contexts;
public class CoreDbContext(DbContextOptions<CoreDbContext> options) : DbContext(options)
{
    public DbSet<Employee> Employee { get; set; } = null!;
    public DbSet<Manager> Manager { get; set; } = null!;
};