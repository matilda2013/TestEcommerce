using AngEcommerceApi.Data;
using AngEcommerceApi.Helper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngEcommerceApi.Controllers
{
    public class BuggyErrorController : ControllerBase
    {
        private readonly MyAppContext _context;
        public BuggyErrorController(MyAppContext context)
        {
            _context = context;
        }

        [HttpGet("not found")]
        public IActionResult GetNotFoundRequest()
        {
            var value = _context.Products.Find(23);
            if(value == null)
            {
                return NotFound(new ApiException(500));
            }
                
            return Ok();
        }

        [HttpGet("serverError")]
        public IActionResult GetServerError()
        {
            var thing = _context.Products.Find(23);
            var thingtoreturn = thing.ToString();//cant convert null to string,server error
            return Ok(thingtoreturn);
        }

        [HttpGet("badRequest")]
        public IActionResult GetBadRequest()
        {
            return BadRequest(new ApiResponse(400));
        }

        [HttpGet("badRequest/{id}")]
        public IActionResult GetBadRequest(int id)
        {
            return BadRequest();
        }
    }
}
