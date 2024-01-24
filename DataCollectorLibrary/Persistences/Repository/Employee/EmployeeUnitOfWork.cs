namespace DataCollectorLibrary.Persistences.Repository.Employee
{
    public class EmployeeUnitOfWork : UnitOfWork, IEmployeeUnitOfWork
    {
        public EmployeeUnitOfWork(DataCollectorLibrary.Persistences.Context.EmployeeContext context) : base(context)
        {
            Employee = new EmployeeRepository(context);
        }

        public IEmployeeRepository Employee { get; private set; }
    }
}
