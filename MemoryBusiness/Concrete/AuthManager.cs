using AutoMapper;
using Memory.Business.Abstract;
using Memory.DataAccess.Concrete.EntityFrameWork.Mappings;
using Memory.Entities.Concrete;
using Memory.Entities.Concrete.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory.Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly UserManager<AppIdentityUser> _userManager;
        private readonly RoleManager<AppIdentityRole> _roleManager;
        private readonly SignInManager<AppIdentityUser> _signInManager;
        private readonly IMapper _mapper;

        public AuthManager(UserManager<AppIdentityUser> userManager, RoleManager<AppIdentityRole> roleManager, SignInManager<AppIdentityUser> signInManager, IMapper mapper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;  
            _mapper = mapper;
        }
        public async Task<AppIdentityUser> GetUser(string email)
        {
            AppIdentityUser user = await _userManager.Users.FirstOrDefaultAsync(x => x.Email == email);
            return user;
        }
        public async Task<AppIdentityUser> GetUserByUserName(string userName)
        {
            return await  _userManager.Users.FirstOrDefaultAsync(x=>x.UserName==userName);
        }

        public async Task<SignInResult> Login(LoginDto loginDto)
        {
            AppIdentityUser user = await _userManager.Users.FirstOrDefaultAsync(x => x.Email == loginDto.Email);

           return user == null ? new SignInResult() : await _signInManager.PasswordSignInAsync(user, loginDto.Password, false, false);
        }

        public async Task Logout()
        {
           await _signInManager.SignOutAsync();
        }

        public async Task<IdentityResult> AddRoleToUser(AppIdentityUser user, string role)
        {
            AppIdentityRole rol = await _roleManager.Roles.FirstOrDefaultAsync(x => x.Name == role);
            if (rol == null)
            {
                await _roleManager.CreateAsync(new AppIdentityRole() { Name = role,NormalizedName = role.ToUpper()} );
            }
            return await _userManager.AddToRoleAsync(user, role);
        }

        public async Task<IdentityResult> Register(RegisterDto registerDto)
        {
            AppIdentityUser user = _mapper.Map<AppIdentityUser>(registerDto); 
           
            IdentityResult result = await _userManager.CreateAsync(user, registerDto.Password);
            if (result.Succeeded)
            {
                AddRoleToUser(user,"User");
            }
            return result;



        }
    }
}
