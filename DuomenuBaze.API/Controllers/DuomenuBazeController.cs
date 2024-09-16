using Microsoft.AspNetCore.Mvc;
using NariuDuomenuBaze.Core.Contracts;
using NariuDuomenuBaze.Core.Models;
using NariuDuomenuBaze.Core.Services;

namespace DuomenuBaze.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DuomenuBazeController : Controller
    {

        private readonly IMemberEfDbRepository _memberEfDbRepository;
        private readonly IMemberFileRepository _memberFileRepository;
        private readonly IMemberService _memberService;


        public DuomenuBazeController(IMemberEfDbRepository memberEfDbRepository, IMemberFileRepository memberFileRepository, IMemberService memberService)
        {
            _memberEfDbRepository = memberEfDbRepository;
            _memberFileRepository = memberFileRepository;
            _memberService = memberService;
        }


        [HttpGet("GetAllMembers")]
        public async Task<IActionResult> Index()
        {
            var allMembers = await _memberService.GetAllMembers();
            return Ok(allMembers);
        }

        [HttpPost("AddMember")]
        public async Task<IActionResult> AddMember(Member member)
        {
            try
            {
                await _memberService.AddMember(member);
                return Ok();
            }
            catch
            {
                return Problem();
            }

        }

        [HttpPatch("UpdateMember")]
        public async Task<IActionResult> UpdateMember(Member member)
        {
            try
            {
                await _memberService.UpdateMember(member);
                return Ok(member);

            }
            catch
            {
                return Problem();
            }

        }

        [HttpGet("GetMemberBySurname")]
        public async Task<IActionResult> GetMemberBySurname(string surname)
        {
            try
            {
                var foundMember = await _memberService.GetMemberBySurname(surname);
                return Ok(foundMember);

            }
            catch
            {
                return Problem();

            }

        }

        [HttpDelete("DeleteMemberById")]
        public async Task<IActionResult> DeleteMemberById(int id)
        {

            await _memberService.DeleteMemberById(id);
            return Ok();

        }


        [HttpDelete("DeleteMemberBySurname")]
        public async Task<IActionResult> DeleteMemberBySurname(string surname)
        {

            await _memberService.DeleteMemberBySurname(surname);
            return Ok();

        }



    }
}
