using Tema_dotNet.Core.Dto.Request;
using Tema_dotNet.Core.Dto.Response;
using Tema_dotNet.Database.Entities;

namespace Tema_dotNet.Core.Mapping

{
    public static class RolMappingExtensions
    {
        public static RolResponseDto MapToRoleResponseDto(this Rol rol)
        {
            return new RolResponseDto
            {
                Id = rol.Id,
                Nume = rol.Nume
            };
        }

        public static List<RolResponseDto> MapToRoleResponseDtos(this List<Rol> roles)
        {
            return roles.Select(role => role.MapToRoleResponseDto()).ToList();
        }

        public static Rol MapToRole(this RolRequestDto rolRequestDto)
        {
            return new Rol
            {
                Nume = rolRequestDto.Nume
            };
        }
    }
}