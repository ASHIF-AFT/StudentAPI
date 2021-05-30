using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentAPI.Repositories;
using StudentAPI.Models;
namespace StudentAPI.Controllers
{
    [Route("api/[controller]/AddReportCard")]
    [ApiController]
    public class ReportCardController : ControllerBase
    {
        private readonly IReportCardRepository _reportCardRepository;
        public ReportCardController(IReportCardRepository reportCardRepository)
        {
            
        }
        [HttpGet]
        public async Task<IEnumerable<ReportCard>> GetReportCard()
        {
            return await _reportCardRepository.Get();
        }


    }
}
