using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using akiira_api.Dtos.Character;
using AutoMapper;

namespace akiira_api
{
  public class AutoMapperProfile : Profile
  {
    public AutoMapperProfile()
    {
      CreateMap<character, GetCharacterDto>();
      CreateMap<AddCharacterDto, character>();

    }
  }
}