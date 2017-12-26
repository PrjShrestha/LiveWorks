using AutoMapper;
using LiveWorks.Core.Models;
using LiveWorks.EntityDto;

namespace LiveWorks.Utils.Automapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Item, ItemDto>().ForMember(item => item.Id,
                opts => opts.MapFrom(itemDto => itemDto.Type.ToUpper()));

            CreateMap<Item, ItemDto>().ReverseMap();

            CreateMap<Category, CategoryDto>();
            CreateMap<Category, CategoryDto>().ReverseMap();
        }
    }
}
