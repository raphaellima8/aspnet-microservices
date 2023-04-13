using System;
using Microsoft.Extensions.Logging;
using Ordering.Domain.Entities;

namespace Ordering.Infrastructure.Persistence
{
	public class OrderContextSeed
	{
		public static async Task SeedAsync(OrderContext orderContext, ILogger<OrderContextSeed> logger)
		{
			if (!orderContext.Orders.Any())
			{
				orderContext.Orders.AddRange(GetPreconfiguredOrders());
				await orderContext.SaveChangesAsync();
				logger.LogInformation("Seed database associated with context {DbContextName}", typeof(OrderContext).Name);
			}
		}

		private static IEnumerable<Order> GetPreconfiguredOrders()
		{
			return new List<Order>
			{
				new Order()
				{
					UserName = "swn",
					FirstName = "Raphael",
					LastName = "Lima",
					EmailAddress = "email@email.com",
					AddressLine = "Teste Rua",
					Country = "Brasil",
					TotalPrice = 350,
					CardName = "Mastercard",
					CardNumber = "123456789",
					CreatedBy = "raphael",
					CreatedDate = DateTime.Today,
					CVV = "123",
					Expiration = "02/28",
					LastModifiedBy = "Raphael Lima",
					LastModifiedDate = DateTime.Today,
					PaymentMethod = 1,
					State = "SP",
					ZipCode = "12312312"
				}
			};
		}

    }
}

