using LMSProject.Models;

namespace LMSProject.Services
{
    public interface ITokenService
    {
        public string CreateToken(LoginDTO user);
    }
}
