using AutoMapper;
using Store.Domain;
using Store.Entites;

namespace Store.Tests
{
	internal static class Mapper
	{
		public static MapperConfiguration Config 
		{ 
			get
			{
				return new MapperConfiguration(cfg => {
					cfg.CreateMap<ProductEntity, ProductModel>();
				});
			}
		}
	}
}
