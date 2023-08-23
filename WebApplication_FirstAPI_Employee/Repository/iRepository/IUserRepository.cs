using WebApplication_FirstAPI_Employee.Models;
using WebApplication_FirstAPI_Employee.Models.ViewModels;

namespace WebApplication_FirstAPI_Employee.Repository.iRepository
{
    public interface IUserRepository
    {
        bool IsUniqueUser (UserVModel2 user);
        User Autenticate (string username,string password);
        User Register (UserVModel2 uservm2);
    }
}
