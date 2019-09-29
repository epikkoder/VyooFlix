using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using VyooFlix.App_Start;
using VyooFlix.Dtos;
using VyooFlix.Models;

namespace VyooFlix.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;
        protected readonly IMapper _mapper;
        private readonly MapperConfiguration config;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
            config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
            _mapper = config.CreateMapper();
        }

        // GET /api/movies
        public IEnumerable<MovieDto> GetMovies()
        {
            return _context.Movies.ToList().Select(_mapper.Map<Movie, MovieDto>);
        }

        // GET /api/movies/1
        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return NotFound();

            return Ok(_mapper.Map<Movie, MovieDto>(movie));
        }
    }
}