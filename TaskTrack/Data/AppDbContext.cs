using TaskTrack.Models;
using Microsoft.EntityFrameworkCore;

namespace TaskTrack.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    
    public DbSet<TaskItem> Tasks => Set<TaskItem>();
}