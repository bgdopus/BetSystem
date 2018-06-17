using BetSystem.Data.Contracts;
using BetSystem.Data.Models;
using BetSystem.Services.Abstract;
using BetSystem.Services.Contracts;
using BetSystem.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetSystem.Services
{
    public class EventService : IEventService
    {
        private IGenericRepository<Event> eventRepository;

        public EventService(IGenericRepository<Event> eventRepository)
        {
            this.eventRepository = eventRepository;
        }

        public void AddEvent(EventDTO betEventDTO)
        {
            var betEvent = new Event
            {
                EventName = betEventDTO.EventName,
                OddsForFirstTeam = betEventDTO.OddsForFirstTeam,
                OddsForDraw = betEventDTO.OddsForDraw,
                OddsForSecondTeam = betEventDTO.OddsForSecondTeam,
                EventStartDate = betEventDTO.EventStartDate
            };

            try
            {
                this.eventRepository.Add(betEvent);
            }
            catch (Exception ex)
            {

                throw ;
            }

        }

        public IList<EventDTO> GetAllEvents()
        {
            var events = this.eventRepository.All.ToList(); ;
            IList<EventDTO> result = new List<EventDTO>();

            foreach (var betEvent in events)
            {
                result.Add(new EventDTO()
                {
                    Id = betEvent.Id,
                    EventName = betEvent.EventName,
                    OddsForFirstTeam = betEvent.OddsForFirstTeam,
                    OddsForDraw = betEvent.OddsForDraw,
                    OddsForSecondTeam = betEvent.OddsForSecondTeam,
                    EventStartDate = betEvent.EventStartDate
                });
            }

            return result;
        }

        public void UpdateEvent(EventDTO betEventDTO)
        {
            var betEvent = new Event
            {
                Id = betEventDTO.Id,
                EventName = betEventDTO.EventName,
                OddsForFirstTeam = betEventDTO.OddsForFirstTeam,
                OddsForDraw = betEventDTO.OddsForDraw,
                OddsForSecondTeam = betEventDTO.OddsForSecondTeam,
                EventStartDate = betEventDTO.EventStartDate,
                IsDeleted = betEventDTO.IsDeleted
            };

            try
            {
                this.eventRepository.Update(betEvent);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public void RemoveEvent(EventDTO betEventDTO)
        {
            this.UpdateEntity(betEventDTO, true);
        }

        private void UpdateEntity(EventDTO betEventDTO,bool isDeleted)
        {
            var betEvent = new Event
            {
                Id = betEventDTO.Id,
                EventName = betEventDTO.EventName,
                OddsForFirstTeam = betEventDTO.OddsForFirstTeam,
                OddsForDraw = betEventDTO.OddsForDraw,
                OddsForSecondTeam = betEventDTO.OddsForSecondTeam,
                EventStartDate = betEventDTO.EventStartDate,
                IsDeleted = isDeleted
            };

            try
            {
                this.eventRepository.Update(betEvent);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        
    }
}
