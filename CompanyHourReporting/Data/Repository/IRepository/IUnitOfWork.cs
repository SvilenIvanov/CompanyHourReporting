using CompanyHourReporting.Data.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyHourReporting.DataAccess.Repository.IRepository {
    public interface IUnitOfWork {

        ICompanyRepository Company { get; }
        IEmployeeRepository Employee { get; }
        void Save();
    }
}
