using Admin.Models;
using Admin.Repository;
using Admin.Service.Contract;
using Admin.ViewComponents;
using Admin.ViewModel;
using IdentityModel;
using Microsoft.AspNetCore.Connections.Features;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System.Linq.Expressions;

namespace Admin.Service
{
    public class NotificationService : INotificationService
    {
        private readonly IRepository<VeilleContextuelle> _repository;

        public NotificationService(IRepository<VeilleContextuelle> repository)
        {
            _repository = repository;
        }

      
        public async Task<NotificationViewModel> GetNotificationsAsync()
        {

            var veilleContextuelles = await _repository.FindManyByExpression(v => true)
                                             .Include(v => v.Utilisateur)
                                             .ToListAsync();

            // Transformer les données en objets Notification
            var notifications = veilleContextuelles.Select(v => new Notification
            {
                Id = v.Id,
                UserName = v.Utilisateur?.Nom ?? "Unknown User",
                Message = v.DetailsEvenement,
                TimeAgo = v.DateEvenement.ToString("f"), 
            }).ToList();

            var viewModel = new NotificationViewModel
            {
                TotalCount = notifications.Count,
                Notifications = notifications
            };

            return viewModel;
        }
    }
}
