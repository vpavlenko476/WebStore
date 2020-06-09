using Store.Entites;
using System.ComponentModel.DataAnnotations;

namespace Store.Entites
{
	public class ProductEntity: BaseEntity
	{
		[StringLength(50)]
		public string Name { get; set; }

		[StringLength(50)]
		public string Description { get; set; }
		public int? Price { get; set; }
		public string Category { get; set; }
	}
}
