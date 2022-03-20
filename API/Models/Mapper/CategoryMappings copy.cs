using API.Data.Entities;
using API.Models.Dtos;
using AutoMapper;

namespace API.Models.Mapper
{
    public class CategoryMappings : Profile
    {
        public CategoryMappings()
        {
            CreateMap<Category, CategoryCreateDto>().ReverseMap();
            CreateMap<Category, CategoryViewDto>().ReverseMap();
            CreateMap<Category, CategoryEditDto>().ReverseMap();
        }
    }
}