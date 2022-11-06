using LMSProject.Models;
using LMSProject.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMSProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanDetailsController : ControllerBase
    {
        private readonly IRepo<int, LoanDetails> _repo;

        public LoanDetailsController(IRepo<int, LoanDetails> repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public ActionResult<LoanDetails> Create(LoanDetails user)
        {
            var e = _repo.Add(user);
            return Created("", e);
        }


        [HttpGet]
        public ActionResult<ICollection<LoanDetails>> GET()
        {
            return Ok(_repo.GetAll());
        }

        [HttpPut]
        public ActionResult<LoanDetails> Update(LoanDetails employee)
        {
            var emp = _repo.Update(employee);
            if (emp == null)
                return BadRequest("No such employee");
            return Ok(emp);
        }

        [HttpDelete]
        public ActionResult<ICollection<LoanDetails>> Delete(int id)
        {
            var emp = _repo.Delete(id);
            if (emp == null)
                return BadRequest("No such employee");
            return Ok(emp);
        }
    }
}
