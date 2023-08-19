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

            CreateMap<Libros, BookDto>()
                .ForMember(l => l.Fecha, d => d.MapFrom(d => d.FechaY))
                .ForMember(l => l.Id_autores, d => d.MapFrom(d => d.Autor));

            CreateMap<BookDto, Libros>()
                .ForMember(l => l.FechaY, d => d.MapFrom(d => d.Fecha))
                .ForMember(l => l.Autor, d => d.MapFrom(d => d.Id_autores));

            CreateMap<Autores, AutorDto>();
            CreateMap<AutorDto, Autores>();

            //CreateMap<Libros, BookDto>().ReverseMap();
        }
    }
}
