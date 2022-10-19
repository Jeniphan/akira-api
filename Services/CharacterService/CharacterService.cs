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
    private static List<Character> characters = new List<Character>
    {
        new Character(),
        new Character { Name = "akiira",
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
      Character Character = _mapper.Map<Character>(newCharacter);
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

    public async Task<ServiceReponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updateCharacter)
    {
      ServiceReponse<GetCharacterDto> response = new ServiceReponse<GetCharacterDto>();
      try
      {
        Character character = characters.FirstOrDefault(c => c.Id == updateCharacter.Id);
        character.Name = updateCharacter.Name;
        character.HitPoint = updateCharacter.HitPoint;
        character.Strength = updateCharacter.Strength;
        character.Defense = updateCharacter.Defense;
        character.Intalligence = updateCharacter.Intalligence;
        character.Class = updateCharacter.Class;
        response.Data = _mapper.Map<GetCharacterDto>(character);
      }
      catch (Exception ex)
      {
        response.Success = false;
        response.Message = ex.Message;
      }
      return response;
    }
    public async Task<ServiceReponse<List<GetCharacterDto>>> DeleteCharacter(int Id)
    {
      ServiceReponse<List<GetCharacterDto>> response = new ServiceReponse<List<GetCharacterDto>>();
      try
      {
        Character character = characters.First(c => c.Id == Id);
        characters.Remove(character);
        response.Data = characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
      }
      catch (Exception ex)
      {
        response.Success = false;
        response.Message = ex.Message;
      }
      return response;
    }
  }
}