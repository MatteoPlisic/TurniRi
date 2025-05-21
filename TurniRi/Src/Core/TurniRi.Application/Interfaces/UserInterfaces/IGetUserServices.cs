using System.Threading.Tasks;
using TurniRi.Application.DTOs.Account.Requests;
using TurniRi.Application.DTOs.Account.Responses;
using TurniRi.Application.Wrappers;

namespace TurniRi.Application.Interfaces.UserInterfaces
{
    public interface IGetUserServices
    {
        Task<PagedResponse<UserDto>> GetPagedUsers(GetAllUsersRequest model);
    }
}
