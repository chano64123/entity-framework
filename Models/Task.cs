using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projectEF.Models;

[Table("Task")]
public class Task {
    [Key]
    public Guid IdTask { get; set; }

    [ForeignKey("IdCategory")]
    public Guid IdCategory { get; set; }

    [Required]
    [MaxLength(200)]
    [MinLength(10)]
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public Priority Priority { get; set; }
    public DateTime DateCreate { get; set; }

    [NotMapped]
    public string Resume { get; set; } = string.Empty;

    public virtual Category Category { get; set; } = new Category();
}

public enum Priority {
    Low,
    Medium,
    Hight
}
