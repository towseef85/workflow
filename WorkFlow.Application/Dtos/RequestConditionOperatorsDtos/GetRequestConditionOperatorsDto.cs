namespace WorkFlow.Application.Dtos.RequestConditionOperatorsDtos
{
    public class GetRequestConditionOperatorsDto
    {
        public int Id { get; set; }
        public int FormControlId { get; set; }
        public string ControlName { get; set; }
        public string Operand { get; set; }
        public string Operator { get; set; }
        public float Value { get; set; }
    }
}
