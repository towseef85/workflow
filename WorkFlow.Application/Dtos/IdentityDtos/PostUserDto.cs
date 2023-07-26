namespace WorkFlow.Application.Dtos.IdentityDtos
{
    public class PostUserDto
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string EngName { get; set; }
        public string ArbName { get; set; }
        public string UserTypeId { get; set; }
        public string UserMode { get; set; }
        public string Remarks { get; set; }
    }
}
