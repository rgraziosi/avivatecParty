using AvivatecParty.Application.Interfaces;
using AvivatecParty.Application.Services;
using AvivatecParty.Domain.Core.Bus;
using AvivatecParty.Domain.Core.Events.Interfaces;
using AvivatecParty.Domain.Core.Notifications;
using AvivatecParty.Domain.Entities;
using AvivatecParty.Domain.Entities.Participantes.Commands;
using AvivatecParty.Domain.Entities.Participantes.Events;
using AvivatecParty.Domain.Interface;
using AvivatecParty.Infra.CrossCutting.Bus;
using AvivatecParty.Infra.Data.Context;
using AvivatecParty.Infra.Data.Repository;
using AvivatecParty.Infra.Data.UoW;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace AvivatecParty.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            // Application
            //services.AddSingleton(Mapper.Configuration);
            //services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<IConfigurationProvider>(), sp.GetService));
            services.AddScoped<IParticipanteAppService, ParticipanteAppService>();

            // Domain - Commands
            services.AddScoped<IHandler<RegistrarParticipanteCommand>, ParticipanteCommandHandler>();
            services.AddScoped<IHandler<AtualizarParticipanteCommand>, ParticipanteCommandHandler>();
            services.AddScoped<IHandler<RemoverParticipanteCommand>, ParticipanteCommandHandler>();

            // Domain - Eventos
            services.AddScoped<IDomainNotificationHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<IHandler<ParticipanteResgistradoEvent>, ParticipanteEventHandler>();
            services.AddScoped<IHandler<ParticipanteAtualizadoEvent>, ParticipanteEventHandler>();
            services.AddScoped<IHandler<ParticipanteRemovidoEvent>, ParticipanteEventHandler>();

            // Infra - Data
            services.AddScoped<IParticipanteRepository, ParticipanteRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<AvivatecPartyContext>();

            // Infra - Bus
            services.AddScoped<IBus, InMemoryBus>();
        }
    }
}