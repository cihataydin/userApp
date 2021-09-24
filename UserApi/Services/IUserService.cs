using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserApi.DTO.Response;
using UserApi.DTO.Request;

namespace UserApi.Services
{
    public interface IUserService
    {
        Task<IList<UserResponseDto>> GetUsersAsync();
        Task<UserResponseDto> GetUserByIdAsync(int id);
        Task<UserResponseDto> CreateUserAsync(CreateUserRequestDto createUserRequestDto);
        Task<UserResponseDto> UpdateUserAsync(UpdateUserRequestDto updateUserRequestDto);
        Task<bool?> DeleteUserAsync(int id);   
    }
}