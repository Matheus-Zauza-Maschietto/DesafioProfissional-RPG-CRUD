using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using RpgApi.DTOs;

namespace RpgApi.Models;

public class Personagem
{
    [Key]
    public int Id { get; set; }
    public string Nome { get; set; }
    public string NomeAventureiro { get; set; }
    public Classe Classe { get; set; }
    public uint Level { get; set; }
    public uint Forca { get; set; }
    public uint Defesa { get; set; }
    public ICollection<ItemMagico>? ItensMagicos { get; set; }

    public Personagem()
    {
        
    }

    public Personagem(PersonagemCreateDTO personagemDTO)
    {
        Nome = personagemDTO.Nome;
        NomeAventureiro = personagemDTO.NomeAventureiro;
        Classe.TryParse(personagemDTO.Classe, out Classe classe);
        Classe = classe;
        Level = personagemDTO.Level;
        Forca = personagemDTO.Forca;
        Defesa = personagemDTO.Defesa;
        ItensMagicos = new List<ItemMagico>();
    }

    public Personagem Update(PersonagemUpdateDTO personagemDTO)
    {
        NomeAventureiro = personagemDTO.NomeAventureiro;
        return this;
    }
    
}
