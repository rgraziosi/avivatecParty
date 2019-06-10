using AvivatecParty.Domain.Core.Events;
using System;

namespace AvivatecParty.Domain.Core.Commands
{
    public class Command : Message
    {
        public DateTime Timestamp { get; private set; }

        public Command()
        {
            Timestamp = DateTime.Now;
        }
    }
}