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
            // Récupérer les données de VeilleContextuelle avec l'inclusion de Utilisateur
            var veilleContextuelles = await _repository.FindManyByExpression(v => true)
                                             .Include(v => v.Utilisateur)
                                             .ToListAsync();

            // Transformer les données en objets Notification
            var notifications = veilleContextuelles.Select(v => new Notification
            {
                UserName = v.Utilisateur?.Nom ?? "Unknown User", // Utiliser "Unknown User" si Utilisateur est null
                Message = v.DetailsEvenement,
                TimeAgo = v.DateEvenement.ToString("f"), // Format de la date selon vos besoins
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
