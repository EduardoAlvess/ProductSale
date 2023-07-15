namespace ProductSale.Infra.Cache
{
    public interface ICacheProvider
    {
        T Get<T>(string key);
        void DeleteCache(string key);
        void Set<T>(string key, T value);
    }
}