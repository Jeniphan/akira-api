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

    [HttpPut]
    public async Task<ActionResult<ServiceReponse<GetCharacterDto>>> updateCharacter(UpdateCharacterDto updateCharacter)
    {
      var response = await CharacterService.UpdateCharacter(updateCharacter);
      if (response.Data == null)
      {
        return NotFound(response);
      }
      return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ServiceReponse<List<GetCharacterDto>>>> Delete(int id)
    {
      var response = await CharacterService.DeleteCharacter(id);
      if (response.Data == null)
      {
        return NotFound(response);
      }
      return Ok(response);
    }
  }
}