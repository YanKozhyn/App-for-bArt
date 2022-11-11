namespace TestApp.Interfaces
{
    public interface IUnitOfWork
    {
        IAccountRepository Accounts { get; }
        IIncedentRepository Incidents { get; }
        IContactRepository Contacts { get; }
        Task SaveAsync(CancellationToken token = default);
    }
}
