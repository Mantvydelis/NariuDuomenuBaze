using Microsoft.EntityFrameworkCore;
using NariuDuomenuBaze.Core.Contracts;
using NariuDuomenuBaze.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NariuDuomenuBaze.Core.Repositories
{
    public class MemberEfDbRepository : IMemberEfDbRepository
    {
        public async Task AddMember(Member member)
        {
            using (var context = new MyDbContext())
            {
                await context.Members.AddAsync(member);
                await context.SaveChangesAsync();
            }
        }

        public async Task DeleteMemberById(int id)
        {
            using (var context = new MyDbContext())
            {
                context.Members.Remove(await context.Members.FindAsync(id));
                await context.SaveChangesAsync();
            }
        }

        public async Task DeleteMemberBySurname(string surname)
        {
            using (var context = new MyDbContext())
            {
                context.Members.Remove(await context.Members.FindAsync(surname));
                await context.SaveChangesAsync();
            }
        }

        public async Task<List<Member>> GetAllMembers()
        {
            using (var context = new MyDbContext())
            {
                List<Member> allMembers = await context.Members.ToListAsync();
                return allMembers;
            }
        }

        public async Task<Member> GetMemberBySurname(string surname)
        {
            using (var context = new MyDbContext())
            {
                Member foundMember = context.Members.Where(x => x.Surname == surname).First();
                return foundMember;
            }
        }

        public async Task UpdateMember(Member member)
        {
            using (var context = new MyDbContext())
            {
                context.Members.Update(member);
                await context.SaveChangesAsync();
            }
        }
    }
}
