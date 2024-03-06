using EvalBackendAz.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvalBackendAz.Repository.Contracts
{
    public interface IEventsRepository
    {

        Task<Events> AddEventsAsync(Events events);
        Task<IEnumerable<Events>> GetAllEventsAsync();
    }
}
