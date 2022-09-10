namespace Todo.WebApi.Controllers.DTOs.Item;

public class CreateItemDto
{
    public string Title { get; set; }
    
    public string Description { get; set; }
    
    public bool Done { get; set; }
}