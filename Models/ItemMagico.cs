using System.ComponentModel.DataAnnotations;

namespace RpgApi.Models;

public class ItemMagico
{
    [Key]
    public int Id { get; set; }

    public Personagem Personagem { get; set; }
    public string Nome { get; set; }
    public TipoItem TipoItem { get; set; }
    public int Forca { get; set; }
    public int Defesa { get; set; }
}