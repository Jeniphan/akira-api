using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using akiira_api.Dtos.Character;

namespace akiira_api.Services.CharacterService
{
  public interface ICharacterService
  {
    Task<ServiceReponse<List<GetCharacterDto>>> GetAllCharacter();
    Task<ServiceReponse<GetCharacterDto>> GetCharacterbyId(int id);
    Task<ServiceReponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter);

  }
}