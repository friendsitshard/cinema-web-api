using Davaleba.AutoMapper;
using Davaleba.DTOs;
using KinapoiskiDAL;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Davaleba.Controllers
{
    public class MoviesController : ApiController
    {
        private readonly KinoModel _context;

        public MoviesController()
        {
            _context = new KinoModel();
        }

        // GET: api/Movies
        public List<MovieDTO> Get()
        {
            var movies = _context.Movies.ToList();
            return AutoMapperConfig.Mapper.Map<List<MovieDTO>>(movies);
        }

        // GET: api/Movies/5
        public IHttpActionResult Get(int id)
        {
            var movie = _context.Movies.Find(id);

            if (movie == null)
            {
                return NotFound();
            }

            return Ok(AutoMapperConfig.Mapper.Map<MovieDTO>(movie));
        }

        // POST: api/Movies
        public IHttpActionResult Post([FromBody] MovieDTO movieDto)
        {
            var movie = AutoMapperConfig.Mapper.Map<Movy>(movieDto);

            _context.Movies.Add(movie);
            _context.SaveChanges();

            return Ok("Movie was added");
        }

        // PUT: api/Movies/5
        public IHttpActionResult Put(int id, [FromBody] Movy movie)
        {
            var data = _context.Movies.Find(id);

            if (movie == null)
            {
                return NotFound(); 
            }

            data.Title = movie.Title;
            data.ReleaseDate = movie.ReleaseDate;
            data.Genre = movie.Genre;
            data.Rating = movie.Rating;

            _context.SaveChanges();

            return Ok("Movie was updated");
        }

        // DELETE: api/Movies/5
        public IHttpActionResult Delete(int id)
        {
            var movie = _context.Movies.Find(id);

            if (movie == null)
            {
                return NotFound(); 
            }

            _context.Movies.Remove(movie);
            _context.SaveChanges();

            return Ok("Movie was deleted");
        }

        public IHttpActionResult Search([FromBody]string searchValue)
        {
            var data = _context.Movies
                .Where(m => m.Title.Contains(searchValue) || m.Genre.Contains(searchValue))
                .ToList();

            if (data == null)
                return NotFound();

            return Ok(AutoMapperConfig.Mapper.Map<List<MovieDTO>>(data));
        }

        public IHttpActionResult FilterByYear([FromBody] int year)
        {
            var movies = _context.Movies
                .Where(m => m.ReleaseDate.HasValue && m.ReleaseDate.Value.Year == year)
                .ToList();

            if (movies == null)
            {
                return NotFound(); 
            }

            return Ok(AutoMapperConfig.Mapper.Map<List<MovieDTO>>(movies));
        }
    }
}