using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using akiira_api.Dtos.Character;
using AutoMapper;

namespace akiira_api.Services.CharacterService
{
  public class CharacterService : ICharacterService
  {
    private static List<character> characters = new List<character>
    {
        new character(),
        new character { Name = "akiira",
        Id = 1}

    };
    private readonly IMapper _mapper;
    public CharacterService(IMapper mapper)
    {
      _mapper = mapper;
    }
    public async Task<ServiceReponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter)
    {
      var serviceReponse = new ServiceReponse<List<GetCharacterDto>>();
      character Character = _mapper.Map<character>(newCharacter);
      Character.Id = characters.Max(c => c.Id) + 1;
      characters.Add(Character);
      serviceReponse.Data = characters.Select(x => _mapper.Map<GetCharacterDto>(x)).ToList();
      return serviceReponse;
    }

    public async Task<ServiceReponse<List<GetCharacterDto>>> GetAllCharacter()
    {
      return new ServiceReponse<List<GetCharacterDto>>
      {
        Data = characters.Select(x => _mapper.Map<GetCharacterDto>(x)).ToList()
      };
    }

    public async Task<ServiceReponse<GetCharacterDto>> GetCharacterbyId(int id)
    {
      var serviceResponse = new ServiceReponse<GetCharacterDto>();
      var _character = characters.FirstOrDefault(x => x.Id == id);
      serviceResponse.Data = _mapper.Map<GetCharacterDto>(_character);
      return serviceResponse;
    }
  }
}