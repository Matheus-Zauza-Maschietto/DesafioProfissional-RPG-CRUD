using RpgApi.Models;

namespace RpgApi.DTOs;

public class PersonagemDTO
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string NomeAventureiro { get; set; }
    public string Classe { get; set; }
    public uint Level { get; set; }
    public uint Forca { get; set; }
    public uint Defesa { get; set; }

    public PersonagemDTO()
    {
        
    }


    public PersonagemDTO(Personagem personagem)
    {
        Id = personagem.Id;
        Nome = personagem.Nome;
        NomeAventureiro = personagem.NomeAventureiro;
        Classe = personagem.Classe.ToString();
        Level = personagem.Level;
        Forca = personagem.Forca + (uint)personagem.ItensMagicos.Sum(p => p.Forca);
        Defesa = personagem.Defesa + (uint)personagem.ItensMagicos.Sum(p => p.Defesa);;
    }
    
}