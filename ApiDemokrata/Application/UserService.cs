using ApiDemokrata.Domain;
using ApiDemokrata.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace ApiDemokrata.Application
{
    public class UserService: IUserService
    {
        private readonly ApplicationDbContext _context;
        public UserService(ApplicationDbContext context) 
        {
            _context = context;
        }

        public async Task<User> CreateUserAsync(User request)
        {
            var newUser = new User
            {
                FirstName = request.FirstName,
                MiddleName = request.MiddleName,
                LastName = request.LastName,
                SecondLastName = request.SecondLastName,
                DateOfBirth = request.DateOfBirth,
                Salary = request.Salary,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();

            return newUser;
        }

        public async Task DeleteUserAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                throw new KeyNotFoundException("User not found");
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User?> GetUserByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<Domain.PagedResult<User>> SearchUsersAsync(string firstName, string lastName, int pageNumber, int pageSize)
        {
            var query = _context.Users.AsQueryable();

            // Filtrar por nombre y apellido si se proporcionan
            if (!string.IsNullOrWhiteSpace(firstName))
            {
                query = query.Where(u => u.FirstName.Contains(firstName));
            }

            if (!string.IsNullOrWhiteSpace(lastName))
            {
                query = query.Where(u => u.LastName.Contains(lastName));
            }

            // Obtener el total de registros coincidentes
            var totalRecords = await query.CountAsync();

            // Aplicar paginación
            var users = await query
                .OrderBy(u => u.FirstName) // Ordenar por nombre
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new Domain.PagedResult<User>
            {
                Items = users,
                TotalRecords = totalRecords,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }

        public async Task UpdateUserAsync(int id, User request)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                throw new KeyNotFoundException("User not found");
            }

            // Actualizamos los campos permitidos
            user.FirstName = request.FirstName;
            user.MiddleName = request.MiddleName;
            user.LastName = request.LastName;
            user.SecondLastName = request.SecondLastName;
            user.DateOfBirth = request.DateOfBirth;
            user.Salary = request.Salary;
            user.UpdatedAt = DateTime.Now;

            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }
    }
}
