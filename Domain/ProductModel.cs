using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Domain
{
	public class ProductModel
	{
		public string Name { get; set; }		
		public string Description { get; set; }
		public int? Price { get; set; }
		public string Category { get; set; }
	}
}
