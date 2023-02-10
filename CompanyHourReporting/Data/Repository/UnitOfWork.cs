using CompanyHourReporting.Data;
using CompanyHourReporting.Data.Repository;
using CompanyHourReporting.Data.Repository.IRepository;
using CompanyHourReporting.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyHourReporting.DataAccess.Repository {
    public class UnitOfWork : IUnitOfWork {
        private readonly AppDbContext _db;
        public ICompanyRepository Company { get; set; }
        public IEmployeeRepository Employee { get; set; }

        public UnitOfWork(AppDbContext db) {
            _db = db;
            Company = new CompanyRepository(_db);
            Employee = new EmployeeRepository(_db);

        }



        public void Save() {
            _db.SaveChanges();
        }
    }
}
