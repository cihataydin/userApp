using AutoMapper;
using UserApi.Data;
using UserApi.DTO.Request;
using UserApi.DTO.Response;

namespace UserApi.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
        CreateMap<UserEntity, UserRequestDto>().ReverseMap();
        CreateMap<UserEntity, CreateUserRequestDto>().ReverseMap();
        CreateMap<UserEntity, UpdateUserRequestDto>().ReverseMap();
        CreateMap<UserEntity, UserResponseDto>().ReverseMap();
        }
    }
}