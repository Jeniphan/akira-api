using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using akiira_api.Dtos.Character;
using akiira_api.Services.CharacterService;
using Microsoft.AspNetCore.Mvc;

namespace akiira_api.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class akiiraController : ControllerBase
  {
    private readonly ICharacterService CharacterService;
    public akiiraController(ICharacterService CharacterService)
    {
      this.CharacterService = CharacterService;

    }
    [HttpGet("GetAll")]
    public async Task<ActionResult<ServiceReponse<List<GetCharacterDto>>>> Get()
    {
      return Ok(await CharacterService.GetAllCharacter());
    }
    [HttpGet("GetSingle/{id}")]
    public async Task<ActionResult<ServiceReponse<GetCharacterDto>>> GetSingle(int id)
    {
      return Ok(await CharacterService.GetCharacterbyId(id));
    }

    [HttpPost]
    public async Task<ActionResult<ServiceReponse<List<GetCharacterDto>>>> AddCharacter(AddCharacterDto newCharacter)
    {
      return Ok(await CharacterService.AddCharacter(newCharacter));
    }
  }
}