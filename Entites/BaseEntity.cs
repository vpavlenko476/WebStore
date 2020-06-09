using System.ComponentModel.DataAnnotations;

namespace Store.Entites
{
	public class BaseEntity
	{
		[Key]
		public int Id { get; set; }

		[Timestamp]
		public byte[] TimeStamp { get; set; }
	}
}
