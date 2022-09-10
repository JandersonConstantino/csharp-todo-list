using Microsoft.AspNetCore.Mvc;
using Todo.WebApi.Controllers.DTOs.Item;
using Todo.WebApi.Models;
using Todo.WebApi.Services;

namespace Todo.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ItemController : ControllerBase
{
    private readonly ILogger<ItemController> _logger;
    private readonly ItemService _service;

    public ItemController(ILogger<ItemController> logger)
    {
        _logger = logger;
        _service = new ItemService();
    }

    [HttpGet]
    public List<Item> Get()
    {
        return _service.FindAll();
    }

    [HttpPost]
    public Item Post(CreateItemDto item)
    {
        return _service.Create(item);
    }
}