using Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BuggyController : BaseApiController
    {
        public readonly StoreContext _context;

        public BuggyController(StoreContext context)
        {
            _context = context;
           
        }

        [HttpGet("testauth")]
        [Authorize]
        public ActionResult<string> GetSecretTest()
        {
            return "secret text is here";
        }
    }
}