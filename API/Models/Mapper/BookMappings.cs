using API.Data.Entities;
using API.Models.Dtos;
using AutoMapper;

namespace API.Models.Mapper
{
    public class BookMappings : Profile
    {
        public BookMappings()
        {
            CreateMap<Book, BookCreateDto>().ReverseMap();
            CreateMap<Book, BookViewDto>().ReverseMap();
            CreateMap<Book, BookEditDto>().ReverseMap();
        }
    }
}