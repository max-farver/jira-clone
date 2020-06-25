using System;
using System.Net;
using System.Threading.Tasks;
using Application.Auth.Authentication.DTOs;
using Application.Errors;
using Application.Interfaces;
using Domain;
using Domain.Users;
using Microsoft.AspNetCore.Identity;

namespace Application.Projects
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IJwtGenerator _jwtGenerator;
        private readonly IUnitOfWork _unitOfWork;

        public AuthService(IUnitOfWork unitOfWork, UserManager<User> userManager, SignInManager<User> signInManager, IJwtGenerator jwtGenerator)
        {
            _unitOfWork = unitOfWork;
            _jwtGenerator = jwtGenerator;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<AppUser> Login(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null)
                throw new RestException(HttpStatusCode.Unauthorized);

            var result = await _signInManager
                .CheckPasswordSignInAsync(user, password, false);

            if (result.Succeeded)
            {
                return new AppUser
                {
                    DisplayName = user.DisplayName,
                    Token = _jwtGenerator.CreateToken(user),
                    Username = user.UserName,
                };
            }

            throw new RestException(HttpStatusCode.Unauthorized);
        }

        public async Task<AppUser> Register(string username, string displayName, string email, string password)
        {

            if (await _unitOfWork.Users.Find(u => u.Email == email) != null)
                throw new RestException(HttpStatusCode.BadRequest, new { Email = "Email already exists" });

            if (await _unitOfWork.Users.Find(u => u.UserName == username) != null)
                throw new RestException(HttpStatusCode.BadRequest, new { Username = "Username already exists" });

            var user = new User
            {
                DisplayName = displayName,
                Email = email,
                UserName = username
            };

            var result = await _userManager.CreateAsync(user, password);

            if (result.Succeeded)
            {
                return new AppUser
                {
                    DisplayName = user.DisplayName,
                    Token = _jwtGenerator.CreateToken(user),
                    Username = user.UserName
                };
            }

            throw new Exception("Problem creating user");
        }
    }
}