using AutoMapper;
using VyooFlix.Dtos;
using VyooFlix.Models;

namespace VyooFlix.App_Start
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<Customer, CustomerDto>();
			CreateMap<CustomerDto, Customer>();

            CreateMap<Movie, MovieDto>();
            CreateMap<MovieDto, Movie>()
                .ForMember(m => m.Id, opt => opt.Ignore());
        }
	}
}