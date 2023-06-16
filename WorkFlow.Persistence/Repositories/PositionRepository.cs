using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkFlow.Application.Dtos.PositionDtos;
using WorkFlow.Application.Interfaces;
using WorkFlow.Domain.Entities;
using WorkFlow.Persistence.Context;

namespace WorkFlow.Persistence.Repositories
{
    public class PositionRepository : IPositionsRepository
    {
        public readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public PositionRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<bool> AddPosition(PostPositionDto PositionDto, CancellationToken cancellationToken)
        {
            _context.Positions.Add(_mapper.Map<Positions>(PositionDto));
            var result = await _context.SaveChangesAsync(cancellationToken) > 0;
            return result;
        }

        public async Task<bool> DeletePosition(int id)
        {
            var position = await _context.Positions.FindAsync(id);
            if (position == null) return false;
            position.Deleted = true;
            position.DeleteDate = DateTime.Now;
            var result = await _context.SaveChangesAsync() > 0;
            return result;
        }

        public async Task<List<GetPositionDto>> GetAllPositions()
        {
            var positions = await _context.Positions.ToListAsync();

            var resultData = _mapper.Map<List<GetPositionDto>>(positions);
            return resultData;
        }

        public async Task<GetPositionDto> GetPositionById(int id)
        {
            var resultdata = await _context.Positions
                .ProjectTo<GetPositionDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(x => x.Id == id);
            return resultdata;
        }

        public async Task<bool> UpdatePosition(PostPositionDto PositionDto)
        {
            var position = await _context.Positions.FindAsync(PositionDto.Id);
            if (position == null) return false;
            _mapper.Map(PositionDto, position);
            var result = await _context.SaveChangesAsync() > 0;
            return result;
        }
    }
}
