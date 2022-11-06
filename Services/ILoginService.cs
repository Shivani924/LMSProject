using LMSProject.Models;

namespace LMSProject.Services
{
    public interface ILoginService
    {
        /*  bool Login(LoginDTO user);
          bool Register(Login user);*/

        /* bool Login(LoginDTO user);
         bool Register(UserPassDTO user);*/
        /*This upper code is junk vaibhav*/


        /*LoginDTO Login(LoginDTO user);*/
        Login Login(LoginDTO user);
        LoginDTO Register(UserPassDTO user);
    }
}
