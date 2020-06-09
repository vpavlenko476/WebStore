using Store.Domain;
using System.Collections.Generic;


namespace Store.Models.ViewModels
{
	public class ProductsListViewModel
	{
		public IEnumerable<ProductModel> Products { get; set; }
		public PagingInfo pagingInfo { get; set; }
	}
}
