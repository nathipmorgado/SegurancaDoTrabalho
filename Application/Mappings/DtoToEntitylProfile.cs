using SegurancaTrabalho.ServiceInterfaceLayer.Dto;
using AutoMapper;
using SegurancaTrabalho.BusinessEntities.Entities;
using Application.Dto;
using Domain.Entities.Entities;

namespace SegurancaTrabalho.ServiceLayer.Mappings
{
    public class DtoToEntitylProfile : Profile
    {
        public DtoToEntitylProfile()
        {
            

            CreateMap<Token_Entity, TokenDto>()
                .ReverseMap();

            CreateMap<Empresa_Entity, Empresa_Dto>()
                .ReverseMap();

            CreateMap<Colaborador_Entity, Colaborador_Dto>()
                .ReverseMap();

            CreateMap<Cargo_Entity, Cargo_Dto>()
               .ReverseMap();

            CreateMap<Funcionario_Entity, Funcionario_Dto>()
                .ReverseMap();

            CreateMap<RamoDeAtividade_Entity, RamoDeAtividade_Dto>()
                .ReverseMap();

        }
    }
}
