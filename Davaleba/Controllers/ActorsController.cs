using Davaleba.AutoMapper;
using Davaleba.DTOs;
using KinapoiskiDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Davaleba.Controllers
{
    public class ActorsController : ApiController
    {
        private readonly KinoModel _context;

        public ActorsController()
        {
            _context = new KinoModel();
        }

        // GET: api/Actors
        public List<ActorDTO> Get()
        {
            var data = _context.Actors.ToList();
            return AutoMapperConfig.Mapper.Map<List<ActorDTO>>(data);
        }

        // GET: api/Actors/5
        public IHttpActionResult Get(int id)
        {
            var data = _context.Actors.Find(id);

            if (data == null)
                return NotFound();

            return Ok(AutoMapperConfig.Mapper.Map<ActorDTO>(data));
        }

        // POST: api/Actors
        public IHttpActionResult Post([FromBody]ActorDTO actor)
        {
            var aktor = AutoMapperConfig.Mapper.Map<Actor>(actor);

            _context.Actors.Add(aktor);
            _context.SaveChanges();

            return Ok("Actor was added");
        }

        // PUT: api/Actors/5
        public IHttpActionResult Put(int id, [FromBody] Actor updatedActor)
        {
            var data = _context.Actors.Find(id);

            if (data == null)
            {
                return NotFound(); 
            }

            data.FirstName = updatedActor.FirstName;
            data.LastName = updatedActor.LastName;
            data.DateOfBirth = updatedActor.DateOfBirth;

            _context.SaveChanges();

            return Ok("Actor was updated");
        }

        // DELETE: api/Actors/5
        public IHttpActionResult Delete(int id)
        {
            var data = _context.Actors.Find(id);

            if (data == null)
            {
                return NotFound(); 
            }

            _context.Actors.Remove(data);

            _context.SaveChanges();

            return Ok("Actor was deleted");
        }

        public IHttpActionResult Search([FromBody] string searchValue)
        {
            var data = _context.Actors.Where(m => m.FirstName.Contains(searchValue) || m.LastName.Contains(searchValue)).ToList();

            if (data == null)
                return NotFound();

            return Ok(AutoMapperConfig.Mapper.Map<List<ActorDTO>>(data));
        }
    }
}
