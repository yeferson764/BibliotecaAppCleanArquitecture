using AutoMapper;
using BibliotecaApp.Application.DTOs.MaterialDtos;
using BibliotecaApp.Application.DTOs.PersonasDtos;
using BibliotecaApp.Application.DTOs.RolDtos;
using BibliotecaApp.Application.DTOs.TipoMaterialDtos;

namespace BibliotecaApp.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Material, MaterialDto>().ReverseMap();
            CreateMap<MaterialCreateAndUpdateDto, Material>();

            CreateMap<Persona, PersonaDto>()
                .ForMember(dest => dest.RolName, opt => opt.MapFrom(src => src.Rol.RolName))
                .ForMember(dest => dest.CapacidadPrestamo, opt => opt.MapFrom(src => src.Rol.CapacidadPrestamo))
                .ReverseMap();

            CreateMap<PersonaUpdateDto, Persona>();

            CreateMap<Prestamo, PrestamoDto>()
                .ForMember(dest => dest.PersonaNombre, opt => opt.MapFrom(src => src.Persona.Nombre))
                .ForMember(dest => dest.PersonaCedula, opt => opt.MapFrom(src => src.Persona.Cedula))
                .ForMember(dest => dest.MaterialTitulo, opt => opt.MapFrom(src => src.Material.Titulo))
                .ReverseMap();

            CreateMap<Rol, RolDto>().ReverseMap();

            CreateMap<TipoMaterialCreateAndUpdateDto, TipoMaterial>();
            CreateMap<TipoMaterial, TipoMaterialDto>().ReverseMap();

        }
    }
}
