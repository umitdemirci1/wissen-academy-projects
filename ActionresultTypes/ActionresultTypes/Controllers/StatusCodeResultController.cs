using Microsoft.AspNetCore.Mvc;

namespace ActionresultTypes.Controllers
{
    public class StatusCodeResultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public StatusCodeResult StatusCodeContent()
        {
            //return Ok();
            //return NotFound();
            //return BadRequest();
            //return Unauthorized();
            //return Forbid();
            return new StatusCodeResult(200);
        }
    }
}
