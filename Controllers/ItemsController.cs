/*

using Catalog.Dtos;
using Catalog.Entities;
using Catalog.Interfaces.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace Catalog.Controllers;

[ApiController]
[Route("items")]
public class ItemsController : ControllerBase
{
    private readonly IItemsServices _itemsServices;

    public ItemsController(IItemsServices itemsServices)
    {
        _itemsServices = itemsServices;
    }


    [HttpGet]
    public async Task<List<Item>> GetItems()
    {
        var items = await _itemsServices.GetAllItems();
        return items;
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<Item>> GetItem(Guid id)
    {
        var item = await _itemsServices.GetItem(id);
        return item is null ? NotFound() : item;
    }


    [HttpPost]
    public async Task<ActionResult<Item?>> CreateItem(ItemDto item)
    {
        var result = await _itemsServices.CreateItem(item);
        return result;
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult> UpdateItem(Guid id, ItemDto itemDto)
    {
        try
        {
            await _itemsServices.UpdateItem(id, itemDto);
        }
        catch (ArgumentException)
        {
            return NotFound("Id not Found");
        }

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> DeleteItem(Guid id)
    {
        try
        {
            await _itemsServices.DeleteItem(id);
        }
        catch (ArgumentException)
        {
            return NotFound("Item not found with that specific id");
        }

        return NoContent();

    }


}

*/