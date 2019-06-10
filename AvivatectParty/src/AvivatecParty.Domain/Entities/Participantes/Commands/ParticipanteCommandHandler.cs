using AvivatecParty.Domain.CommandHandlers;
using AvivatecParty.Domain.Core.Bus;
using AvivatecParty.Domain.Core.Events.Interfaces;
using AvivatecParty.Domain.Core.Notifications;
using AvivatecParty.Domain.Entities.Participantes.Events;
using AvivatecParty.Domain.Interface;
using System;

namespace AvivatecParty.Domain.Entities.Participantes.Commands
{
    public class ParticipanteCommandHandler : CommandHandler,
        IHandler<RegistrarParticipanteCommand>,
        IHandler<AtualizarParticipanteCommand>,
        IHandler<RemoverParticipanteCommand>
    {
        private readonly IParticipanteRepository _participanteRepository;
        private readonly IBus _bus;

        public ParticipanteCommandHandler(IUnitOfWork uow, IBus bus, IDomainNotificationHandler<DomainNotification> notifications, IParticipanteRepository participanteRepository)
            : base(uow, bus, notifications)
        {
            _participanteRepository = participanteRepository;
            _bus = bus;
        }

        public void Handle(RegistrarParticipanteCommand message)
        {
            Participante participante = message.Participante;

            if (!ParticipanteValido(participante)) return;

            // Validação de negocio
            // Nome Igual X
            // Email Igual X
            // Login Igual X

            // Persistencia
            _participanteRepository.Add(participante);

            if (Commit())
            {
                _bus.RaiseEvent(new ParticipanteResgistradoEvent(message.Participante));
            }
        }

        public void Handle(AtualizarParticipanteCommand message)
        {
            if (!ParticipanteExistente(message.Participante.Id, message.MessageType)) return;

            // Validação de negocio
            // Nome Igual X
            // Email Igual X
            // Login Igual X

            Participante participante = message.Participante;

            if (!ParticipanteValido(participante)) return;

            _participanteRepository.Update(participante);

            if (Commit())
            {
                _bus.RaiseEvent(new ParticipanteAtualizadoEvent(message.Participante));
            }
        }

        public void Handle(RemoverParticipanteCommand message)
        {
            if (!ParticipanteExistente(message.Participante.Id, message.MessageType)) return;

            _participanteRepository.Remove(message.Participante.Id);

            if (Commit())
            {
                _bus.RaiseEvent(new ParticipanteRemovidoEvent(message.Participante.Id));
            }
        }

        #region [ Methods privates]

        private bool ParticipanteValido(Participante participante)
        {
            if (participante.Valido()) return true;

            NotificarValidacoesErro(participante.ValidationResult);
            return false;
        }

        private bool ParticipanteExistente(Guid Id, string messageType)
        {
            Participante participante = _participanteRepository.GetById(Id);

            if (participante != null) return true;

            _bus.RaiseEvent(new DomainNotification(messageType, "Participante não encontrado"));
            return false;
        }

        #endregion [ Methods privates]
    }
}