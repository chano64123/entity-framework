using Microsoft.EntityFrameworkCore;
using projectEF.Models;
using Task = projectEF.Models.Task;

namespace projectEF;

public class TasksContext : DbContext {
    DbSet<Category> Categories { get; set; }
    DbSet<Task> Tasks { get; set; }

    public TasksContext(DbContextOptions<TasksContext> options) : base(options) {}
}