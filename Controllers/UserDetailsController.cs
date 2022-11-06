using LMSProject.Models;
using LMSProject.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMSProject.Controllers
{
    [EnableCors("MyCors")]
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

        [Route("UserdetailById")]
        [HttpGet]
        public ActionResult<UserDetails> UserdetailById(int key)
        {
            var obj = _repo.Get(key);
            if(obj == null)
                return BadRequest("No such User Details Exists"); ;
            return Ok(obj);
        }

        [HttpPut]
        public ActionResult<UserDetails> Update(UserDetails user)
        {
            var detail = _repo.Update(user);
            if (detail == null)
                return BadRequest("No such Details Exists");
            return Ok(detail);
        }

        [Route("GetUserByUserName")]
        [HttpGet]
        public ActionResult<UserDetails> GetUserByUserName(string un)
        {
            var user = _repo.GetAll();
            var myUsers = user.Where(e => e.UserName == un);
            if (myUsers == null)
                return NotFound("No user found");
            return Ok(myUsers);
        }

        [Route("DeleteUserById")]
        [HttpDelete]
        public ActionResult<ICollection<UserDetails>> DeleteUserById(int id)
        {
            var detail = _repo.Delete(id);
            if (detail == null)
                return BadRequest("No such User Details Exists");
            return Ok(detail);
        }

    }
}
