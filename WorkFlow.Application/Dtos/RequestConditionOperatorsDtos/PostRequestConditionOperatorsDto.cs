namespace WorkFlow.Application.Dtos.RequestConditionOperatorsDtos
{
    public class PostRequestConditionOperatorsDto
    {
        public int FormControlId { get; set; }
        public string Operand { get; set; }
        public string Operator { get; set; }
        public float Value { get; set; }
    }
}
