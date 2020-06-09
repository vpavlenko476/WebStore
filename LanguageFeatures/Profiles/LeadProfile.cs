using AutoMapper;
using Store.Domain;
using Store.Entites;

namespace Store.Profiles
{
    public class LeadProfile : Profile
    {
        public LeadProfile()
        {
            CreateMap<ProductEntity, ProductModel>();
        }
    }
}
