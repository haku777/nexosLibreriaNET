using AutoMapper;
using Nexos_Libreria_API.Common.Dto;
using Nexos_Libreria_API.DataAccess.Entity;
using Nexos_Libreria_API.Common.Dto.Autors;

namespace Nexos_Libreria_API.Services.AutoMapper
{
    public class BasicMapper : Profile
    {

        public BasicMapper() {

            CreateMap<Libros, BookDto>();
            CreateMap<BookDto, Libros>();
            CreateMap<Libros, BookUpdateDto>().ReverseMap();
            CreateMap<Libros, BookCreateDto>().ReverseMap();
           
            CreateMap<Autores, AutorsDto>().ReverseMap();
            CreateMap<Autores, AutorsUpdateDto>().ReverseMap();
            CreateMap<Autores, AutorsCreateDto>().ReverseMap();

            //CreateMap<Libros, BookDto>()
            //    .ForMember(l=>l.Id_Autor, l=>l.MapFrom(l=>l.Autor));
        }
    }
}
