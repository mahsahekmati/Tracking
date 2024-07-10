using Faradid.Tracking.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faradid.Tracking.Domain.Entities.Users
{
    public  class Users:BaseDomainEntity
    {
        [MaxLength(11)]
        public string MobileNumber { get; set; }
        [MaxLength(10)]
        public string NationalCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [MaxLength(256)]
        public string UserName { get; set; }

        [MaxLength(256)]
        public string Email { get; set; }
    }
}
