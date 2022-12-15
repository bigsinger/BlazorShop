using BlazorShop.Data.Models;
using System.Linq.Dynamic.Core;
using System.Reflection;
using System.Text;

namespace Entities.Services;
public static class ProductsServiceExtensions {
	public static IQueryable<Product> SearchName(this IQueryable<Product> items, string searchText) {
		if(string.IsNullOrWhiteSpace(searchText))
			return items;

		return items.Where(p => p.Name.Contains(searchText));
	}

	public static IQueryable<Product> SearchSummary(this IQueryable<Product> items, string searchText) {
		if(string.IsNullOrWhiteSpace(searchText))
			return items;

		return items.Where(p => p.Summary.Contains(searchText));
	}
	public static IQueryable<Product> SearchDescription(this IQueryable<Product> items, string searchText) {
		if(string.IsNullOrWhiteSpace(searchText))
			return items;

		return items.Where(p => p.Description.Contains(searchText));
	}
	public static IQueryable<Product> Sort(this IQueryable<Product> items, string orderByQueryString) {
		if(string.IsNullOrWhiteSpace(orderByQueryString))
			return items;

		var orderParams = orderByQueryString.Trim().Split(',');
		var propertyInfos = typeof(Product).GetProperties(BindingFlags.Public | BindingFlags.Instance);
		var orderQueryBuilder = new StringBuilder();

		foreach(var param in orderParams) {
			if(string.IsNullOrWhiteSpace(param))
				continue;

			var propertyFromQueryName = param.Split(" ")[0];
			var objectProperty = propertyInfos.FirstOrDefault(pi => pi.Name.Equals(propertyFromQueryName, StringComparison.InvariantCultureIgnoreCase));

			if(objectProperty == null)
				continue;

			var direction = param.EndsWith(" desc") ? "descending" : "ascending";
			orderQueryBuilder.Append($"{objectProperty.Name} {direction}, ");
		}

		var orderQuery = orderQueryBuilder.ToString().TrimEnd(',', ' ');
		if(string.IsNullOrWhiteSpace(orderQuery))
			return items.OrderBy(e => e.Name);

		return items.OrderBy(orderQuery);
	}
}
