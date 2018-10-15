using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MissionApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MissionApi.Controllers
{
    [Route("api/[controller]/[Action]")]
    public class MissionsController : Controller
    {
       
        MissionsContext db;
        public MissionsController(MissionsContext context)
        {
           
            this.db = context;
            if (!db.Missions.Any())
            {
                db.Missions.Add(new Mission { Name = "Tom1" });
                db.Missions.Add(new Mission { Name = "Alice" });
                db.SaveChanges();
            }
        }

        [HttpGet]
        public IEnumerable<Mission> Get()
        {
            return db.Missions.ToList();
        }

        // GET api/users/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
           Mission mission = db.Missions.FirstOrDefault(x => x.Id == id);
            if (mission == null)
                return NotFound();
            return new ObjectResult(mission);
        }
        
        [HttpGet("{name}")]
        public List<Mission> GetMissions(string name)
        {
            IEnumerable<Mission> query = db.Missions;
            query = query.Where(m => m.Name.Contains(name));
            return query.ToList();
        }

        // POST api/users
        [HttpPost]
        public IActionResult Post([FromBody]Mission mission)
        {
            if (mission == null)
            {
                return BadRequest();
            }

            db.Missions.Add(mission);
            db.SaveChanges();
            return Ok(mission);
        }

        // PUT api/users/
        [HttpPut]
        public IActionResult Put([FromBody]Mission mission)
        {
            if (mission == null)
            {
                return BadRequest();
            }
            if (!db.Missions.Any(x => x.Id == mission.Id))
            {
                return NotFound();
            }

            db.Update(mission);
            db.SaveChanges();
            return Ok(mission);
        }

        // DELETE api/users/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Mission mission = db.Missions.FirstOrDefault(x => x.Id == id);
            if (mission == null)
            {
                return NotFound();
            }
            db.Missions.Remove(mission);
            db.SaveChanges();
            return Ok(mission);
        }


    }
}
