using Parking.Models;

namespace Parking.Notifications
{
    public interface INotification
    {
        void Notify(Client client);
    }
}
