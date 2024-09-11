﻿using Constracts;
using Entities.Models;

namespace Repository
{
    public class EmployeeRepository(RepositoryContext repositoryContext) : RepositoryBase<Employee>(repositoryContext), IEmployeeRepository
    {
        public IEnumerable<Employee> GetEmployees(Guid companyId, bool trackChanges)
            => FindByCondition(e => e.CompanyId.Equals(companyId), trackChanges)
                .OrderBy(e => e.Name)
                .ToList();
    }
}
