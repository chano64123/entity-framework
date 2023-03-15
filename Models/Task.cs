namespace projectEF.Models;

public class Task
{
    public Guid IdTask { get; set; }
    public Guid IdCategory { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public Priority Priority { get; set; }
    public DateTime DateCreate { get; set; }
    public virtual Category Category { get; set; } = new Category();
}

public enum Priority {
    Low,
    Medium,
    Hight
}
