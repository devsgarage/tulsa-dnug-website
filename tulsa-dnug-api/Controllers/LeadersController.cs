using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using tulsa_dnug_website.api.DAL;
using tulsa_dnug_website.shared_kernel.Models;

namespace tulsa_dnug_website.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeadersController : ControllerBase
    {
        // **TODO: Add method security
        private readonly ILeaderRepository leaderRepository;

        public LeadersController(ILeaderRepository repo)
        {
            this.leaderRepository = repo;
        }

        // GET: api/Leaders
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(leaderRepository.GetLeaders());
        }

        // GET: api/Leaders/5
        [HttpGet("{id}", Name = "Get")]
        public Leader Get(int id)
        {
            return leaderRepository.GetLeader(id);
        }

        // POST: api/Leaders
        [HttpPost]
        public void Post([FromBody] string value)
        {
            throw new NotImplementedException();
        }

        // PUT: api/Leaders/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            throw new NotImplementedException();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
