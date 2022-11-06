using LMSProject.Models;

namespace LMSProject.Services
{
    public interface ILoginService
    {
        /*  bool Login(LoginDTO user);
          bool Register(Login user);*/

        /* bool Login(LoginDTO user);
         bool Register(UserPassDTO user);*/
        LoginDTO Login(LoginDTO user);
        LoginDTO Register(UserPassDTO user);
    }
}
