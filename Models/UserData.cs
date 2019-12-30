using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace WT03.Models
{
    public class UserData: IdentityUser
    {
        [PersonalData]
        public string FirstName { get; set; }
        [PersonalData]
        public string LastName { get; set; }
        [PersonalData]
        [MaxLength(5)]
        public int ControlNumber { get; set; }
        [PersonalData]
        public string Address1 { get; set; }
        [PersonalData]
        public string Address2 { get; set; }

        [PersonalData]
        public int PostalCode { get; set; }

        [PersonalData]
        public string City { get; set; }
    }
}
