using LMSProject.Models;
using LMSProject.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMSProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentsController : ControllerBase
    {
        private readonly IRepo<string, Documents> _repo;

        public DocumentsController(IRepo<string, Documents> repoo)
        {
            _repo = repoo;
        }

        [HttpPost]
        public ActionResult<Documents> Create(Documents user)
        {
            var e = _repo.Add(user);
            return Created("", e);
        }
        [HttpGet]
        public ActionResult<ICollection<Documents>> GET()
        {
            return Ok(_repo.GetAll());
        }
        [Route("GetDocumentsByUserId")]
        [HttpGet]
        public ActionResult<Documents> GetDocumentsByUserName(string un)
        {
            var user = _repo.GetAll();
            var myUsers = user.Where(e => e.UserName == un);
            if (myUsers == null)
                return NotFound("No user found");
            return Ok(myUsers);
        }
        [HttpPut]
        public ActionResult<Documents> Update(Documents user)
        {
            var detail = _repo.Update(user);
            if (detail == null)
                return BadRequest("No such Details Exists");
            return Ok(detail);
        }
    }
}
