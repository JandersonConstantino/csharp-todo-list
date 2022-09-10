using MongoDB.Driver;
using Todo.WebApi.Controllers.DTOs.Item;
using Todo.WebApi.Models;
using Todo.WebApi.Repository;

namespace Todo.WebApi.Services;

public sealed class ItemService
{
    private readonly ItemRepository _repository;
    
    public ItemService()
    {
        _repository = new ItemRepository();
    }

    public List<Item> FindAll()
    {
        return _repository.FindAll();
    }

    public Item FindById(Guid id)
    {
        var item = _repository.FindById(id);
        
        if (item == null)
            throw new Exception("Item not found!");

        return item;
    }

    public Item Create(CreateItemDto dto)
    {
        var item = new Item
        {
            Id = Guid.NewGuid(),
            Title = dto.Title,
            Description = dto.Description,
            Done = dto.Done
        };

        if (item.Title.Trim().Equals(""))
            throw new Exception("Title is required!");
        
        if (ExistItemWithTitle(item.Title))
            throw new Exception("You cannot register same todo item twice times!");

        return _repository.Create(item);
    }

    private bool ExistItemWithTitle(string title)
    {
        var result = _repository.GetCollection().Find(x => x.Title.Equals(title)).FirstOrDefault();
        return result != null;
    }
}