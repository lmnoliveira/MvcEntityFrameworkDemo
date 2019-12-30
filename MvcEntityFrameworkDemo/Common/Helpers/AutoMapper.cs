using AutoMapper;
using AutoMapper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Common.Helpers
{
    public class AutoMapper<TSource, TDestination>
    {
        private IMapper Mapper { get; set; }

        public AutoMapper()
        {
            Initialize(null);
        }

        public AutoMapper(List<KeyValuePair<string, object>> nameValueParameters)
        {
            Initialize(nameValueParameters);
        }

        private void Initialize(List<KeyValuePair<string, object>> nameValueParameters)
        {
            MapperConfigurationExpression configExpression = new MapperConfigurationExpression();
            IMappingExpression mappingExpression = configExpression.CreateMap(typeof(TSource), typeof(TDestination));
            nameValueParameters?.ForEach(nvp => mappingExpression.ForMember(nvp.Key, mo => mo.MapFrom(mf => nvp.Value)));

            var config = new MapperConfiguration(configExpression);
            Mapper = config.CreateMapper();
        }

        public TDestination Run(TSource source)
        {
            return Mapper.Map<TDestination>(source);
        }

        public IEnumerable<TDestination> Run(IEnumerable<TSource> source)
        {
            return Mapper.Map<IEnumerable<TDestination>>(source);
        }
    }
}