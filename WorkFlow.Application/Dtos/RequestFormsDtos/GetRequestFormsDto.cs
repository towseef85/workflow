using WorkFlow.Application.Dtos.RequestFormControlsDtos;
using WorkFlow.Application.Dtos.RequestTypeDtos;

namespace WorkFlow.Application.Dtos.RequestFormsDtos
{
    public class GetRequestFormsDto
    {
        public int Id { get; set; }
        public string EngName { get; set; }
        public string ArbName { get; set; }
        public string EngDescription { get; set; }
        public string ArbDescription { get; set; }
        public int? Rank { get; set; }
        public int RequestTypeId { get; set; }
        public bool Deleted { get; set; }
        public virtual GetRequestTypeDto RequestType { get; set; }
        public ICollection<GetRequestFormControlsDto> FormControls { get; set; }
    }
}
