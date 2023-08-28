using BlazorServerApp.Model;
using BlazorServerApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorServerApp.Data
{
    public class RolesService
    {
        private readonly ApplicationContext _employee;
        public RolesService( ApplicationContext employee)
        {
            _employee = employee;
        }
        public async Task<List<Roles>> GetAllRolesAsync()
        {
            try
            {
                return await _employee.Roles.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetAllRoles: {ex.Message}");
                return null;
            }
        }
        public async Task<bool> AddNewRolesAsync(Roles roles)
        {
            try
            {
                await _employee.Roles.AddAsync(roles);
                await _employee.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in AddNewRolesAsync: {ex.Message}");
                return false;
            }
        }
        public async Task<Roles> GetRolesByIdAsync(int id)
        {
            try
            {
                Roles Roles = await _employee.Roles.FirstOrDefaultAsync(x => x.Id == id);
                return Roles;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetRolesByIdAsync: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> UpdateRolesDetailsAsync(Roles roles)
        {
            try
            {
                _employee.Roles.Update(roles);
                await _employee.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in UpdateRolesDetailsAsync: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> DeleteRoles(Roles roles)
        {
            try
            {
                _employee?.Roles.Remove(roles);
                await _employee.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in DeleteRoles: {ex.Message}");
                return false;
            }
        }
    }
}
