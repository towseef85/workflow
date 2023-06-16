namespace WorkFlow.Application.Dtos.UserConditionDtos
{
    public class GetUsersConditionDto
    {
        public int Id { get; set; }
        public int RequestConditionId { get; set; }
        public string RequestConditionName { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string UserTypeId { get; set; }
        public string UserTypeName { get; set; }
        public int UserActionId { get; set; }
        public string UserActionName { get; set; }
        public int PriorityLevel { get; set; }
        public bool isFinal { get; set; } = false;
        public string DataSource { get; set; }
    }
}
