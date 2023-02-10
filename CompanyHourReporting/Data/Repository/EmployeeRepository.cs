using CompanyHourReporting.Data.Repository.IRepository;
using CompanyHourReporting.DataAccess.Repository;
using CompanyHourReporting.Models;

namespace CompanyHourReporting.Data.Repository {
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository {

        private readonly AppDbContext _db;
        public EmployeeRepository(AppDbContext db) : base(db) {
            _db = db;
        }

        public void Update(Employee obj) {
            _db.Employees.Update(obj);
        }
    }
}
