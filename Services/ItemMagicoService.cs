using RpgApi.Models;
using RpgApi.Repository;

namespace RpgApi.Services;

public class ItemMagicoService
{
    private readonly ItemMagicoRepository _itemMagicoRepository;
    public ItemMagicoService(ItemMagicoRepository itemMagicoRepository)
    {
        _itemMagicoRepository = itemMagicoRepository;
    }

    public async Task<ICollection<ItemMagico>> GetAllItemsMagico()
    {
        return (ICollection<ItemMagico>)(await _itemMagicoRepository.GetAll());
    }
    
    public async Task<ItemMagico?> GetItemMagicoById(int id)
    {
        return await _itemMagicoRepository.GetById(id);
    }
    
    public async Task DeleteItemMagicoById(int id)
    {
        ItemMagico itemMagico = await _itemMagicoRepository.GetById(id);
        await _itemMagicoRepository.Delete(itemMagico);
    }
}