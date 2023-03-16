using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projectEF.Models;

[Table("Category")]
public class Category {
    //[Key]
    public Guid IdCategory { get; set; }
    
    //[Required]
    //[MaxLength(150)]
    [MinLength(5)]
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}