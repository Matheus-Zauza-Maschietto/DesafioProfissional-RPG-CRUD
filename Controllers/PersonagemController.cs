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
public class PersonagemController : ControllerBase
{
    private readonly PersonagemService _personagemService;
    private readonly ItemMagicoService _itemMagicoService;
    public PersonagemController(PersonagemService personagemService, ItemMagicoService ItemMagicoService)
    {
        _personagemService = personagemService;
        _itemMagicoService = ItemMagicoService;
    }

    [HttpGet("{id:int}")]
    public async Task<IResult?> GetPersonagemById([FromRoute]int id)
    {
        var personagem = await _personagemService.GetPersonagemById(id);
        var response = new ResponsePattern(new PersonagemDTO(personagem));
        return Results.Ok(response);
    }
    
    
    [HttpGet]
    public async Task<IResult?> GetPersonagens()
    {
        var personagens = await _personagemService.GetAllPersonagens();
        var response = new ResponsePattern(personagens.Select(p=> new PersonagemDTO(p)));
        return Results.Ok(response);
    }
    
    [HttpPost]
    public async Task<IResult?> PostPersonagem(PersonagemCreateDTO personagemCreateDTO)
    {
        var personagem = await _personagemService.CreatePersonagem(personagemCreateDTO);
        var response = new ResponsePattern(new PersonagemDTO(personagem));
        return Results.Ok(response);
    }
    
    [HttpPatch("{id:int}")]
    public async Task<IResult?> PatchPersonagem(PersonagemUpdateDTO personagemUpdateDTO, int id)
    {
        var personagem = await _personagemService.UpdatePersonagem(personagemUpdateDTO, id);
        var response = new ResponsePattern(new PersonagemDTO(personagem));
        return Results.Ok(response);
    }
    
    [HttpDelete("{id:int}")]
    public async Task<IResult?> DeletePersonagem([FromRoute]int id)
    {
        await _personagemService.DeletePersonageById(id);
        return Results.NoContent();
    }
    
    [HttpPost("{personagemId:int}/ItemMagico")]
    public async Task<IResult?> PostItemMagico(ItemMagicoCreateWithPersonagemDTO itemMagicoDTO, int personagemId)
    {
        var itemMagico = await _itemMagicoService.CreateItemMagicoAddingToPersonagem(itemMagicoDTO, personagemId);
        var response = new ResponsePattern(new ItemMagicoDTO(itemMagico));
        return Results.Ok(response);
    }
    
    [HttpGet("{personagemId:int}/ItemMagico")]
    public async Task<IResult?> GetItensMagicos(int personagemId)
    {
        var itensMagicos = await _itemMagicoService.GetItensMagicosByPersonagemId(personagemId);
        var response = new ResponsePattern(itensMagicos.Select(p => new ItemMagicoDTO(p)));
        return Results.Ok(response);
    }
    
    [HttpDelete("{personagemId:int}/ItemMagico/{itemMagicoId:int}")]
    public async Task<IResult?> DeleteItensMagicos(int personagemId, int itemMagicoId)
    {
        await _itemMagicoService.RemoveItemMagicoFromPersonagem(personagemId, itemMagicoId);
        return Results.NoContent();
    }
    
        
    [HttpGet("{personagemId:int}/ItemMagico/Amuleto")]
    public async Task<IResult?> GetAmuletoFromPersonagem(int personagemId)
    {
        var itemMagico = await _itemMagicoService.GetAmuletoFromPersonagem(personagemId);
        var response = new ResponsePattern(new ItemMagicoDTO(itemMagico));
        return Results.Ok(response);
    }
    
}
