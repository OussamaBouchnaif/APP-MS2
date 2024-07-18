using Admin.Service.Contract;
using Microsoft.AspNetCore.Mvc;

namespace Admin.ViewComponents
{
    public class NotificationViewComponent : ViewComponent
    {
        private readonly INotificationService _notificationService;


        public NotificationViewComponent(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var viewModel = await _notificationService.GetNotificationsAsync();

            return View(viewModel);
        }
    }

    public class Notification
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Message { get; set; }
        public string TimeAgo { get; set; }
    }
}