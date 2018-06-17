using AutoMapper;
using BetSystem.Common.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace BetSystem.Web.App_Start
{
    public class AutoMapperConfig
    {
        public void RegisterMappings()
        {
            var currentAssembly = Assembly.GetExecutingAssembly();

            this.Execute(new Assembly[] { currentAssembly });
        }

        public static IMapperConfigurationExpression Configuration { get; private set; }

        public IMapperConfigurationExpression Execute(Assembly[] assemblies)
        {
            Mapper.Initialize((config) =>
            {
                var types = assemblies.SelectMany(x => x.GetTypes()).ToList();
                LoadStandardMappings(types, config);
                LoadCustomMappings(types, config);

                Configuration = config;
            });

            return Configuration;
        }

        private static void LoadStandardMappings(IEnumerable<Type> types, IMapperConfigurationExpression config)
        {
            var maps = (from t in types
                        from i in t.GetInterfaces()
                        where i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapFrom<>) &&
                              !t.IsAbstract &&
                              !t.IsInterface
                        select new
                        {
                            Source = i.GetGenericArguments()[0],
                            Destination = t
                        }).ToArray();


            foreach (var map in maps)
            {
                config.CreateMap(map.Source, map.Destination);
                config.CreateMap(map.Destination, map.Source);
            }
        }

        private static void LoadCustomMappings(IEnumerable<Type> types, IMapperConfigurationExpression config)
        {
            var maps = (from t in types
                        from i in t.GetInterfaces()
                        where typeof(ICustomMapping).IsAssignableFrom(t) &&
                              !t.IsAbstract &&
                              !t.IsInterface
                        select (ICustomMapping)Activator.CreateInstance(t)).ToArray();

            foreach (var map in maps)
            {
                map.CreateMappings(config);
            }
        }
    }
}