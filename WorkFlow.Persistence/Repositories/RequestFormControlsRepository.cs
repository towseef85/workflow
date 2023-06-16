using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using WorkFlow.Application.Dtos.RequestFormControlsDtos;
using WorkFlow.Domain.Entities;
using WorkFlow.Application.Interfaces;
using WorkFlow.Persistence.Context;

namespace WorkFlow.Persistence.Repositories
{
    public class RequestFormControlsRepository : IRequestFormControlsRepository
    {
        public readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public RequestFormControlsRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<bool> AddRequestFormControls(PostRequestFormControlsDto RequestFormControlsDto, CancellationToken cancellationToken)
        {
            var formControls = new RequestFormControls{
                ControlName = RequestFormControlsDto.ControlName.ToLower(),
                EngCaption = RequestFormControlsDto.EngCaption,
                ArbCaption = RequestFormControlsDto.ArbCaption,
                ArbToolTip = RequestFormControlsDto.ArbToolTip,
                ControlType =RequestFormControlsDto.ControlType.ToLower(),
                HasDataSource = RequestFormControlsDto.DataSourceType != null,        
                IsRequired = RequestFormControlsDto.IsRequired,
                DataSourceType = RequestFormControlsDto.DataSourceType,
                DataSource  = RequestFormControlsDto.DataSource,
                ToolTip = RequestFormControlsDto.ToolTip,
                IsNumeric = RequestFormControlsDto.IsNumeric, 
                IsHide = RequestFormControlsDto.IsHide,
                RequestFormId = RequestFormControlsDto.RequestFormId
                };

          //  await  _context.RequestFormControls.AddAsync(_mapper.Map<RequestFormControls>(RequestFormControlsDto));
           await _context.RequestFormControls.AddAsync(formControls);
            var result = await _context.SaveChangesAsync(cancellationToken) > 0;
            if(result && RequestFormControlsDto.SelectData != null)
            {
               
                foreach (var item in RequestFormControlsDto.SelectData)
                {
                    var selectDataEntity = new ControlSelectData
                    {
                        FormControlId= formControls.Id,
                        Name = item.Name,
                        Value = item.Value,
                    };
                    _context.ControlSelectData.Add(selectDataEntity);
                }
                
                await _context.SaveChangesAsync(cancellationToken); 
            }
            return result;
        }

        public async Task<bool> DeleteRequestFormControls(int id)
        {
            var requestFormControls = await _context.RequestFormControls.FindAsync(id);
            if (requestFormControls == null) return false;
            requestFormControls.Deleted = true;
            requestFormControls.DeleteDate = DateTime.Now;
            var result = await _context.SaveChangesAsync() > 0;
            return result;
        }

        public async Task<List<GetRequestFormControlsDto>> GetAllRequestFormControls()
        {
            var requestFormControls = await _context.RequestFormControls.Include(x=>x.RequestForms).Include(x=>x.ControlConditions).ToListAsync();

            var resultData = _mapper.Map<List<GetRequestFormControlsDto>>(requestFormControls);
            return resultData;
        }

        public async Task<GetRequestFormControlsDto> GetRequestFormControlsById(int id)
        {
            var resultdata = await _context.RequestFormControls
                .ProjectTo<GetRequestFormControlsDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(x => x.Id == id);
            return resultdata;
        }

        public async Task<List<SelectData>> GetSelectDataForControl(int controlId)
        {
           var result = await _context.ControlSelectData.Where(x=>x.FormControlId == controlId).ToListAsync();
            var resultData = _mapper.Map<List<SelectData>>(result);
            return resultData;
        }

        public async Task<bool> UpdateRequestFormControls(UpdateRequestFormControlsDto RequestFormControlsDto)
        {
            var requestFormControls = await _context.RequestFormControls.FindAsync(RequestFormControlsDto.Id);
            if (requestFormControls == null) return false;
            _mapper.Map(RequestFormControlsDto, requestFormControls);
            var result = await _context.SaveChangesAsync() > 0;
            return result;
        }
    }
}
