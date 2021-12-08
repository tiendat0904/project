using AutoMapper;
using DataEntryApplication.Server.Data.Entities;
using DataEntryApplication.Shared;

namespace DataEntryApplication.Server
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CMD1, CMD1Model>();
            CreateMap<CMD1Model, CMD1>();
        }
    }
}