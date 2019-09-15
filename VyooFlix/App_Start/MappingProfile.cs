﻿using AutoMapper;
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
		}
	}
}