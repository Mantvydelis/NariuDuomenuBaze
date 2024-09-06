using NariuDuomenuBaze.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NariuDuomenuBaze.Core.Models
{
    public class Member
    {
        [Key]
        public int Id { get; set; }

        public DateOnly ApprovedAt { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string Branch { get; set; }

        public string Address { get; set; }

        public int PersonIdCode { get; set; }

        public Gender Gender { get; set; }

        public bool MembershipFee { get; set; }

        public Priorities Priorities { get; set; }
        

    }
}
