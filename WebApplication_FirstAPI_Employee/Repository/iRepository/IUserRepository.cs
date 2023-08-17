using WebApplication_FirstAPI_Employee.Models;

namespace WebApplication_FirstAPI_Employee.Repository.iRepository
{
    public interface IUserRepository
    {
        bool IsUniqueUser (string username);
        User Autenticate (string username,string password);
        User Register (string username,string password,string confirmPassword,string role);
    }
}
