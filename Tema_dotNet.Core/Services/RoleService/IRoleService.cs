using Tema_dotNet.Core.Dto.Request;
using Tema_dotNet.Core.Dto.Response;

namespace Tema_dotNet.Core.Services
{
    public interface IRoleService
    {
        List<RoleResponseDto> GetAll();

        RoleResponseDto Get(int id);

        void Create(RoleRequestDto roleDto);

        void Update(int id, RoleRequestDto updatedRoleDto);

        void Delete(int id);
    }
}