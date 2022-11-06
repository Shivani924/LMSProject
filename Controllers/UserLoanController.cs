using LMSProject.Models;
using LMSProject.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMSProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserLoanController : ControllerBase
    {
        private readonly IRepo<int, UserLoan> _repo;

        public UserLoanController(IRepo<int, UserLoan> repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public ActionResult<UserLoan> Create(UserLoan user)
        {
            var e = _repo.Add(user);
            return Created("", e);
        }


        [HttpGet]
        public ActionResult<ICollection<UserLoan>> GET()
        {
            return Ok(_repo.GetAll());
        }

        [HttpPut]
        public ActionResult<UserLoan> Update(UserLoan employee)
        {
            var emp = _repo.Update(employee);
            if (emp == null)
                return BadRequest("No such employee");
            return Ok(emp);
        }

        [HttpDelete]
        public ActionResult<ICollection<UserLoan>> Delete(int id)
        {
            var emp = _repo.Delete(id);
            if (emp == null)
                return BadRequest("No such employee");
            return Ok(emp);
        }
    }
}
