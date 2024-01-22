namespace TesteNetCore.Application.Mapper
{
    public interface IObjectConverter
    {
        T Map<T>(object source);
    }
}
