namespace DataCollectorLibrary.Persistences.Repository.Employee
{
    public interface IEmployeeUnitOfWork : IUnitOfWork
    {
        IEmployeeRepository Employee { get; }
    }
}
