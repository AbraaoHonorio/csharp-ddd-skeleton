using System.Collections.Generic;
using System.Linq;

namespace XPTO.Core.Domain
{
    public abstract class Notifiable
    {
        private readonly List<DomainNotifier> _notifications;

        protected Notifiable() => _notifications = new List<DomainNotifier>();

        protected IReadOnlyCollection<DomainNotifier> Notifications => _notifications;

        protected void AddNotification(string message) => _notifications.Add(new DomainNotifier(message));

        protected void AddNotification(DomainNotifier notification) => _notifications.Add(notification);

        protected void AddNotifications(IReadOnlyCollection<DomainNotifier> notifications) => _notifications.AddRange(notifications);

        protected void AddNotifications(IList<DomainNotifier> notifications) => _notifications.AddRange(notifications);

        protected void AddNotifications(ICollection<DomainNotifier> notifications) => _notifications.AddRange(notifications);

        protected void AddNotifications(Notifiable item) => AddNotifications(item.Notifications);

        protected void AddNotifications(params Notifiable[] items)
        {
            foreach (var item in items)
                AddNotifications(item);
        }

        protected void Clear() => _notifications.Clear();

        protected bool Invalid => _notifications.Any();

        protected bool Valid => !Invalid;
    }
}