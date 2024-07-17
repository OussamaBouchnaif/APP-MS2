using Admin.Models;
using Admin.ViewComponents;
using Admin.ViewModel;

namespace Admin.Service.Contract
{
    public interface INotificationService
    {
        Task<NotificationViewModel> GetNotificationsAsync();
    }
}
