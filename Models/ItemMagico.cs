using System.ComponentModel.DataAnnotations;
using RpgApi.DTOs;

namespace RpgApi.Models;

public class ItemMagico
{
    [Key]
    public int Id { get; set; }
    public Personagem? Personagem { get; set; }
    public string Nome { get; set; }
    public TipoItem TipoItem { get; set; }
    public uint Forca { get; set; }
    public uint Defesa { get; set; }

    public ItemMagico()
    {
        
    }

    public ItemMagico(ItemMagicoCreateDTO itemMagicoDTO)
    {
        Nome = itemMagicoDTO.Nome;
        TipoItem.TryParse(itemMagicoDTO.TipoItem, out TipoItem tipoItem);
        TipoItem = tipoItem;
        Forca = itemMagicoDTO.Forca;
        Defesa = itemMagicoDTO.Defesa;
    }
    
    public ItemMagico(ItemMagicoCreateWithPersonagemDTO itemMagicoDTO, Personagem personagem)
    {
        Personagem = personagem;
        Nome = itemMagicoDTO.Nome;
        TipoItem.TryParse(itemMagicoDTO.TipoItem, out TipoItem tipoItem);
        TipoItem = tipoItem;
        Forca = itemMagicoDTO.Forca;
        Defesa = itemMagicoDTO.Defesa;
    }
}