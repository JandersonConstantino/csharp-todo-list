using System.ComponentModel.DataAnnotations;

namespace Todo.WebApi.Models;

public class Item
{
    public Guid Id { get; set; }
    
    [Required]
    public string Title { get; set; }

    public string Description { get; set; }
    
    public bool Done { get; set; }
}