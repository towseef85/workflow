using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using WorkFlow.Application.Dtos.RequestConditionOperatorsDtos;
using WorkFlow.Application.Dtos.RequestFormControlConditionsDtos;
using WorkFlow.Application.Interfaces;
using WorkFlow.Domain.Entities;
using WorkFlow.Persistence.Context;

namespace WorkFlow.Persistence.Repositories
{
    public class ControlConditionRepository : IControlConditionRepository
    {
        public readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public ControlConditionRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<bool> AddControlCondition(PostRequestFormControlConditionDto ControlConditionDto, CancellationToken cancellationToken)
        {
            _context.RequestControlConditions.Add(_mapper.Map<RequestControlConditions>(ControlConditionDto));
            var result = await _context.SaveChangesAsync(cancellationToken) > 0;
            return result;
        }

        public async Task<bool> DeleteControlCondition(int id)
        {
            var condition = await _context.RequestControlConditions.FindAsync(id);
            if (condition == null) return false;
            condition.Deleted = true;
            condition.DeleteDate = DateTime.Now;
            var result = await _context.SaveChangesAsync() > 0;
            return result;
        }

        public async Task<List<GetRequestFormControlConditionsDto>> GetAllControlConditions()
        {
            var requestFormControlConditions = await _context.RequestControlConditions.Include(x=>x.RequestForms).Include(x=>x.RequestConditionOperators).ToListAsync();

            var resultData = _mapper.Map<List<GetRequestFormControlConditionsDto>>(requestFormControlConditions);
            return resultData;
        }

        public async Task<List<GetRequestFormControlConditionsDto>> GetControlConditionByFormId(int id)
        {
            var conditionList = new List<GetRequestFormControlConditionsDto>();
            var result = await _context.RequestControlConditions.Include(x=>x.RequestConditionOperators).Include(x=>x.RequestForms.FormControls).Where(x=>x.FormId == id).ToListAsync();
            foreach (var condition in result)
            {
                var formcondition = new GetRequestFormControlConditionsDto
                {
                    Id = condition.Id,
                    FormId = condition.FormId,
                    ArbDescription = condition.ArbDescription,
                    EngDescription = condition.EngDescription,
                    EscalationHours = condition.EscalationHours,
                    RestrictForm = condition.RestrictForm,
                    Operators = condition.RequestConditionOperators.Select(x => new GetRequestConditionOperatorsDto
                    {
                        Id = x.Id,
                        FormControlId = x.FormControlId,
                        ControlName = condition.RequestForms.FormControls.Select(x => x.ControlName).FirstOrDefault(),
                        Operand = x.Operand,
                        Operator = x.Operator,
                        Value = x.Value

                    }).ToList()
                };
                conditionList.Add(formcondition);
                 }
                var resultData = _mapper.Map<List<GetRequestFormControlConditionsDto>>(conditionList);
            return resultData;
        }

        public async Task<GetRequestFormControlConditionsDto> GetControlConditionById(int id)
        {
            var resultdata = await _context.RequestControlConditions
              .ProjectTo<GetRequestFormControlConditionsDto>(_mapper.ConfigurationProvider)
              .FirstOrDefaultAsync(x => x.Id == id);
            return resultdata;
        }

        public async Task<bool> UpdateControlCondition(PostRequestFormControlConditionDto ControlConditionDto)
        {
            var resultdata = await _context.RequestControlConditions.FindAsync(ControlConditionDto.Id);
            if (resultdata == null) return false;
            _mapper.Map(ControlConditionDto, resultdata);
            var result = await _context.SaveChangesAsync() > 0;
            return result;
        }
    }
}
