namespace FinanceTracking.Services
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Threading.Tasks;
	using FinanceTracking.Entities;
	using FinanceTracking.Enums;
	using FinanceTracking.Services.Interfaces;

	/// <summary>
	/// Мок для IDataService
	/// </summary>
	public class MockDataService : IDataService
	{
		private static readonly Random random = new Random();
		private const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
		// Листы, потому что при IEnumerable постоянно перевычислялись массивы
		private readonly List<Product> _products;
		private readonly List<Check> _checks;

		public MockDataService()
		{
			this._products = GetRandomProductList().ToList();
			this._checks = this.GetRandomCheckList().ToList();
		}

		public async Task<T> GetStatisticsAsync<T>(Func<IQueryable<Check>, T> request)
		{
			await Task.CompletedTask;

			return request.Invoke(this._checks.AsQueryable());
		}

		#region Helpers

		private static IEnumerable<Product> GetRandomProductList()
		{
			for (int i = 0; i < random.Next(30, 65); i++)
			{
				yield return new Product
				{
					Id = i,
					Name = RandomString(),
					ProductMeasurement = (ProductMeasurement)(random.Next(1, 3) * 10)
				};
			}
		}

		private IEnumerable<Shopping> GetRandomShoppingList()
		{
			for (int i = 0; i < random.Next(2, 10); i++)
			{
				yield return new Shopping
				{
					Id = i,
					Product = this._products.ElementAt(random.Next(this._products.Count)),
					Price = random.Next(1, 1000),
					Quantity = random.Next(1, 15)
				};
			}
		}

		private IEnumerable<Check> GetRandomCheckList()
		{
			for (int i = 0; i < random.Next(50, 150); i++)
			{
				yield return new Check
				{
					Id = i,
					Shopping = this.GetRandomShoppingList().ToList(),
					ShoppingDate = new DateTime(random.Next(2019, 2021), random.Next(1, 13), random.Next(1, 29))
				};
			}
		}

		private static string RandomString()
			=> new string(Enumerable.Repeat(chars, random.Next(2, 15))
					.Select(s => s[random.Next(s.Length)])
					.ToArray());

		#endregion
	}
}
