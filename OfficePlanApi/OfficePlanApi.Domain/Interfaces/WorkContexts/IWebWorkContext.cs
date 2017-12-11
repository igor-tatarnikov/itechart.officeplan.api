namespace OfficePlanApi.Domain.Interfaces.WorkContexts
{
    public interface IWebWorkContext : IBaseWorkContext
    {
        bool IsAuthenticated { get; }

        string UserName { get; }
    }
}
