using LMSProject.Models;
using LMSProject.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMSProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserDetailsController : ControllerBase
    {
        private readonly IRepo<int, UserDetails> _repo;

        public UserDetailsController(IRepo<int, UserDetails> repo)
        {
            _repo = repo;
        }

      
        [HttpPost]
        public ActionResult<UserDetails> Create(UserDetails user)
        {
            var e = _repo.Add(user);
            return Created("", e);
        }

        [HttpGet]
        public ActionResult<ICollection<UserDetails>> GET()
        {
            return Ok(_repo.GetAll());
        }

        [HttpPut]
        public ActionResult<UserDetails> Update(UserDetails user)
        {
            var detail = _repo.Update(user);
            if (detail == null)
                return BadRequest("No such employee");
            return Ok(detail);
        }

        [HttpDelete]
        public ActionResult<ICollection<UserDetails>> Delete(int id)
        {
            var emp = _repo.Delete(id);
            if (emp == null)
                return BadRequest("No such employee");
            return Ok(emp);
        }

    }
}
