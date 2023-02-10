using CompanyHourReporting.Data.Repository.IRepository;
using CompanyHourReporting.DataAccess.Repository;
using CompanyHourReporting.Models;

namespace CompanyHourReporting.Data.Repository {
    public class CompanyRepository : Repository<Company>, ICompanyRepository {

        private readonly AppDbContext _db;

        public CompanyRepository(AppDbContext db) : base(db) {
            _db = db;
        }

        public void Update(Company obj) {
            _db.Companies.Update(obj);
        }
    }
}
