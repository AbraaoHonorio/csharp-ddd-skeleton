using System.Collections.Generic;
using XPTO.Core.Domain;

namespace XPTO.Core.DomainNotification
{
    public interface IDomainNotification
    {
        bool HasNotification();

        IEnumerable<DomainNotifier> Notifications();

        void Handle(DomainNotifier notification);
    }
}