using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VyooFlix.Dtos;
using VyooFlix.Models;

namespace VyooFlix.App_Start
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			var config = new MapperConfiguration(cfg =>
			{
				cfg.CreateMap<Customer, CustomerDto>();
				cfg.CreateMap<CustomerDto, Customer>();
			});
		}
	}
}