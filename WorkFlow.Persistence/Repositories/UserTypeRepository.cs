using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkFlow.Application.Dtos.UsertypesDtos;
using WorkFlow.Application.Interfaces;
using WorkFlow.Domain.Entities;
using WorkFlow.Persistence.Context;

namespace WorkFlow.Persistence.Repositories
{
    public class UserTypeRepository : IUserTypeRepository
    {
        public readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly RoleManager<IdentityRole> _roleManager;
        public UserTypeRepository(ApplicationDbContext context, IMapper mapper, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _mapper = mapper;
            _roleManager = roleManager;
        }
        public async Task<bool> AddUserType(PostUserTypeDto UserTypeDto, CancellationToken cancellationToken)
        {
            var roleExists = await _roleManager.RoleExistsAsync(UserTypeDto.EngName);
            if (!roleExists)
            {
                IdentityResult roleResult = await _roleManager.CreateAsync(new IdentityRole(UserTypeDto.EngName));
                if (roleResult.Succeeded)
                {
                   // var getId = await _roleManager.FindByNameAsync(UserTypeDto.RoleName);
                    _context.UserTypes.Add(_mapper.Map<UserType>(UserTypeDto));
                var result = await _context.SaveChangesAsync(cancellationToken) > 0;
                return result;
                }
            }
            return false;
        }

        public async Task<bool> DeleteUserType(int id)
        {
            var UserType = await _context.UserTypes.FindAsync(id);

            if (UserType == null) return false;
            var getRole = await _roleManager.FindByNameAsync(UserType.EngName);
            IdentityResult deleteRole = await _roleManager.DeleteAsync(getRole);
            if (deleteRole.Succeeded)
            {
            UserType.Deleted = true;
            UserType.DeleteDate = DateTime.Now;
            var result = await _context.SaveChangesAsync() > 0;
             return result;
            }
            return false;
        }

        public async Task<List<GetUserTypeDto>> GetAllUserTypes()
        {
            var UserTypes = await _context.UserTypes.Where(x=>x.Deleted == false).ToListAsync();

            var resultData = _mapper.Map<List<GetUserTypeDto>>(UserTypes);
            return resultData;
        }

        public async Task<GetUserTypeDto> GetUserTypeById(int id)
        {
            var resultdata = await _context.UserTypes
               .ProjectTo<GetUserTypeDto>(_mapper.ConfigurationProvider)
               .FirstOrDefaultAsync(x => x.Id == id);
            return resultdata;
        }

        public async Task<bool> UpdateUserType(PostUserTypeDto UserTypeDto)
        {
            var UserType = await _context.UserTypes.FindAsync(UserTypeDto.Id);
            if (UserType == null) return false;
            _mapper.Map(UserTypeDto, UserType);
            var result = await _context.SaveChangesAsync() > 0;
            return result;
        }
    }
}
