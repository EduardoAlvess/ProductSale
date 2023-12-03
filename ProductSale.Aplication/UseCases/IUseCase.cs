namespace ProductSale.Aplication.UseCases
{
    public interface IUseCase<T, U> where U : UseCaseResult
    {
        Task<U> Execute(T input = default);
    }
}
