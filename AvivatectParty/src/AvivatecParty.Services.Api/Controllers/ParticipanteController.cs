using AutoMapper;
using AvivatecParty.Application.Interfaces;
using AvivatecParty.Application.ViewModels;
using AvivatecParty.Domain.Core.Bus;
using AvivatecParty.Domain.Core.Notifications;
using AvivatecParty.Domain.Entities;
using AvivatecParty.Domain.Entities.Participantes.Commands;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace AvivatecParty.Services.Api.Controllers
{
    [Route("api/")]
    [ApiController]
    public class ParticipanteController : BaseController
    {
        private readonly IParticipanteAppService _participanteAppService;
        private readonly IBus _bus;
        private readonly IParticipanteRepository _participanteRepository;
        private readonly IMapper _mapper;

        public ParticipanteController(IDomainNotificationHandler<DomainNotification> notifications,
                                      IBus bus,
                                      IParticipanteAppService participanteAppService,
                                      IParticipanteRepository participanteRepository,
                                      IMapper mapper) : base(notifications, bus)
        {
            _participanteAppService = participanteAppService;
            _participanteRepository = participanteRepository;
            _mapper = mapper;
            _bus = bus;
        }

        [HttpGet]
        [Route("participantes")]
        public IEnumerable<ParticipanteViewModel> Get()
        {
            return _participanteAppService.GetAll();
        }

        [HttpGet]
        [Route("participantes/{id:guid}")]
        public ParticipanteViewModel Get(Guid id, int version)
        {
            return _participanteAppService.GetById(id);
        }

        [HttpPost]
        [Route("participantes")]
        public IActionResult Post([FromBody] ParticipanteViewModel participanteViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotificarErroModelInvalida();
                return Response();
            }

            var participanteCommand = _mapper.Map<RegistrarParticipanteCommand>(participanteViewModel);

            _bus.SendCommand(participanteCommand);
            return Response(participanteCommand);
        }

        [HttpPut]
        [Route("participantes")]
        public IActionResult Put([FromBody] ParticipanteViewModel participanteViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotificarErroModelInvalida();
                return Response();
            }

            _participanteAppService.Update(participanteViewModel);
            return Response(participanteViewModel);
        }

        [HttpDelete]
        [Route("participantes/{id:guid}")]
        public IActionResult Delete(Guid id)
        {
            _participanteAppService.Remove(id);
            return Response();
        }

        [HttpGet]
        [Route("participantes/locais")]
        public IEnumerable<LocalViewModel> ObterLocais()
        {
            //return new LocalViewModel().ListarLocais();
            return _participanteAppService.GetAllLocais();
        }
    }
}