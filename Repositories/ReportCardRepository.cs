using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudentAPI.Models;

namespace StudentAPI.Repositories
{
    public class ReportCardRepository : IReportCardRepository
    {
        private readonly SchoolContext _context;
        public ReportCardRepository(SchoolContext context)
        {
            _context = context;
        }

        public async Task<ReportCard> Create(ReportCard reportCard)
        {
            _context.ReportCard.Add(reportCard);
            await _context.SaveChangesAsync();
            return reportCard;
        }

        public async Task Delete(int id)
        {
            var reportCardToDelete = await _context.ReportCard.FindAsync(id);
            _context.ReportCard.Remove(reportCardToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ReportCard>> Get()
        {
            return await _context.ReportCard.ToListAsync();
        }

        public async Task<ReportCard> Get(int id)
        {
            return await _context.ReportCard.FindAsync(id);
        }

        public async Task Update(ReportCard reportCard)
        {
            _context.Entry(reportCard).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
