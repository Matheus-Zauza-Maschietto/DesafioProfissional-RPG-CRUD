using RpgApi.Models;

namespace RpgApi.DTOs;

public class ItemMagicoCreateDTO
{
    public string Nome { get; set; }
    public string TipoItem { get; set; }
    public uint Forca { get; set; }
    public uint Defesa { get; set; }
}