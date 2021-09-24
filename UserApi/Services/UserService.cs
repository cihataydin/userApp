using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserApi.Repositories;
using UserApi.Data;
using UserApi.UOW;
using UserApi.DTO.Response;
using UserApi.DTO.Request;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace UserApi.Services
{
    public class UserService : IUserService
    {
        private readonly IEFRepository<UserEntity> _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(IEFRepository<UserEntity> userRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IList<UserResponseDto>> GetUsersAsync()
        {
            var users = await _userRepository.Get().ToListAsync();

            return _mapper.Map<List<UserResponseDto>>(users);
        }

        public async Task<UserResponseDto> GetUserByIdAsync(int id)
        {
            var user = await _userRepository.Get(i => i.Id == id).FirstOrDefaultAsync();

            return _mapper.Map<UserResponseDto>(user);
        }

        public async Task<UserResponseDto> CreateUserAsync(CreateUserRequestDto createUserRequestDto)
        {
            UserEntity user = _mapper.Map<UserEntity>(createUserRequestDto);

            user = await _userRepository.CreateAsync(user);

            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<UserResponseDto>(user);
        }

        public async Task<UserResponseDto> UpdateUserAsync(UpdateUserRequestDto updateUserRequestDto)
        {
            var user = _mapper.Map<UserEntity>(updateUserRequestDto);

            try
            {
                user = _userRepository.Update(user);
                await _unitOfWork.SaveChangesAsync();
            }
            catch (System.Exception)
            {
                return null;
            }                         

            return _mapper.Map<UserResponseDto>(user); 
        }

        public async Task<bool?> DeleteUserAsync(int id)
        {
            var user = await _userRepository.Get(i => i.Id == id).FirstOrDefaultAsync();

            if(user is null)
            {
                return null;
            }
           
            _userRepository.Delete(user);

            await _unitOfWork.SaveChangesAsync();

            return true;
        }
    }
}