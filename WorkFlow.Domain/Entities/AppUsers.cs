using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkFlow.Domain.Entities
{
    public class AppUsers : IdentityUser
    {
        public string EngName { get; set; }
        public string ArbName { get; set; }
        public string UserTypeId { get; set; }
        public string UserMode { get; set; }
        public string Remarks { get; set; }

    }
}
