using System.Collections.Generic;
using System.Linq;
using XPTO.Core.Domain;

namespace XPTO.Core.DomainNotification
{
    public class DomainNotification : IDomainNotification
    {
        private readonly IList<DomainNotifier> _domainNotifications;

        public DomainNotification() => _domainNotifications = new List<DomainNotifier>();

        public void Handle(DomainNotifier notification) => _domainNotifications.Add(notification);

        public bool HasNotification() => _domainNotifications.Any();

        public IEnumerable<DomainNotifier> Notifications() => _domainNotifications;
    }
}