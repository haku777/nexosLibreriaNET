using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Nexos_Libreria_API.Common.Dto;
using Nexos_Libreria_API.DataAccess.Entity;

namespace Nexos_Libreria_API.Services.AutoMapper
{
    public class BasicMapper : Profile
    {

        public BasicMapper() {

            CreateMap<Libros, BookDto>();
            CreateMap<BookDto, Libros>();
            CreateMap<Libros, BookCreateDto>().ReverseMap();
            CreateMap<Libros, BookUpdateDto>().ReverseMap();
            CreateMap<Autores, AutorDto>().ReverseMap();
            //CreateMap<Libros, BookDto>().ReverseMap();
        }
    }
}
