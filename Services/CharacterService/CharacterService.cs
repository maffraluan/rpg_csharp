using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using csharp_rpg.DTO.Character;
using csharp_rpg.Models;

namespace csharp_rpg.Services.CharacterService
{
  public class CharacterService : ICharacterService
  {
    private static List<Character> _characters = new List<Character>
    {
        new Character(),
    };

    private readonly IMapper _mapper;
    public CharacterService(IMapper _mapper)
    {
      this._mapper = _mapper;
    }
    public async Task<ServiceResponse<List<GetCharacterDTO>>> AddCharacter(AddCharacterDTO _newCharacter)
    {
      ServiceResponse<List<GetCharacterDTO>> _serviceResponse = new ServiceResponse<List<GetCharacterDTO>>();
      Character _character = (this._mapper.Map<Character>(_newCharacter));
      _character.Id = _characters.Max(c => c.Id) + 1;
      _characters.Add(_character);
      _serviceResponse.Data = (_characters.Select(c => this._mapper.Map<GetCharacterDTO>(c))).ToList();
      return _serviceResponse;
    }

    public async Task<ServiceResponse<List<GetCharacterDTO>>> GetAllCharacters()
    {
      ServiceResponse<List<GetCharacterDTO>> _serviceResponse = new ServiceResponse<List<GetCharacterDTO>>();
      _serviceResponse.Data = (_characters.Select(c => this._mapper.Map<GetCharacterDTO>(c))).ToList();
      return _serviceResponse;
    }

    public async Task<ServiceResponse<GetCharacterDTO>> GetCharacterById(int id)
    {
      ServiceResponse<GetCharacterDTO> _serviceResponse = new ServiceResponse<GetCharacterDTO>();
      _serviceResponse.Data = this._mapper.Map<GetCharacterDTO>(_characters.FirstOrDefault(c => c.Id == id));
      return _serviceResponse;
    }

    public async Task<ServiceResponse<GetCharacterDTO>> UpdateCharacter(UpdateCharacterDTO _updatedCharacter)
    {
      ServiceResponse<GetCharacterDTO> _serviceResponse = new ServiceResponse<GetCharacterDTO>();

      Character _character = _characters.FirstOrDefault(c => c.Id == _updatedCharacter.Id);
      _character.Name = _updatedCharacter.Name;
      _character.Class = _updatedCharacter.Class;
      _character.Defense = _updatedCharacter.Defense;
      _character.HitPoints = _updatedCharacter.HitPoints;
      _character.Intelligence = _updatedCharacter.Intelligence;
      _character.Strength = _updatedCharacter.Strength;

      _serviceResponse.Data = this._mapper.Map<GetCharacterDTO>(_character);

      return _serviceResponse;
    }
  }
}