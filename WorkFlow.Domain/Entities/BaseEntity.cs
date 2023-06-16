﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkFlow.Domain.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }

        public  DateTime? CreatedDate { get; set; }
        //public virtual string CreatedBy { get; set; }
        public  DateTime? UpdatedDate { get; set; }
        public  DateTime? DeleteDate { get; set; }
        //public virtual string UpdatedBy { get; set; }

        public bool Deleted { get; set; }
    }
}
