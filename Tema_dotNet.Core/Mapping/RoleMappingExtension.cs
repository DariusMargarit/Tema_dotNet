using Tema_dotNet.Core.Dto.Request;
using Tema_dotNet.Core.Dto.Response;
using Tema_dotNet.Database.Entities;

namespace Tema_dotNet.Core.Dto
{
    public static class RoleMappingExtensions
    {
        public static RoleResponseDto MapToRoleResponseDto(this Role role)
        {
            return new RoleResponseDto
            {
                Id = role.Id,
                Name = role.Name
            };
        }

        public static List<RoleResponseDto> MapToRoleResponseDtos(this List<Role> roles)
        {
            return roles.Select(role => role.MapToRoleResponseDto()).ToList();
        }

        public static Role MapToRole(this RoleRequestDto roleRequestDto)
        {
            return new Role
            {
                Name = roleRequestDto.Name
            };
        }
    }
}