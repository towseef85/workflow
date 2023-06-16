using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkFlow.Application.Dtos.UserActionDto;
using WorkFlow.Application.Interfaces;
using WorkFlow.Domain.Entities;
using WorkFlow.Persistence.Context;

namespace WorkFlow.Persistence.Repositories
{
    public class UserActionsRepository : IUserActionsRepository
    {
        public readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public UserActionsRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<bool> AddUserAction(PostUserActionDto UserActionDto, CancellationToken cancellationToken)
        {
           switch (UserActionDto.ActionType)
            {
                case "isApproval":
                    UserActionDto.IsApproval = true;
                    break;
                case "isReject":
                    UserActionDto.IsReject = true;
                    break;
                case "isDelegate":
                    UserActionDto.IsDelegate = true;
                    break;
            }

            _context.UserActions.Add(_mapper.Map<UserActions>(UserActionDto));
            var result = await _context.SaveChangesAsync(cancellationToken) > 0;
            return result;
        }

        public async Task<bool> DeleteUserAction(int id)
        {
            var UserAction = await _context.UserActions.FindAsync(id);
            if (UserAction == null) return false;
            UserAction.Deleted = true;
            UserAction.DeleteDate = DateTime.Now;
            var result = await _context.SaveChangesAsync() > 0;
            return result;
        }

        public async Task<List<GetUserActionDto>> GetAllUserActions()
        {
            var UserActions = await _context.UserActions.ToListAsync();

            var resultData = _mapper.Map<List<GetUserActionDto>>(UserActions);
            return resultData;
        }

        public async Task<GetUserActionDto> GetUserActionById(int id)
        {
            var resultdata = await _context.UserActions
               .ProjectTo<GetUserActionDto>(_mapper.ConfigurationProvider)
               .FirstOrDefaultAsync(x => x.Id == id);
            return resultdata;
        }

        public async Task<bool> UpdateUserAction(PostUserActionDto UserActionDto)
        {
            var UserAction = await _context.UserActions.FindAsync(UserActionDto.Id);
            if (UserAction == null) return false;
            switch (UserActionDto.ActionType)
            {
                case "isApproval":
                    UserActionDto.IsApproval = true;
                    break;
                case "isReject":
                    UserActionDto.IsReject = true;
                    break;
                case "isDelegate":
                    UserActionDto.IsDelegate = true;
                    break;
            }
            _mapper.Map(UserActionDto, UserAction);
            var result = await _context.SaveChangesAsync() > 0;
            return result;
        }
    }
}
