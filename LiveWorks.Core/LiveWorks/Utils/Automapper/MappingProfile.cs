using AutoMapper;
using LiveWorks.Core.Models;
using LiveWorks.EntityDto;
using System.Collections.Generic;

namespace LiveWorks.Utils.Automapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Item, ItemDto>().ForMember(dest => dest.TypeDto,
                opts => opts.MapFrom(src => src.Type));
            CreateMap<Item, ItemDto>().ForMember(dest => dest.TypeDto,
                opts => opts.MapFrom(src => src.Type)).ReverseMap();
            
            CreateMap<Stock, StockDto>();
            CreateMap<Stock, StockDto>().ReverseMap();

            CreateMap<StockIn, StockInDto>();
            CreateMap<StockIn, StockInDto>().ReverseMap();

            CreateMap<StockOut, StockOutDto>();
            CreateMap<StockOut, StockOutDto>().ReverseMap();

            CreateMap<Category, CategoryDto>();
            CreateMap<Category, CategoryDto>().ReverseMap();

            //CreateMap<IEnumerable<Item>, IEnumerable<ItemDto>>();
            //CreateMap<IEnumerable<Item>, IEnumerable<ItemDto>>().ReverseMap();

            //CreateMap<IEnumerable<Stock>, IEnumerable<StockDto>>();
            //CreateMap<IEnumerable<Stock>, IEnumerable<StockDto>>().ReverseMap();

            //CreateMap<IEnumerable<StockIn>, IEnumerable<StockInDto>>();
            //CreateMap<IEnumerable<StockIn>, IEnumerable<StockInDto>>().ReverseMap();

            //CreateMap<IEnumerable<StockOut>, IEnumerable<StockOutDto>>();
            //CreateMap<IEnumerable<StockOut>, IEnumerable<StockOutDto>>().ReverseMap();

            //CreateMap<IEnumerable<Category>, IEnumerable<CategoryDto>>();
            //CreateMap<IEnumerable<Category>, IEnumerable<CategoryDto>>().ReverseMap();
        }
    }
}
