using Data.Interface;
using Data.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApiCrud.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private IMember memberRepo;

        public MemberController(IMember _memberRepo) 
        {
            memberRepo = _memberRepo;
        }

        [HttpGet]
        public ActionResult<List<Member>> GetMembers()
        {
            return memberRepo.GetAllMembers().ToList();
        }
        [HttpGet]
        public ActionResult<Member> GetMemberByID(int id)
        {
            return memberRepo.GetMember(id);
        }
    }
}
