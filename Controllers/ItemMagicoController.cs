using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RpgApi.DTOs;
using RpgApi.Models;
using RpgApi.Repository;
using RpgApi.Services;

namespace RpgApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ItemMagicoController : ControllerBase
{
    private readonly ItemMagicoService _itemMagicoService;
    public ItemMagicoController(ItemMagicoService personagemService)
    {
        _itemMagicoService = personagemService; 
    }

    [HttpGet("{id:int}")]
    public async Task<IResult?> GetItemMagicoById([FromRoute]int id)
    {
        var itemMagico = await _itemMagicoService.GetItemMagicoById(id);
        var response = new ResponsePattern(new ItemMagicoDTO(itemMagico));
        return Results.Ok(response);
    }
    
    
    [HttpGet]
    public async Task<IResult?> GetPersonagens()
    {
        var itensMagicos = await _itemMagicoService.GetAllItemsMagico();
        var response = new ResponsePattern(itensMagicos.Select(p => new ItemMagicoDTO(p)));
        return Results.Ok(response);
    }
    
    [HttpPost]
    public async Task<IResult?> PostItemMagico(ItemMagicoCreateDTO itemMagicoCreateDTO)
    {
        var itemMagico = await _itemMagicoService.CreateItemMagico(itemMagicoCreateDTO);
        var response = new ResponsePattern(new ItemMagicoDTO(itemMagico));
        return Results.Ok(response);
    }
    
    [HttpDelete("{id:int}")]
    public async Task<IResult?> DeleteItemMagico([FromRoute]int id)
    {
        await _itemMagicoService.DeleteItemMagicoById(id);
        return Results.NoContent();
    }
    
}
