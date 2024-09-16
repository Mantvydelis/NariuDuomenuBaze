using NariuDuomenuBaze.Core.Contracts;
using NariuDuomenuBaze.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NariuDuomenuBaze.Core.Repositories
{
    public class MemberFileRepository : IMemberFileRepository
    {

        private readonly string _filePath;

        public MemberFileRepository(string memberFilePath)
        {
            _filePath = memberFilePath;
        }


        public async Task AddMember(Member member)
        {
            var newLine = $"{member.Id},{member.Name},{member.Surname},{member.PhoneNumber},{member.Email},{member.Branch},{member.Address},{member.PersonIdCode},{member.Gender},{member.MembershipFee},{member.Priorities}";
           
            await File.AppendAllTextAsync(_filePath, newLine + Environment.NewLine);  

        }

        public async Task DeleteMemberById(int id)
        {
            var lines = await File.ReadAllLinesAsync(_filePath);
            var updatedLines = lines.Where(line => !line.StartsWith(id.ToString())).ToList();
            await File.WriteAllLinesAsync(_filePath, updatedLines);
        }

        public async Task DeleteMemberBySurname(string surname)
        {
            var lines = await File.ReadAllLinesAsync(_filePath);
            var updatedLines = lines.Where(line => !line.Contains($",{surname},")).ToList();
            await File.WriteAllLinesAsync(_filePath, updatedLines);
        }

        public async Task UpdateMember(Member member)
        {
            var lines = await File.ReadAllLinesAsync(_filePath);
            var updatedLines = lines.Select(line =>
            {
                var fields = line.Split(',');
                if (int.Parse(fields[0]) == member.Id)
                {
                    return $"{member.Id},{member.Name},{member.Surname},{member.PhoneNumber},{member.Email},{member.Branch},{member.Address},{member.PersonIdCode},{member.Gender},{member.MembershipFee},{member.Priorities}";
                }
                return line;
            }).ToList();
            await File.WriteAllLinesAsync(_filePath, updatedLines);
        }
    }
}
