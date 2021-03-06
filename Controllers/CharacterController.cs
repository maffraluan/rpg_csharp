using System.Collections.Generic;
using System.Linq;
using csharp_rpg.Models;
using Microsoft.AspNetCore.Mvc;

namespace csharp_rpg.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class CharacterController : ControllerBase
  {
    private static List<Character> _characters = new List<Character>
    {
        new Character(),
        new Character { Id = 1, Name = "Sam"}
    };
    [HttpGet("GetAll")]
    public IActionResult Get()
    {
      return Ok(_characters);
    }
    [HttpGet("{id}")]
    public IActionResult GetSingle(int id)
    {
      return Ok(_characters.FirstOrDefault(c => c.Id == id));
    }
    }
}