namespace WorkFlow.Application.Dtos.UserActionDto
{
    public class GetUserActionDto
    {
        public int Id { get; set; }
        public string EngName { get; set; }
        public string ArbName { get; set; }
        public string Remarks { get; set; }
        public bool IsApproval { get; set; }
        public bool IsReject { get; set; }
        public bool IsDelegate { get; set; }
    }
}
