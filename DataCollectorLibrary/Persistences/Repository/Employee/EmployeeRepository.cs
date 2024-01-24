using DataCollectorLibrary.Persistences.Context;

namespace DataCollectorLibrary.Persistences.Repository.Employee
{
    public class EmployeeRepository : Repository<DataCollectorLibrary.Persistences.Entity.Employee>, IEmployeeRepository
    {
        public EmployeeRepository(EmployeeContext context) : base(context) { }
        public EmployeeContext EmployeeContext
        {
            get { return Context as EmployeeContext; }
        }
    }
}
