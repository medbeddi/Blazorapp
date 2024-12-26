using Models;

public interface IEmployeeService
{
    Task<IEnumerable<Employee>> GetEmployees();

    Task<Employee> GetEmployee(int id);
    Task<HttpResponseMessage> UpdateEmployee(Employee updatedEmployee);
}