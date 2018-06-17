using AutoMapper;

namespace BetSystem.Common.Mappings
{
    public interface ICustomMapping
    {
        void CreateMappings(IMapperConfigurationExpression configuration);
    }
}
