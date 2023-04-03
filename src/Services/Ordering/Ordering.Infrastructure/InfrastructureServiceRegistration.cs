using System;
using Microsoft.Extensions.DependencyInjection;
using Ordering.Infrastructure.Persistence;
using Ordering.Application.Contracts.Persistence;
using Ordering.Infrastructure.Repositories;
using Ordering.Application.Models;
using Ordering.Application.Contracts.Infrastructure;
using Ordering.Infrastructure.Mail;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Ordering.Infrastructure
{
	public static class InfrastructureServiceRegistration
	{
		public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<OrderContext>(options =>
				options.UseSqlServer(configuration.GetConnectionString("OrderingConnectionString")));

			services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));
			services.AddScoped<IOrderRepository, OrderRepository>();

			services.Configure<EmailSettings>(c => configuration.GetSection("EmailSettings"));
			services.AddTransient<IEmailService, EmailService>();

			return services;
		}
	}
}

