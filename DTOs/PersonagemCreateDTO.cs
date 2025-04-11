using RpgApi.Models;

namespace RpgApi.DTOs;

public class PersonagemCreateDTO
{
    public string Nome { get; set; }
    public string NomeAventureiro { get; set; }
    public string Classe { get; set; }
    public uint Level { get; set; }
    public uint Forca { get; set; }
    public uint Defesa { get; set; }
}