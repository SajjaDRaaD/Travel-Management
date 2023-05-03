using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelManagement.Application.Services;
using TravelManagement.Domain.Repositories;
using TravelManagement.Infrastructure.EF.Contexts;
using TravelManagement.Infrastructure.EF.Options;
using TravelManagement.Infrastructure.EF.Repositories;
using TravelManagement.Infrastructure.EF.Services;
using TravelManagement.Shared.Options;

namespace TravelManagement.Infrastructure.EF
{
    internal static class Extensions
    {
        public static IServiceCollection AddSqlDb(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ITravelerCheckListRepository,TravelerCheckListRepository>();
            services.AddScoped<ITravelerCheckListReadService, TravelerCheckListReadService>();

            var options = configuration.GetOptions<DataBaseOptions>("ConnectionStrings");
            services.AddDbContext<ReadDbContext>(ctx=>
                ctx.UseSqlServer(options.ConnectionString));
            services.AddDbContext<WriteDbContext>(ctx =>
                ctx.UseSqlServer(options.ConnectionString));

            return services;
        }
    }
}
