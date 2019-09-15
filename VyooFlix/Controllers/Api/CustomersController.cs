using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using VyooFlix.App_Start;
using VyooFlix.Dtos;
using VyooFlix.Models;

namespace VyooFlix.Controllers.Api
{
	public class CustomersController : ApiController
	{
		private ApplicationDbContext _context;
		protected readonly IMapper _mapper;
		private readonly MapperConfiguration config;

		public CustomersController()
		{
			_context = new ApplicationDbContext();
			config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
			_mapper = config.CreateMapper();
		}

		// GET /api/customers
		public IEnumerable<CustomerDto> GetCustomers()
		{
			return _context.Customers.ToList().Select(_mapper.Map<Customer, CustomerDto>);
		}

		// GET /api/customers/1
		public CustomerDto GetCustomer(int id)
		{
			var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

			if (customer == null)
				throw new HttpResponseException(HttpStatusCode.NotFound);

			return _mapper.Map<Customer, CustomerDto>(customer);
		}

		// POST /api/customers
		[HttpPost]
		public CustomerDto CreateCustomer(CustomerDto customerDto)
		{
			if (!ModelState.IsValid)
				throw new HttpResponseException(HttpStatusCode.BadRequest);

			var customer = _mapper.Map<CustomerDto, Customer>(customerDto);
			_context.Customers.Add(customer);
			_context.SaveChanges();

			customerDto.Id = customer.Id;

			return customerDto;
		}

		// PUT /api/customers/1
		[HttpPut]
		public void UpdateCustomer(int id, CustomerDto customerDto)
		{
			if (!ModelState.IsValid)
				throw new HttpResponseException(HttpStatusCode.BadRequest);

			var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

			if (customerInDb == null)
				throw new HttpResponseException(HttpStatusCode.NotFound);

			_mapper.Map(customerDto, customerInDb);

			_context.SaveChanges();
		}

		// DELETE /api/customers/1
		[HttpDelete]
		public void DeleteCustomer(int id)
		{
			var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

			if (customerInDb == null)
				throw new HttpResponseException(HttpStatusCode.NotFound);

			_context.Customers.Remove(customerInDb);
			_context.SaveChanges();
		}
	}
}