using ApiDemokrata.Domain;
using System.Linq.Dynamic.Core;

namespace ApiDemokrata.Application
{
    public interface IUserService
    {
        Task<User> CreateUserAsync(User request);
        Task<User?> GetUserByIdAsync(int id);
        Task UpdateUserAsync(int id, User request);
        Task DeleteUserAsync(int id);
        Task<Domain.PagedResult<User>> SearchUsersAsync(string firstName, string lastName, int pageNumber, int pageSize);

    }
}
