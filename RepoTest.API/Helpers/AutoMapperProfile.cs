/*
    Data Transfer Object By AutoMapper Library
*/

using AutoMapper;
using RepoTest.API.Dtos;
using RepoTest.API.Models;

namespace RepoTest.API.Helpers
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile(){
            CreateMap<Product, ProductDtos>().ReverseMap(); 
            CreateMap<BillFormDtos, Bill>().ForMember(dest => dest.BillItems, o => {
                o.MapFrom(p => p.BillItemsDtos);
            });
            CreateMap<BillItemFromDtos, BillItem>().ForMember(dest => dest.ItemNavigation, o => {
                o.MapFrom(p => p.ItemFormDtos);
            });
            CreateMap<ItemFormDtos, Item>();


            CreateMap<Bill, BillReturnDtos>().ForMember(dest => dest.BillItemReturnDtos, o => {
                o.MapFrom(p => p.BillItems);
            });
            CreateMap<BillItem, BillItemReturnDtos>().ForMember(dest => dest.ItemReturnDtos, o => {
                o.MapFrom(p => p.ItemNavigation);
            });
            CreateMap<Item, ItemReturnDtos>();
        }
    }
}