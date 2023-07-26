using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkFlow.Application.Dtos.IdentityDtos;
using WorkFlow.Application.Interfaces;
using WorkFlow.Domain.Entities;
using WorkFlow.Persistence.Context;

namespace WorkFlow.Persistence.Repositories
{
    public class IdentityRepository : IIdentityRepository
    {
        private readonly UserManager<AppUsers> _userManager;
        public readonly ApplicationDbContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;
        public IdentityRepository(ApplicationDbContext context, RoleManager<IdentityRole> roleManager, UserManager<AppUsers> userManager)
        {
            _context = context;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task<bool> AddUser(PostUserDto postUserDto, CancellationToken cancellationToken)
        {
            var userExists = await _userManager.FindByEmailAsync(postUserDto.Email);
            if (userExists == null)
            {
            var user = new AppUsers
            {
                EngName = postUserDto.EngName,
                ArbName = postUserDto.ArbName,
                Email = postUserDto.Email,
                UserName = postUserDto.UserName,
                UserMode = postUserDto.UserMode,
                UserTypeId = postUserDto.UserTypeId,
                Remarks = postUserDto.Remarks
                
            };
                IdentityResult identityResult= await _userManager.CreateAsync(user, postUserDto.Password);
                if (identityResult.Succeeded)
                {
                    var getRole = await _roleManager.FindByIdAsync(postUserDto.UserTypeId);
                    IdentityResult roleresult = await _userManager.AddToRoleAsync(user, getRole.Name);
                    if (roleresult.Succeeded) return true;

                }
              
                    await _userManager.DeleteAsync(user);
                    return false;
                
            }
            return false;
        }

        public async Task<bool> AddUserRole(PostRoleDto postRoleDto, CancellationToken cancellationToken)
        {
            var roleExists = await _roleManager.RoleExistsAsync(postRoleDto.Role);
            if (!roleExists)
            {
                var role = new UserType
                {
                    //Name = postRoleDto.Role,
                    EngName = postRoleDto.EngName,
                    ArbName = postRoleDto.ArbName,
                    Remarks = postRoleDto.Remarks,
                    Deleted = false,
                    DeleteDate = null

                };
                IdentityResult roleResult = await _roleManager.CreateAsync(new IdentityRole(postRoleDto.Role));
                if (roleResult.Succeeded) return true;
            }
            return false;
        }

        public async Task<List<GetRoleDto>> GetAllRoles()
        {
            var roleList = await _roleManager.Roles.ToListAsync();
            GetRoleDto[] roles = new GetRoleDto[] { };
            var getlist = roles.ToList();
            if (roleList != null)
            {

                foreach (var role in roleList)
                {
                    var rolelist = new GetRoleDto
                    {
                        Id = role.Id,
                        Name = role.Name
                    };
                    getlist.Add(rolelist);

                }
            }

            return getlist;
        }

        public async Task<List<GetUserDto>> GetAllUsers()
        {
            var userlist = await _userManager.Users.Select(x => new GetUserDto()
            {
                Id = x.Id,
                UserName = x.UserName,
                ArbName=x.ArbName,
                Email = x.Email,
                EngName=x.EngName,
                Remarks=x.Remarks,
                UserMode=x.UserMode,
                UserTypeId=x.UserTypeId,
                RoleName= String.Join(",", _context.Roles.Where(y=>y.Id == x.UserTypeId).Select(x=>x.Name))
            }).ToListAsync();
            return userlist;
        }

        public async Task<bool> EditUser(PostUserDto postUserDto, CancellationToken cancellationToken)
        {
            var getUser = await _userManager.FindByIdAsync(postUserDto.Id);
            var getRole = await _roleManager.FindByIdAsync(getUser.UserTypeId);
         
            if (getUser != null)
            {
                getUser.ArbName = postUserDto.ArbName;
                getUser.Email = postUserDto.Email;
                getUser.EngName = postUserDto.EngName;
                getUser.Remarks = postUserDto.Remarks;
                getUser.UserMode = postUserDto.UserMode;
                getUser.UserTypeId = postUserDto.UserTypeId;
            }
            IdentityResult userResult = await _userManager.UpdateAsync(getUser);
            if (userResult.Succeeded)
            {
                if(getRole != null)
                {
                    if(getRole.Id != postUserDto.UserTypeId)
                    {
                        IdentityResult deleteRole = await _userManager.RemoveFromRoleAsync(getUser,getRole.Name);
                        if(deleteRole.Succeeded)
                        {
                            await _userManager.AddToRoleAsync(getUser, getRole.Name);
                            return true;
                        }
                        return false;
                    }

                    return true;
                }

            }
            return false;
        }

        public async Task<GetUserDto> GetUserById(string id)
        {
            var resultdata = await _userManager.FindByIdAsync(id);
            var result = new GetUserDto
            {
                Id = resultdata.Id,
                UserName = resultdata.UserName,
                Email = resultdata.Email,
                EngName = resultdata.EngName,
                ArbName = resultdata.ArbName,
                UserMode = resultdata.UserMode,
                UserTypeId = resultdata.UserTypeId,
                Remarks = resultdata.Remarks,

            };
              
            return result;
        }
    }
}
