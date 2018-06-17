using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using BetSystem.Common.Constants;
using AutoMapper.QueryableExtensions;

namespace BetSystem.Data.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<BetSystem.Data.MsSqlDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = false;
            this.AutomaticMigrationDataLossAllowed = false;
        }

        public object JsonConvert { get; private set; }

        protected override void Seed(BetSystem.Data.MsSqlDbContext context)
        {
            this.SeedSampleData(context);
        }
        
        private void SeedSampleData(MsSqlDbContext context)
        {
            //if (context.Events.Any())
            //{
            //    return;
            //}

            //var events = Newtonsoft.Json.JsonConvert.DeserializeObject<ICollection<Data.JsonModels.Event>>(System.IO.File.ReadAllText(Resource.DbSeedPath));
            //var dbEvents = events.AsQueryable().ProjectTo<Models.Event>().ToList();
            
            //foreach (var betEvent in dbEvents)
            //{
            //    context.Events.Add(betEvent);
            //}

            context.Events.AddOrUpdate(new Models.Event { EventName = "Juventus vs Milan", OddsForFirstTeam = 1, OddsForDraw = 3, OddsForSecondTeam = 2, EventStartDate = new DateTime(2013, 6, 1, 12, 32, 30) },
                new Models.Event { EventName = "RealM vs Barselona", OddsForFirstTeam = 1, OddsForDraw = 3, OddsForSecondTeam = 2, EventStartDate = new DateTime(2013, 6, 1, 12, 32, 30) },
                new Models.Event { EventName = "Lazio vs Inter", OddsForFirstTeam = 1, OddsForDraw = 3, OddsForSecondTeam = 2, EventStartDate = new DateTime(2013, 6, 1, 12, 32, 30) },
                new Models.Event { EventName = "Liverpool vs Arsenal", OddsForFirstTeam = 1, OddsForDraw = 3, OddsForSecondTeam = 2, EventStartDate = new DateTime(2013, 6, 1, 12, 32, 30) },
                new Models.Event { EventName = "BorusiaD vs Shalke", OddsForFirstTeam = 1, OddsForDraw = 3, OddsForSecondTeam = 2, EventStartDate = new DateTime(2013, 6, 1, 12, 32, 30) });
            context.SaveChanges();
        }
    }
}
