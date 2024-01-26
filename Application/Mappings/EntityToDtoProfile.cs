using SegurancaTrabalho.ServiceInterfaceLayer.Dto;
using AutoMapper;
using SegurancaTrabalho.BusinessEntities.Entities;
using Application.Dto;
using Domain.Entities.Entities;

namespace SegurancaTrabalho.ServiceLayer.Mappings
{
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile()
        {
            

            CreateMap<TokenDto, Token_Entity>()
               .ReverseMap();

            CreateMap<Empresa_Dto, Empresa_Entity>()
               .ReverseMap();

            CreateMap<Colaborador_Dto, Colaborador_Entity>()
                .ReverseMap();

            CreateMap<Cargo_Dto, Cargo_Entity>()
                .ReverseMap();

            CreateMap<Funcionario_Dto, Funcionario_Entity>()
             .ReverseMap();

            CreateMap<RamoDeAtividade_Dto, RamoDeAtividade_Entity>()
             .ReverseMap();

        }
    }
}
