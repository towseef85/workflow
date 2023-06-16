using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkFlow.Application.Dtos.UserConditionDtos
{

    public class UserConditionDto

    {
        public int Id { get; set; }
        public int RequestConditionId { get; set; }
        public string UserId { get; set; }
        public string UserTypeId { get; set; }
        public int UserActionId { get; set; }
        public int PriorityLevel { get; set; }
        public bool isFinal { get; set; } = false;
        public string DataSource { get; set; }
    }
}

