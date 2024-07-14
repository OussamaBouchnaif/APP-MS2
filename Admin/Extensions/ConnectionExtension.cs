using Microsoft.EntityFrameworkCore;
using MS2Api.Data;

namespace Admin.Extensions
{
    public static class ConnectionExtension
    {
        public static IServiceCollection AddGestionCommandesContext(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<MyContext>(o =>
            o.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionDb")));
            return builder.Services;
        }
    }
}
