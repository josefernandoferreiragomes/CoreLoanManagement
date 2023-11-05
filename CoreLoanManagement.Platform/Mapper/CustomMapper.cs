using AutoMapper.Configuration.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.Platform.Mapper
{
    public class CustomMapper
    {
        private static List<MappingConfig> mappings = new List<MappingConfig>();
        private static AutoMapper.MapperConfiguration config = null;
        private static AutoMapper.IMapper mapper = null;

        public static void RegisterMapping<TSource, TDestination>()
            where TSource : class, new()
            where TDestination : class, new()
        {
            if(mappings == null)
            {
                throw new Exception("Mapping registration is closed");
            }

            if(mappings.Where(m=> m.Source == typeof(TSource) && m.Destination == typeof(TDestination)).Count()>0)
            {
                throw new Exception(string.Format("Duplicate mappings {0} => {1}",typeof(TSource).FullName, typeof(TDestination).FullName));
            }
            mappings.Add(new MappingConfig
            {
                Source=typeof(TSource),
                Destination=typeof(TDestination)
            });
        }

        internal static void CloseMappingRegistration()
        {
            if(mappings == null)
            {
                return;
            }
            config = new AutoMapper.MapperConfiguration(cfg =>
            {
                foreach (MappingConfig mc in mappings)
                {
                    cfg.CreateMap(mc.Source, mc.Destination);
                }
            });
            mapper=config.CreateMapper();
            mappings.Clear();
            mappings = null;
        }
        public static TDestination Map<TSource, TDestination>(TSource source)
            where TSource : class, new()
            where TDestination : class, new()
        {
            CloseMappingRegistration();
            return mapper.Map<TSource, TDestination>(source);  
        }

    }

}
