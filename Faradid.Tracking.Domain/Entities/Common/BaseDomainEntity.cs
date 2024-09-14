﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faradid.Tracking.Domain.Entities.Common
{
    public class BaseDomainEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime EditDate { get; set; }
        public int? EditBy { get; set; }
    }
}
