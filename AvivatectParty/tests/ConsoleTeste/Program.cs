using AvivatecParty.Domain.Core.Bus;
using AvivatecParty.Domain.Core.Commands;
using AvivatecParty.Domain.Core.Events;
using AvivatecParty.Domain.Core.Events.Interfaces;
using AvivatecParty.Domain.Core.Notifications;
using AvivatecParty.Domain.Entities;
using AvivatecParty.Domain.Entities.Participantes.Commands;
using AvivatecParty.Domain.Entities.Participantes.Events;
using AvivatecParty.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ConsoleTeste
{
    class Program
    {
        static void Main(string[] args)
        {
            var bus = new FakeBus();
            // registro sucesso
            //Participante participante = new Participante("Rafael", "rafael@gmail.com", "rafael123", "rafael123");
            //var cmd = new RegistrarParticipanteCommand(participante);
            //bus.SendCommand(cmd);


            //// registro falha
            //Participante participante2 = new Participante("", "rafael.com", "ra", "rafael123");
            //var cmd2 = new RegistrarParticipanteCommand(participante2);
            //bus.SendCommand(cmd2);

            Console.ReadKey();
        }
    }


}
public class FakeBus : IBus
{
    public void RaiseEvent<T>(T theEvent) where T : Event
    {
        Publish(theEvent);
    }

    public void SendCommand<T>(T theCommand) where T : Command
    {
        Publish(theCommand);
    }

    private static void Publish<T>(T message) where T : Message
    {
        var msgType = message.MessageType;

        if (msgType.Equals("DomainNotification"))
        {
            var obj = new DomainNotificationHandler();
            ((IDomainNotificationHandler<T>)obj).Handle(message);
        }

        if (msgType.Equals("RegistrarParticipanteCommand") || msgType.Equals("AtualizarParticipanteCommand") || msgType.Equals("RemoverParticipanteCommand"))
        {
            var obj = new ParticipanteCommandHandler(new FakeUow(), new FakeBus(), new DomainNotificationHandler(), new FakeParticipanteRepository());
            ((IHandler<T>)obj).Handle(message);
        };


        if (msgType.Equals("RegistrarParticipanteEvent") || msgType.Equals("AtualizarParticipanteEvent") || msgType.Equals("RemoverParticipanteEvent"))
        {
            var obj = new ParticipanteEventHandler();
            ((IHandler<T>)obj).Handle(message);
        }


    }
}

public class FakeParticipanteRepository : IParticipanteRepository
{
    public void Add(Participante obj)
    {
        //
    }

    public void Dispose()
    {
        //
    }

    public IEnumerable<Participante> Find(Expression<Func<Participante, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Participante> GetAll()
    {
        throw new NotImplementedException();
    }

    public Participante GetById(Guid id)
    {
        // .ParticipanteFactory().NovoParticipanteCompleto(new Guid("ba11de4a-1088-4fb2-bc1d-6b5d36c7fcf2"), "Rafael", "email@ass.com", "rafeal", "123dfdsf", DateTime.Now.AddDays(2), true, false);
        return new Participante("Rafael", "rafael@ref.com", "rafeddd", "s3214d", DateTime.Now, true);
    }

    public void Remove(Guid id)
    {
        //
    }

    public int SaveChanges()
    {
        return 1;
    }

    public void Update(Participante obj)
    {
        //
    }
}

public class FakeUow : IUnitOfWork
{
    public CommandResponse Commit()
    {
        return new CommandResponse(true);
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }
}