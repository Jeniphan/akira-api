using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using akiira_api.Dtos.Character;
using akira_api.Data;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace akiira_api.Services.CharacterService
{
  public class CharacterService : ICharacterService
  {
    private readonly IMapper _mapper;
    private readonly DataContext _context;
    public CharacterService(IMapper mapper, DataContext context)
    {
      _mapper = mapper;
      _context = context;
    }
    public async Task<ServiceReponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter)
    {
      var serviceReponse = new ServiceReponse<List<GetCharacterDto>>();
      Character Character = _mapper.Map<Character>(newCharacter);
      _context.Characters.Add(Character);
      await _context.SaveChangesAsync();
      serviceReponse.Data = await _context.Characters.Select(x => _mapper.Map<GetCharacterDto>(x)).ToListAsync();
      return serviceReponse;
    }

    public async Task<ServiceReponse<List<GetCharacterDto>>> GetAllCharacter()
    {
      var response = new ServiceReponse<List<GetCharacterDto>>();
      var dbCharacters = await _context.Characters.ToListAsync();
      response.Data = dbCharacters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();

      return response;
    }

    public async Task<ServiceReponse<GetCharacterDto>> GetCharacterbyId(int id)
    {
      var serviceResponse = new ServiceReponse<GetCharacterDto>();
      var dbCharacter = await _context.Characters.FirstOrDefaultAsync(x => x.Id == id);
      serviceResponse.Data = _mapper.Map<GetCharacterDto>(dbCharacter);
      return serviceResponse;
    }

    public async Task<ServiceReponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updateCharacter)
    {
      ServiceReponse<GetCharacterDto> response = new ServiceReponse<GetCharacterDto>();
      try
      {
        Character character = await _context.Characters
        .FirstOrDefaultAsync(c => c.Id == updateCharacter.Id);
        // _mapper.Map(updateCharacter, character);
        character.Name = updateCharacter.Name;
        character.HitPoint = updateCharacter.HitPoint;
        character.Strength = updateCharacter.Strength;
        character.Defense = updateCharacter.Defense;
        character.Intalligence = updateCharacter.Intalligence;
        character.Class = updateCharacter.Class;
        await _context.SaveChangesAsync();
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
        Character character = await _context.Characters.FirstAsync(c => c.Id == Id);
        _context.Characters.Remove(character);

        await _context.SaveChangesAsync();
        response.Data = _context.Characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
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