using CompanyHourReporting.DataAccess.Repository.IRepository;
using CompanyHourReporting.Models;

namespace CompanyHourReporting.Data.Repository.IRepository {
    public interface IEmployeeRepository : IRepository<Employee> {
        void Update(Employee obj);
    }
}
