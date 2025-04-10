using RpgApi.Models;

namespace RpgApi.DTOs;

public class ItemMagicoCreateDTO
{
    public int PersonagemId { get; set; }
    public string Nome { get; set; }
    public TipoItem TipoItem { get; set; }
    public int Forca { get; set; }
    public int Defesa { get; set; }
}