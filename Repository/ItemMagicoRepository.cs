using Microsoft.EntityFrameworkCore;
using RpgApi.Models;

namespace RpgApi.Repository;

public class ItemMagicoRepository
{
    private readonly ApplicationDbContext _dbContext;

    public ItemMagicoRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ItemMagico?> GetById(int id)
    {
        return await _dbContext.ItensMagicos.FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<List<ItemMagico>> GetAll()
    {
        return await _dbContext.ItensMagicos.ToListAsync();
    }

    public async Task<ItemMagico> Add(ItemMagico personagem)
    {
        ItemMagico created = (await _dbContext.ItensMagicos.AddAsync(personagem)).Entity;
        await _dbContext.SaveChangesAsync();
        return created; 
    }

    public async Task<ItemMagico> Update(ItemMagico personagem)
    {
        ItemMagico updated = _dbContext.ItensMagicos.Update(personagem).Entity;
        await _dbContext.SaveChangesAsync();
        return updated;
    }

    public async Task Delete(ItemMagico personagem)
    {
        _dbContext.ItensMagicos.Remove(personagem);
        await _dbContext.SaveChangesAsync();
    }
}