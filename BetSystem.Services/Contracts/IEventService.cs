using BetSystem.Data.Models;
using BetSystem.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetSystem.Services.Contracts
{
    public interface IEventService : IDataService<Event>
    {
        IList<EventDTO> GetAllEvents();

        void AddEvent(EventDTO betEvent);

        void UpdateEvent(EventDTO betEventDTO);

        void RemoveEvent(EventDTO betEventDTO);
    }
}
