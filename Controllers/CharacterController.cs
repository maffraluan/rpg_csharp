using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using csharp_rpg.DTO.Character;
using csharp_rpg.Models;
using csharp_rpg.Services.CharacterService;
using Microsoft.AspNetCore.Mvc;

namespace csharp_rpg.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class CharacterController : ControllerBase
  {
    private readonly ICharacterService _characterService;

    public CharacterController(ICharacterService _characterService)
    {
      this._characterService = _characterService;

    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> Get()
    {
      return Ok(await this._characterService.GetAllCharacters());
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetSingle(int id)
    {
      return Ok(await this._characterService.GetCharacterById(id));
    }
    [HttpPost]
    public async Task<IActionResult> AddCharacter(AddCharacterDTO _newCharacter)
    {
      return Ok(await this._characterService.AddCharacter(_newCharacter));
    }
    [HttpPut]
    public async Task<IActionResult> UpdateCharacter(UpdateCharacterDTO _updatedCharacter)
    {
      return Ok(await this._characterService.UpdateCharacter(_updatedCharacter));
    }
  }
}