using CompanyHourReporting.DataAccess.Repository.IRepository;
using CompanyHourReporting.Models;

namespace CompanyHourReporting.Data.Repository.IRepository {
    public interface ICompanyRepository : IRepository<Company> {
        void Update(Company obj);
    }
}

