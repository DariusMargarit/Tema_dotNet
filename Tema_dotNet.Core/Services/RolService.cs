using Tema_dotNet.Core.Dto.Request;
using Tema_dotNet.Core.Dto.Response;
using Tema_dotNet.Core.Dto;
using Tema_dotNet.Core.Mapping;
using Tema_dotNet.Database.Repositories;

namespace Tema_dotNet.Core.Services
{
    public class RolService 
    {
        private readonly RolRepository _rolRepository;

        public RolService(RolRepository rolRepository)
        {
            _rolRepository = rolRepository;
        }

        public List<RolResponseDto> GetAll()
        {
            var roles = _rolRepository.GetAll();
            var rolesDtos = roles.MapToRoleResponseDtos();
            return rolesDtos;
        }

        public RolResponseDto Get(int id)
        {
            try
            {
                var role = _rolRepository.Get(id);
                var roleDto = role.MapToRoleResponseDto();
                return roleDto;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Create(RolRequestDto rolDto)
        {
            try
            {
                var role = rolDto.MapToRole();
                _rolRepository.Create(role);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Update(int id, RolRequestDto updatedRolDto)
        {
            try
            {
                var updatedRole = updatedRolDto.MapToRole();
                _rolRepository.Update(id, updatedRole);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Delete(int id)
        {
            try
            {
                _rolRepository.Delete(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
