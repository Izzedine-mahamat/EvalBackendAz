using EvalBackendAz.DAL;
using EvalBackendAz.DAL.Migrations;
using EvalBackendAz.Entities;
using EvalBackendAz.Repository.Contracts;
using Microsoft.EntityFrameworkCore.Migrations.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Events = EvalBackendAz.Entities.Events;

namespace EvalBackendAz.Repository
{
    public class  EventsRepository : IEventsRepository
    {

        private EvalBackendAzDbContext _DbContext;

        public EventsRepository(EvalBackendAzDbContext DbContext)
        {
            _DbContext = DbContext;
        }

        public async Task<Events> AddEventsAsync(Events events)
        {
            _DbContext.events.Add(events);
            await _DbContext.SaveChangesAsync();

            return events;
        }

    
    }
}
