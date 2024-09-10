using NariuDuomenuBaze.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NariuDuomenuBaze.Core.Contracts
{
    public interface IMemberFileRepository
    {
        Task AddMember(Member member);
        Task UpdateMember(Member member);
        Task DeleteMemberById(int id);
        Task DeleteMemberBySurname(string surname);



    }
}
