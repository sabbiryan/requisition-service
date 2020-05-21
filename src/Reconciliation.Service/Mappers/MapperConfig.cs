using AutoMapper;

namespace ReconciliationApp.Service.Mappers
{
    public class MapperConfig
    {

        public static void Initialize()
        {
            GetMapper();
        }

        public static AutoMapper.Mapper CreateMaps()
        {
            return new AutoMapper.Mapper(MapperConfig.GetMapper());
        }



        public static MapperConfiguration GetMapper()
        {
            var configurationProvider = new MapperConfiguration(MapperProfiler.Config);

            return configurationProvider;
        }

    }
}