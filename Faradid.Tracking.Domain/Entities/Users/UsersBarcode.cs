using Faradid.Tracking.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faradid.Tracking.Domain.Entities.Users
{
    public class UsersBarcode:BaseDomainEntity
    {
        [Required]
        [ForeignKey(nameof(Users))]
        public int UserId { get; set; }
        [MaxLength(15)]
        public string Barcode { get; set; }
        public bool IsUse { get; set; }
        public Users Users { get; set; }
    }
}
