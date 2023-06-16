using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using WorkFlow.Application.Dtos.UserConditionDtos;
using WorkFlow.Application.Interfaces;
using WorkFlow.Domain.Entities;
using WorkFlow.Persistence.Context;

namespace WorkFlow.Persistence.Repositories
{
    public class UsersConditionRepository : IUsersConditionRepository
    {
        public readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public UsersConditionRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<bool> AddUsersCondition(PostUserConditionDto UserConditionDto, CancellationToken cancellationToken)
        {
            if (UserConditionDto.UserConditions.Any())
            {
               foreach(var userCondition in UserConditionDto.UserConditions)
                {
                    var data = new RequestConditionUsers
                    {
                        RequestConditionId= userCondition.RequestConditionId,
                        DataSource=userCondition.DataSource,
                        isFinal=userCondition.isFinal,
                        UserActionId=userCondition.UserActionId,
                        UserId=userCondition.UserId,
                        UserTypeId=userCondition.UserTypeId,
                        PriorityLevel=userCondition.PriorityLevel,             
                    };
                 await _context.RequestConditionUsers.AddAsync(data);
                }
            }
            // await _context.RequestConditionUsers.AddRangeAsync(_mapper.Map<RequestConditionUsers>(UserConditionDto.UserConditions));
            var result = await _context.SaveChangesAsync(cancellationToken) > 0;
            return result;
        }

        public async Task<bool> DeleteUsersCondition(int id)
        {
            var condition = await _context.RequestConditionUsers.FindAsync(id);
            if (condition == null) return false;
            condition.Deleted = true;
            condition.DeleteDate = DateTime.Now;
            var result = await _context.SaveChangesAsync() > 0;
            return result;
        }

        public async Task<List<GetUsersConditionDto>> GetAllUsersCondtions()
        {      
            var data = (from uc in _context.RequestConditionUsers
                       join cc in _context.RequestControlConditions on uc.RequestConditionId equals cc.Id into dataGroup
                       from rcc in dataGroup
                       join user in _context.Users on uc.UserId equals user.Id into dataUser
                       from m in dataUser.DefaultIfEmpty()
                       join ut in _context.Roles on uc.UserTypeId equals ut.Id into dataRoles
                       from dr in dataRoles.DefaultIfEmpty()
                       join ua in _context.UserActions on uc.UserActionId equals ua.Id into dataUserActions
                       from dua in dataUserActions.DefaultIfEmpty()
                       select new GetUsersConditionDto
                       {
                           Id = uc.Id,
                           RequestConditionId = uc.RequestConditionId,
                           UserTypeId = uc.UserTypeId,
                           UserTypeName= dr.Name,
                           UserActionId= uc.UserActionId,
                           UserActionName= dua.EngName,
                           UserId = uc.UserId,
                           UserName = m.UserName,
                           RequestConditionName= rcc.EngDescription,
                           PriorityLevel= uc.PriorityLevel,
                           isFinal=uc.isFinal,
                           DataSource= uc.DataSource,
                       }).ToList();
            return data;
        }

        public async Task<GetUsersConditionDto> GetUsersCondtionById(int id)
        {
            var resultdata = await _context.RequestConditionUsers
          .ProjectTo<GetUsersConditionDto>(_mapper.ConfigurationProvider)
          .FirstOrDefaultAsync(x => x.Id == id);
            return resultdata;
        }

        public async Task<bool> UpdateUsersCondition(UserConditionDto UserConditionDto)
        {
            var resultdata = await _context.RequestConditionUsers.FindAsync(UserConditionDto.Id);
            if (resultdata == null) return false;
            _mapper.Map(UserConditionDto, resultdata);
            var result = await _context.SaveChangesAsync() > 0;
            return result;
        }
    }
}
