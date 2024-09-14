using Faradid.Tracking.Domain.Entities.ApiResult;
using Faradid.Tracking.Identity.Constanse;
using Faradid.Tracking.Interfaces.Identity;
using Faradid.Tracking.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Faradid.Tracking.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly JwtSettings _jwtSettings;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AuthService(UserManager<ApplicationUser> userManager,
            IOptions<JwtSettings> jwtSettings,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _jwtSettings = jwtSettings.Value;
            _signInManager = signInManager;
        }


        #region login
        public async Task<ApiResult> Login(AuthRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            ApiResult apiResult = new ApiResult();
            apiResult.ErrorMessages=new List<string>();
            if (user == null)
            {
                apiResult.IsSuccess = false;
                apiResult.Result = null;
                apiResult.StatusCode = System.Net.HttpStatusCode.NotFound;
                apiResult.ErrorMessages.Add("نام کاربری یافت نشد");
                return apiResult;
            }

            var result = await _signInManager.PasswordSignInAsync(user.UserName, request.Password, false, lockoutOnFailure: false);

            if (!result.Succeeded)
            {
                apiResult.IsSuccess = false;
                apiResult.Result = null;
                apiResult.StatusCode = System.Net.HttpStatusCode.NotFound;
                apiResult.ErrorMessages.Add("نام کاربری یا رمز عبور اشتباه است");
                return apiResult;
            }

            JwtSecurityToken jwtSecurityToken = await GenerateToken(user);

            AuthResponse response = new AuthResponse()
            {
                Id = user.Id,
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                Email = user.Email,
                UserName = user.UserName,
            };

            apiResult.IsSuccess = true;
            apiResult.Result = response;
            apiResult.StatusCode = System.Net.HttpStatusCode.OK;


            return apiResult;
        }

        private async Task<JwtSecurityToken> GenerateToken(ApplicationUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);

            var roleClaims = new List<Claim>();

            for (int i = 0; i < roles.Count; i++)
            {
                roleClaims.Add(new Claim(ClaimTypes.Role, roles[i]));
            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email,user.Email),
                new Claim(CustomClaimTypes.Uid,user.Id.ToString())
            }
            .Union(userClaims)
            .Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes),
                signingCredentials: signingCredentials);

            return jwtSecurityToken;
        }
        #endregion


        #region register
        public async Task<ApiResult> Register(RegisterationRequest request)
        {
            ApiResult apiResult = new ApiResult();
            apiResult.ErrorMessages = new List<string>();
            var existingUser = await _userManager.FindByNameAsync(request.UserName);
            if (existingUser != null)
            {

                apiResult.IsSuccess = false;
                apiResult.Result = null;
                apiResult.StatusCode = System.Net.HttpStatusCode.NotFound;
                apiResult.ErrorMessages.Add("این نام کاربری قبلا در سامانه ثبت نام کرده است");
                return apiResult;
            }
            var existingEmail = await _userManager.FindByEmailAsync(request.Email);
            if (existingEmail != null)
            {
                apiResult.IsSuccess = false;
                apiResult.Result = null;
                apiResult.StatusCode = System.Net.HttpStatusCode.NotFound;
                apiResult.ErrorMessages.Add("این ایمیل قبلا در سامانه ثبت نام کرده است");
                return apiResult;

            }
            var user = new ApplicationUser
            {
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.UserName,
                EmailConfirmed = true
            };
            var result = await _userManager.CreateAsync(user, request.Password);

            if (result.Succeeded)
            {

                await _userManager.AddToRoleAsync(user, "Employee");
                RegistrationResponse registrationResponse=   new RegistrationResponse() { UserId = user.Id };
                apiResult.IsSuccess = true;
                apiResult.Result = registrationResponse;
                apiResult.StatusCode = System.Net.HttpStatusCode.OK;
                return apiResult;
            }
            else
            {
                throw new Exception($"{result.Errors}");
            }

        }
        #endregion

    }
}
