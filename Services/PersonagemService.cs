using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RpgApi.DTOs;
using RpgApi.Models;
using RpgApi.Repository;

namespace RpgApi.Services;

public class PersonagemService
{
    private readonly PersonagemRepository _personagemRepository;

    public PersonagemService(PersonagemRepository personagemRepository)
    {
        _personagemRepository = personagemRepository;
    }
    
    public async Task<ICollection<Personagem>> GetAllPersonagens()
    {
        return (ICollection<Personagem>)(await _personagemRepository.GetAll());
    }
    
    public async Task<Personagem> GetPersonagemById(int id)
    {
        Personagem? personagem = await _personagemRepository.GetById(id);
        if (personagem is null) throw new ApplicationException("Personagem not found");
        return personagem;
    }
    
    public async Task DeletePersonageById(int id)
    {
        Personagem personagem = await GetPersonagemById(id);
        await _personagemRepository.Delete(personagem);
    }
    
    public async Task<Personagem?> UpdatePersonagem(PersonagemUpdateDTO personagemDTO, int id)
    {
        Personagem personagem = await GetPersonagemById(id);
        personagem.Update(personagemDTO);
        ValidationService.IsPersonagemValid(personagem);
        return await _personagemRepository.Update(personagem);
    }

    public async Task<Personagem?> CreatePersonagem(PersonagemCreateDTO personagemDTO)
    {
        Personagem? personagem = new Personagem(personagemDTO);
        ValidationService.IsPersonagemValid(personagem);
        return await _personagemRepository.Add(personagem);
    }
}
