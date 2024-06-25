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
                Nume = userRequestDto.Nume,
                Email = userRequestDto.Email,
                Parola = userRequestDto.Parola,
                RolId = userRequestDto.RolId
            };
        }

        public static UserResponseDto MapToUserResponseDto(this User user)
        {
            return new UserResponseDto
            {
                Id = user.Id,
                Nume = user.Nume,
                Email = user.Email,
                Rol = user.Rol.Nume
            };
        }

        public static List<UserResponseDto> MapToUserResponseDtos(this List<User> users)
        {
            return users.Select(user => user.MapToUserResponseDto()).ToList();
        }
    }
}