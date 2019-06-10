using AutoMapper;
using AvivatecParty.Application.ViewModels;
using AvivatecParty.Domain.Entities;

namespace AvivatecParty.Services.Api.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Participante, ParticipanteViewModel>();
            CreateMap<Local, LocalViewModel>();
        }
    }
}