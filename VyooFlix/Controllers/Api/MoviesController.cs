﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
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
            return _context.Movies
                .Include(m => m.Genre)
                .ToList()
                .Select(_mapper.Map<Movie, MovieDto>);
        }

        // GET /api/movies/1
        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return NotFound();

            return Ok(_mapper.Map<Movie, MovieDto>(movie));
        }

        // POST /api/movies
        [HttpPost]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movie = _mapper.Map<MovieDto, Movie>(movieDto);
            _context.Movies.Add(movie);
            _context.SaveChanges();

            movieDto.Id = movie.Id;

            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);
        }

        // PUT /api/movies/1
        [HttpPut]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public void UpdateMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var movieInDb = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movieInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _mapper.Map(movieDto, movieInDb);

            _context.SaveChanges();
        }

        // DELETE /api/movies/1
        [HttpDelete]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public void DeleteMovie(int id)
        {
            var movieInDb = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movieInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Movies.Remove(movieInDb);
            _context.SaveChanges();
        }
    }
}