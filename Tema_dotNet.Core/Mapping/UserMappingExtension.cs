using Tema_dotNet.Core.Dto.Request;
using Tema_dotNet.Core.Dto.Response;
using Tema_dotNet.Database.Entities;

namespace Tema_dotNet.Core.Mapping
{
    public static class UserMappingExtensions
    {
        public static User MapToUser(this UserRequestDto userRequestDto)
        {
            return new User
            {
                Name = userRequestDto.Name,
                Email = userRequestDto.Email,
                Password = userRequestDto.Password,
                RoleId = userRequestDto.RoleId
            };
        }

        public static UserResponseDto MapToUserResponseDto(this User user)
        {
            return new UserResponseDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Role = user.Role.Name
            };
        }

        public static List<UserResponseDto> MapToUserResponseDtos(this List<User> users)
        {
            return users.Select(user => user.MapToUserResponseDto()).ToList();
        }
    }
}