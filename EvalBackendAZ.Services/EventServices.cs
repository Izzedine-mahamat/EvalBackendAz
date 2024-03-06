using EvalBackendAz.Entities;
using EvalBackendAz.Repository.Contracts;
using EvalBackendAz.Services.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvalBackendAz.Services
{
    public class EventServices : IEventServices
    {
        private readonly IEventsRepository _eventsRepository;

        public EventServices(IEventsRepository eventsRepository)
        {
            _eventsRepository = eventsRepository;
        }

        public async Task AddEventsAsync(Events events)
        {
            await _eventsRepository.AddEventsAsync(events);
        }

        public async Task<IEnumerable<Events>> GetAllEventsAsync()
        {
            return await _eventsRepository.GetAllEventsAsync();
        }


    }
}
