using RpgApi.Models;

namespace RpgApi.DTOs;

public class ItemMagicoDTO
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string TipoItem { get; set; }
    public uint Forca { get; set; }
    public uint Defesa { get; set; }

    public ItemMagicoDTO(ItemMagico itemMagico)
    {
        Id = itemMagico.Id;
        Nome = itemMagico.Nome;
        TipoItem = itemMagico.TipoItem.ToString();
        Forca = itemMagico.Forca;
        Defesa = itemMagico.Defesa;
    }
    
}