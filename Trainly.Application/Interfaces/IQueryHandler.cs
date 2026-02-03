namespace Trainly.Application.Interfaces
{
    public interface IQueryHandler<in TQuery, TResult>
    {
        Task<TResult> Handle(TQuery query);
    }
}