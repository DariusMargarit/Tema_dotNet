using Tema_dotNet.Core.Dto.Request;
using Tema_dotNet.Core.Dto.Response;

namespace Tema_dotNet.Core.Services
{
    public interface IUserService
    {
        void Register(UserRequestDto userRequestDto);

        string Login(LoginRequestDto loginDto);

        List<UserResponseDto> GetAll();

        UserResponseDto Get(int id);

        void Update(int id, UserRequestDto updatedUserDto);

        void Delete(int id);
    }
}