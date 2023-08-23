using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApplication_FirstAPI_Employee.Data;
using WebApplication_FirstAPI_Employee.Models;
using WebApplication_FirstAPI_Employee.Models.ViewModels;
using WebApplication_FirstAPI_Employee.Repository.iRepository;

namespace WebApplication_FirstAPI_Employee.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppSettings _appSettings;
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context,IOptions<AppSettings> appSettings)
        {
            _context = context;
            _appSettings = appSettings.Value;
        }
        public User Autenticate(string username, string password)
        {
            var userInDb=_context.Users.FirstOrDefault(x=>x.Username==username && x.Password==password);
            if (userInDb == null) return null;
            //JWT 

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescritor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, userInDb.Id.ToString()),
                    new Claim(ClaimTypes.Role, userInDb.Role)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials=new SigningCredentials(new SymmetricSecurityKey(key),SecurityAlgorithms.HmacSha256Signature)
            };
            var token=tokenHandler.CreateToken(tokenDescritor);
            userInDb.Token = tokenHandler.WriteToken(token);

            //****
            userInDb.Password = "";
            return userInDb;
        }

        //public bool IsUniqueUser(List<UserVModel2> user)
        //{
        //    var userInDb = _context.Users.FirstOrDefault(x => x.Username = user & x.Role = user);
        //    if (userInDb == null) return true; return false;
        //}

        public bool IsUniqueUser(UserVModel2 user)
        {
            var userInDb = _context.Users.FirstOrDefault(x => x.Username ==user.UserName && x.Role==user.Role);
            if (userInDb == null) return true; return false;
        }

        public User Register(UserVModel2 uservm2)
        {
            User user=new User()
            {
                Username= uservm2.UserName,
                Password = uservm2.Password,
                ConfirmPassword=uservm2.ConfirmPassword,
                Role=uservm2.Role
            };
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }
    }
}
