namespace WorkFlow.Application.Dtos.RequestFormsDtos
{
    public class PostRequestFormsDto
    {
        public int Id { get; set; }
        public string EngName { get; set; }
        public string ArbName { get; set; }
        public string EngDescription { get; set; }
        public string ArbDescription { get; set; }
        public int? Rank { get; set; }
        public int RequestTypeId { get; set; }
    }
}
