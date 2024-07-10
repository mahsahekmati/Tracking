using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faradid.Tracking.Domain.Entities.Common
{
    public class BaseDomainEntity
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime EditDate { get; set; }
        public int? EditBy { get; set; }
    }
}
