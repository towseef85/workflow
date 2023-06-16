namespace WorkFlow.Application.Dtos.RequestTypeDtos
{
    public class GetRequestTypeDto
    {
        public int Id { get; set; }
        public string EngName { get; set; }
        public string ArbName { get; set; }
        public bool Deleted { get; set; }
    }
}
