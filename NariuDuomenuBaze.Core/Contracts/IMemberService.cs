using NariuDuomenuBaze.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NariuDuomenuBaze.Core.Contracts
{
    public interface IMemberService
    {
        Task<List<Member>> GetAllMembers();

        Task AddMember(Member member);

        Task UpdateMember(Member member);


        //Find
        Task<Member> GetMemberBySurname(string surname);


        //Delete
        Task DeleteMemberById(int id);
        Task DeleteMemberBySurname(string surname);





    }
}
