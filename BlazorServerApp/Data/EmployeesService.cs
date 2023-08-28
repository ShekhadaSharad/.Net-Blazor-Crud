using BlazorServerApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorServerApp.Data
{
    public class EmployeesService
    {
        private readonly ApplicationContext _employee;
        public EmployeesService(ApplicationContext context)
        {
            _employee = context;
        }

        public async Task<List<Employee>> GetAllEmployees()
        {
            try
            {
                return await _employee.Employees.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetAllEmployees: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> AddNewEmployeesAsync(Employee employee)
        {
            try
            {
                await _employee.Employees.AddAsync(employee);
                await _employee.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in AddNewEmployeesAsync: {ex.Message}");
                return false;
            }
        }

        public async Task<Employee> GetEmployeesByIdAsync(int id)
        {
            try
            {
                Employee employee = await _employee.Employees.FirstOrDefaultAsync(x => x.Id == id);
                return employee;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetEmployeesByIdAsync: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> UpdateEmployeesDetailsAsync(Employee employee)
        {
            try
            {
                _employee.Employees.Update(employee);
                await _employee.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in UpdateEmployeesDetailsAsync: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> DeleteEmployee(Employee employee)
        {
            try
            {
                _employee?.Employees.Remove(employee);
                await _employee.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in DeleteEmployee: {ex.Message}");
                return false;
            }
        }

    }
}
