using LMSProject.Models;
using LMSProject.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMSProject.Controllers
{
    [EnableCors("MyCors")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoanDetailsController : ControllerBase
    {
        /* private readonly IRepo<int, LoanDetails> _repo;*/
        private readonly ILoan<int, LoanDetails> _repo;

        // New Additional Code 
        /*private readonly ILoginService _loginService;*/

        /* public LoanDetailsController(IRepo<int, LoanDetails> repo)
         {
             _repo = repo;
         }*/

        public LoanDetailsController(ILoan<int, LoanDetails> repoo)
        {
            _repo = repoo;
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

        [Route("GetLoanDetailsByUserName")]
        [HttpGet]
        public ActionResult<LoanDetails> GetLoanDetailsByUserName(string un)
        {
            var user = _repo.GetAll();
            var myUsers = user.Where(e => e.UserName == un);
            if (myUsers == null)
                return NotFound("No user found");
            return Ok(myUsers);
        }

        [HttpPut]
        public ActionResult<LoanDetails> Update(LoanDetails user)
        {
            var detail = _repo.Update(user);
            if (detail == null)
                return BadRequest("No such Details Exists");
            return Ok(detail);
        }
        [Route("/UpdateStatus")]
        [HttpPatch]
        public ActionResult<LoanDetails> UpdateStatus(LoanDetails customer)
        {
            var user = _repo.UpdateStatus(customer);
            if (user == null)
                return BadRequest("No such Loanid");
            return Ok(user);
        }

        [HttpDelete]
        public ActionResult<ICollection<LoanDetails>> Delete(int id)
        {
            var detail = _repo.Delete(id);
            if (detail == null)
                return BadRequest("No such Details exists");
            return Ok(detail);
        }
    }
}
