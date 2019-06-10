using AvivatecParty.Domain.Core.Events;
using AvivatecParty.Domain.Core.Events.Interfaces;
using System.Collections.Generic;

namespace AvivatecParty.Domain.Core.Notifications
{
    public interface IDomainNotificationHandler<T> : IHandler<T> where T : Message
    {
        bool HasNotifications();

        List<T> GetNotifications();
    }
}