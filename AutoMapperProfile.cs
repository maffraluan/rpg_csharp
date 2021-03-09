using AutoMapper;
using csharp_rpg.DTO.Character;
using csharp_rpg.Models;

namespace csharp_rpg
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Character, GetCharacterDTO>();
            CreateMap<AddCharacterDTO, Character>();
        }
    }
}