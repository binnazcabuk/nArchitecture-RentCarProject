using Application.Features.Models.Dtos;
using Application.Features.Models.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Models.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Model, ModelListDto>().ForMember(r => r.BrandName, opt => opt.MapFrom(t => t.Brand.Name)).ReverseMap();
            CreateMap<IPaginate<Model>, ListModel>().ReverseMap();
        }
    }
}