using System.Collections.Generic;
using System.Threading.Tasks;
using csharp_rpg.DTO.Character;
using csharp_rpg.Models;

namespace csharp_rpg.Services.CharacterService
{
    public interface ICharacterService
    {
    Task<ServiceResponse<List<GetCharacterDTO>>> GetAllCharacters();

    Task<ServiceResponse<GetCharacterDTO>> GetCharacterById(int id);

    Task<ServiceResponse<List<GetCharacterDTO>>> AddCharacter(AddCharacterDTO _newCharacter);

    Task<ServiceResponse<GetCharacterDTO>> UpdateCharacter(UpdateCharacterDTO updateCharater);
  }
}