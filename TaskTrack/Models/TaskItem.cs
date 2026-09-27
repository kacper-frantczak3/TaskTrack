using System.ComponentModel.DataAnnotations;

namespace TaskTrack.Models;

public class TaskItem
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Task name is required")]
    [StringLength(100, ErrorMessage = "Task name cannot be longer than 100 characters")]
    public string Name { get; set; } = string.Empty;
    
    public string Description { get; set; } = string.Empty;
    
    public bool IsCompleted { get; set; }
    
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}