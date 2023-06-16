using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkFlow.Application.Dtos.RequestFormsDtos;
using WorkFlow.Application.Interfaces;
using WorkFlow.Domain.Entities;
using WorkFlow.Persistence.Context;

namespace WorkFlow.Persistence.Repositories
{
    public class RequestFormsRepository : IRequestFormsRepository
    {
        public readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public RequestFormsRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<bool> AddRequestForms(PostRequestFormsDto requestFormsDto, CancellationToken cancellationToken)
        {
            _context.RequestForms.Add(_mapper.Map<RequestForms>(requestFormsDto));
            var result = await _context.SaveChangesAsync(cancellationToken) > 0;
            return result;
        }

        public async Task<bool> DeleteRequestForms(int id)
        {
            var requestForms = await _context.RequestForms.FindAsync(id);
            if (requestForms == null) return false;
            requestForms.Deleted = true;
            requestForms.DeleteDate = DateTime.Now;
            var result = await _context.SaveChangesAsync() > 0;
            return result;
        }

        public async Task<List<GetRequestFormsDto>> GetAllRequestForms()
        {
            var requestForms = await _context.RequestForms.Include(x=>x.RequestType).Include(x=>x.FormControls).ToListAsync();

            var resultData = _mapper.Map<List<GetRequestFormsDto>>(requestForms);
            return resultData;
        }

        public async Task<GetRequestFormsDto> GetRequestFormsById(int id)
        {
            var resultdata = await _context.RequestForms
                  .ProjectTo<GetRequestFormsDto>(_mapper.ConfigurationProvider)
                  .FirstOrDefaultAsync(x => x.Id == id);
            return resultdata;
        }

        public async Task<bool> UpdateRequestForms(PostRequestFormsDto requestFormsDto)
        {
            var requestForm = await _context.RequestForms.FindAsync(requestFormsDto.Id);
            if (requestForm == null) return false;
            _mapper.Map(requestFormsDto, requestForm);
            var result = await _context.SaveChangesAsync() > 0;
            return result;
        }
    }
}
