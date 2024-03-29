﻿using EvalBackendAz.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvalBackendAz.Services.Contracts
{
    public interface IEventServices
    {

        public Task  AddEventsAsync(Events events);
        Task<IEnumerable<Events>> GetAllEventsAsync();
        Task<Events> UpdateEventsAsync(Events events);
        Task DeleteEventsAsync(Guid id);


    }
}
