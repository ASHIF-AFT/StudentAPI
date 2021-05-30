using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentAPI.Models;

namespace StudentAPI.Repositories
{
    public interface IReportCardRepository
    {
        Task<IEnumerable<ReportCard>> Get();

        Task<ReportCard> Get(int id);

        Task<ReportCard> Create(ReportCard reportCard);

        Task Update(ReportCard reportCard);

        Task Delete(int id);
    }
}
