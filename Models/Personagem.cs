using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RpgApi.Models;

public class Personagem
{
    [Key]
    public int Id { get; set; }
    public string Nome { get; set; }
    public string NomeAventureiro { get; set; }
    public Classe Classe { get; set; }
    public int Level { get; set; }
    public int Forca { get; set; }
    public int Defesa { get; set; }
    public ICollection<ItemMagico> ItensMagicos { get; set; }
}
