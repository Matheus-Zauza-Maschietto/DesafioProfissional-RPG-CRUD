using RpgApi.Models;

namespace RpgApi.Services;

public class ValidationService
{
    public static void IsPersonagemValid(Personagem personagem)
    {
        if (personagem.Forca + personagem.Defesa > 10) 
            throw new ApplicationException("Você possui apenas 10 pontos para distribuir.");
        if (personagem.Classe == 0) 
            throw new ApplicationException($"Um personagem deve ter uma das seguintes classes: {string.Join(", " , Enum.GetNames(typeof(Classe)))}");
    }

    public static void IsItemMagicoValid(ItemMagico itemMagico)
    {
        if (itemMagico.TipoItem == TipoItem.Arma && itemMagico.Defesa != 0)
            throw new ApplicationException("Um item mágico do tipo arma não pode ter defesa");
        if (itemMagico.TipoItem == TipoItem.Armadura && itemMagico.Forca != 0)
            throw new ApplicationException("Um item mágico do tipo armadura não pode ter forca");
        if (itemMagico.Defesa == 0 && itemMagico.Forca == 0)
            throw new ApplicationException("Um item mágico não pode ter 0 de força e defesa.");
        if (itemMagico.Defesa + itemMagico.Forca > 10)
            throw new ApplicationException("Um item mágico não pode ter mais do que 10 pontos ao total.");
        if (itemMagico.TipoItem == 0)
            throw new ApplicationException($"Um item mágico deve ter um dos seguintes tipos: {string.Join(", " , Enum.GetNames(typeof(TipoItem)))}");
    }

    public static void IsItemMagicoInsertionValid(ItemMagico itemMagico, Personagem personagem)
    {
        if (itemMagico.TipoItem == TipoItem.Amuleto && personagem.ItensMagicos.Any(p => p.TipoItem == TipoItem.Amuleto))
            throw new ApplicationException("Um personagem pode ter apenas um item mágico do tipo amuleto");
    }
}