﻿using Models;

namespace EmployeeManagment.web.Services
{
    public interface IDepartmentService
    {
        Task<IEnumerable<Department>> GetDepartments();

        Task<Department> GetDepartment(int id);

    }
}
