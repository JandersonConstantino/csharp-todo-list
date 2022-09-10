using MongoDB.Driver;
using Todo.WebApi.Models;

namespace Todo.WebApi.Repository;

public sealed class ItemRepository
{
    private readonly IMongoCollection<Item> _collection;

    public ItemRepository()
    {
        _collection = new DatabaseContext().Item;
    }

    public List<Item> FindAll()
    {
        return _collection.Find(x => true).ToList();
    }

    public Item FindById(Guid id)
    {
        return _collection.Find(x => x.Id == id).FirstOrDefault();
    }

    public Item Create(Item item)
    {
        _collection.InsertOne(item);
        return _collection.Find(x => x.Id == item.Id).FirstOrDefault();
    }

    public Item Update(Item item)
    {
        _collection.FindOneAndReplace(x => x.Id == item.Id, item);
        return _collection.Find(x => x.Id == item.Id).FirstOrDefault();
    }

    public void Delete(Guid id)
    {
        _collection.FindOneAndDelete(x => x.Id == id);
    }

    public IMongoCollection<Item> GetCollection()
    {
        return _collection;
    }
}