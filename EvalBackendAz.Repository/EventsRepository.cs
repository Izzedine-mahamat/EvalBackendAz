﻿using EvalBackendAz.DAL;
using EvalBackendAz.DAL.Migrations;
using EvalBackendAz.Entities;
using EvalBackendAz.Repository.Contracts;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<Events>> GetAllEventsAsync()
        {
            return await _DbContext.events.ToListAsync();
        }

        public async Task<Events> UpdateEventsAsync(Events events)
        {
            _DbContext.events.Update(events);
            await _DbContext.SaveChangesAsync();
            return events;
        }

        public async Task DeleteEventsAsync(Guid id)
        {
            var eventToDelete = await _DbContext.events.FirstOrDefaultAsync(e => e.Id == id);
            if (eventToDelete == null)
            {
                throw new KeyNotFoundException("Event not fund.");
            }

            _DbContext.events.Remove(eventToDelete);
            await _DbContext.SaveChangesAsync();
        }




    }
}
