using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkFlow.Application.Dtos.RequestTypeDtos;
using WorkFlow.Application.Interfaces;
using WorkFlow.Persistence.Context;
using WorkFlow.Domain.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;

namespace WorkFlow.Persistence.Repositories
{
    public class RequestTypesRepository : IRequestTypesRepository
    {
        public readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public RequestTypesRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<bool> AddRequestType(PostRequestTypeDto requestTypeDto, CancellationToken cancellationToken)
        {
           
            _context.RequestTypes.Add(_mapper.Map<RequestType>(requestTypeDto));
           var result= await _context.SaveChangesAsync(cancellationToken) > 0;
            return result;
        }

        public async Task<bool> DeleteRequestType(int id)
        {
            var requestType = await _context.RequestTypes.FindAsync(id);
            if(requestType == null) return false;
            requestType.Deleted = true;
            requestType.DeleteDate = DateTime.Now;
            var result = await _context.SaveChangesAsync() > 0;
            return result;
        }

        public async Task<List<GetRequestTypeDto>> GetAllRequestTypes()
        {
            var requestTypes = await _context.RequestTypes.ToListAsync();

            var resultData = _mapper.Map<List<GetRequestTypeDto>>(requestTypes);
            return resultData;

        }

        public async Task<GetRequestTypeDto> GetRequestTypeById(int id)
        {
            var resultdata= await _context.RequestTypes
                    .ProjectTo<GetRequestTypeDto>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync(x => x.Id == id);
            return resultdata;
        }

        public async Task<bool> UpdateRequestType(PostRequestTypeDto requestTypeDto)
        {
            var requestType = await _context.RequestTypes.FindAsync(requestTypeDto.Id);
            if (requestType == null) return false;
            _mapper.Map(requestTypeDto, requestType);
            var result = await _context.SaveChangesAsync() > 0;
            return result;


        }
    }
}
