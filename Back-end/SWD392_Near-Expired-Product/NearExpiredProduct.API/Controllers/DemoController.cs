using Microsoft.AspNetCore.Mvc;
using NearExpiredProduct.Data.Models;
using NearExpiredProduct.Service.InterfaceService;

namespace NearExpiredProduct.API.Controllers
{
    [ApiController]
    [Route("api/demo")]
    public class DemoController : Controller
    {
        private readonly IMemberService _memberService;
        public  DemoController(IMemberService memberService)
        {
            _memberService = memberService;
        }
        [HttpGet()]
        public async Task<ActionResult<List<Member>>> GetMembers()
        {
            var rs = await _memberService.GetMembers();
            return Ok(rs);
        }
    }
}
