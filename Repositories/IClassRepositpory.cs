using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentAPI.Models;

namespace StudentAPI.Repositories
{
    public interface IClassRepository
    {
        Task<IEnumerable<Class>> Get();

        Task<Class> Get(int id);

        Task<Class> Create(Class classs);

        Task Update(Class classs);

        Task Delete(int id);

    }
}
