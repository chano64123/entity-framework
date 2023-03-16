using Microsoft.EntityFrameworkCore;
using projectEF.Models;
using Task = projectEF.Models.Task;

namespace projectEF;

public class TasksContext : DbContext {
    DbSet<Category> Categories { get; set; }
    DbSet<Task> Tasks { get; set; }

    public TasksContext(DbContextOptions<TasksContext> options) : base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder){
        modelBuilder.Entity<Category>(category => {
            category.ToTable("Category");
            category.HasKey(p => p.IdCategory);

            category.Property(p => p.Name).IsRequired().HasMaxLength(150);
            category.Property(p => p.Description);
            category.Property(p => p.Impact);
        });

        modelBuilder.Entity<Task>(task => {
            task.ToTable("Task");
            task.HasKey(p => p.IdTask);
            task.HasOne(p => p.Category).WithMany(p => p.Tasks).HasForeignKey(p => p.IdCategory);

            task.Property(p => p.Title).IsRequired().HasMaxLength(200);
            task.Property(p => p.Description);
            task.Property(p => p.Priority);
            task.Property(p => p.DateCreate);
            task.Ignore(p => p.Resume);
        });
    }
}