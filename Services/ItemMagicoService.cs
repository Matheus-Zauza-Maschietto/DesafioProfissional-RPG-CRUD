using System.Collections;
using RpgApi.DTOs;
using RpgApi.Models;
using RpgApi.Repository;

namespace RpgApi.Services;

public class ItemMagicoService
{
    private readonly PersonagemService _personagemService;
    private readonly ItemMagicoRepository _itemMagicoRepository;
    public ItemMagicoService(ItemMagicoRepository itemMagicoRepository, PersonagemService personagemService)
    {
        _itemMagicoRepository = itemMagicoRepository;
        _personagemService = personagemService;
    }

    public async Task<ICollection<ItemMagico>> GetAllItemsMagico()
    {
        return (ICollection<ItemMagico>)(await _itemMagicoRepository.GetAll());
    }
    
    public async Task<ItemMagico> GetItemMagicoById(int id)
    {
        ItemMagico? itemMagico = await _itemMagicoRepository.GetById(id);
        if(itemMagico is null) throw new ApplicationException("Item magico não encontrado");
        return itemMagico;
    }
    
    public async Task<ICollection<ItemMagico>> GetItensMagicosByPersonagemId(int personagemId)
    {
        Personagem personagem = await _personagemService.GetPersonagemById(personagemId);
        return await _itemMagicoRepository.GetByPersonagem(personagem);
    }
    
    public async Task<ItemMagico> GetAmuletoFromPersonagem(int personagemId)
    {
        await _personagemService.GetPersonagemById(personagemId);
        ItemMagico? itemMagico = await _itemMagicoRepository.GetAmuletoFromPersonagem(personagemId);
        return itemMagico;
    }
    
    public async Task RemoveItemMagicoFromPersonagem(int personagemId, int itemMagicoId)
    {
        await _personagemService.GetPersonagemById(personagemId);
        ItemMagico? itemMagico = await _itemMagicoRepository.GetById(itemMagicoId);
        itemMagico.Personagem = null;
        await _itemMagicoRepository.Update(itemMagico);
    }
    
    public async Task DeleteItemMagicoById(int id)
    {
        ItemMagico itemMagico = await GetItemMagicoById(id);
        await _itemMagicoRepository.Delete(itemMagico);
    }
    
    
    public async Task<ItemMagico?> CreateItemMagico(ItemMagicoCreateDTO itemMagicoDTO)
    {
        ItemMagico? itemMagico = new ItemMagico(itemMagicoDTO);
        ValidationService.IsItemMagicoValid(itemMagico);
        ItemMagico createdItem = await _itemMagicoRepository.Add(itemMagico);
        return createdItem;
    }
    
    public async Task<ItemMagico?> CreateItemMagicoAddingToPersonagem(ItemMagicoCreateWithPersonagemDTO itemMagicoDTO, int personagemId)
    {
        Personagem personagem = await _personagemService.GetPersonagemById(personagemId);
        ItemMagico? itemMagico = new ItemMagico(itemMagicoDTO, personagem);
        ValidationService.IsItemMagicoValid(itemMagico);
        ValidationService.IsItemMagicoInsertionValid(itemMagico, personagem);
        ItemMagico createdItem = await _itemMagicoRepository.Add(itemMagico);
        createdItem.Personagem.ItensMagicos = null;
        return createdItem;
    }
}