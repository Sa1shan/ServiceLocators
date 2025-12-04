namespace _Source.interfaces
{
    public interface IService
    {
        T GetService<T>() where T : class;
    }
}