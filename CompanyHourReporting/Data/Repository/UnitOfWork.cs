﻿using CompanyHourReporting.Data;
using CompanyHourReporting.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyHourReporting.DataAccess.Repository {
    public class UnitOfWork : IUnitOfWork {
        private readonly AppDbContext _db;

        public UnitOfWork(AppDbContext db) {
            _db = db;
        }
        public void Save() {
            _db.SaveChanges();
        }
    }
}