using NariuDuomenuBaze.Core.Contracts;
using NariuDuomenuBaze.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NariuDuomenuBaze.Core.Services
{
    public class MemberService : IMemberService
    {
        private readonly IMemberEfDbRepository _memberEfDbRepository;
        private readonly IMemberFileRepository _memberFileRepository;

        public MemberService(IMemberEfDbRepository efDbRepository, IMemberFileRepository memberFileRepository)
        {
            _memberEfDbRepository = efDbRepository;
            _memberFileRepository = memberFileRepository;
        }

        public async Task AddMember(Member member)
        {
            await _memberEfDbRepository.AddMember(member);
            await _memberFileRepository.AddMember(member);
        }

        public async Task DeleteMemberById(int id)
        {
            await _memberEfDbRepository.DeleteMemberById(id);
            await _memberFileRepository.DeleteMemberById(id);

        }

        public async Task DeleteMemberBySurname(string surname)
        {
            await _memberEfDbRepository.DeleteMemberBySurname(surname);
            await _memberFileRepository.DeleteMemberBySurname(surname);
        }

        public async Task<List<Member>> GetAllMembers()
        {
            return await _memberEfDbRepository.GetAllMembers();
        }

        public async Task<Member> GetMemberBySurname(string surname)
        {
            return await _memberEfDbRepository.GetMemberBySurname(surname);
        }

        public async Task UpdateMember(Member member)
        {
            await _memberEfDbRepository.UpdateMember(member);
            await _memberFileRepository.UpdateMember(member);

        }
    }
}
