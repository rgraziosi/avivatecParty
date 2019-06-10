using AvivatecParty.Domain.Core.Commands;
using AvivatecParty.Domain.Core.Events;

namespace AvivatecParty.Domain.Core.Bus
{
    public interface IBus
    {
        void SendCommand<T>(T theCommand) where T : Command;

        void RaiseEvent<T>(T theEvent) where T : Event;
    }
}