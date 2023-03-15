namespace projectEF.Models;

public class Category {
    public Guid IdCategory { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}