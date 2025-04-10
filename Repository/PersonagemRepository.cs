using Microsoft.EntityFrameworkCore;
using RpgApi.Models;

namespace RpgApi.Repository;

public class PersonagemRepository
{
    private readonly ApplicationDbContext _dbContext;

    public PersonagemRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Personagem?> GetById(int id)
    {
        return await _dbContext.Personagens.FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<List<Personagem>> GetAll()
    {
        return await _dbContext.Personagens.ToListAsync();
    }

    public async Task<Personagem> Add(Personagem personagem)
    {
        Personagem created = (await _dbContext.Personagens.AddAsync(personagem)).Entity;
        await _dbContext.SaveChangesAsync();
        return created; 
    }

    public async Task<Personagem> Update(Personagem personagem)
    {
        Personagem updated = _dbContext.Personagens.Update(personagem).Entity;
        await _dbContext.SaveChangesAsync();
        return updated;
    }

    public async Task Delete(Personagem personagem)
    {
        _dbContext.Personagens.Remove(personagem);
        await _dbContext.SaveChangesAsync();
    }
}