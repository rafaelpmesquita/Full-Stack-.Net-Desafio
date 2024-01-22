using AutoMapper;
namespace TesteNetCore.Application.Mapper
{
    public class ObjectConverter : IObjectConverter
    {
        private readonly IMapper _mapper;

        public ObjectConverter()
        {
            _mapper = AutoMapperProfile.RegisterMappings().CreateMapper();
        }

        public T Map<T>(object source)
        {
            T model = _mapper.Map<T>(source);

            return model;
        }
    }
}
