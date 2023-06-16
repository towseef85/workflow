namespace WorkFlow.Application.Dtos.IdentityDtos
{
    public class GetUserDto
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string EngName { get; set; }
        public string ArbName { get; set; }
        public string UserTypeId { get; set; }
        public string RoleName { get; set; }
        public string UserMode { get; set; }
        public string Remarks { get; set; }
    }
}
