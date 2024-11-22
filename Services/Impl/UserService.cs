using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using ClinicNetCore.Data;
using ClinicNetCore.Models;
using ClinicNetCore.Models.RequestModels;
using ClinicNetCore.Models.ResponseModels;
using ClinicNetCore.Settings;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace ClinicNetCore.Services.Impl;

public class UserService : IUserService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<ApplicationRole> _roleManager;
    private readonly IConfiguration _configuration;
    private readonly ApplicationDbContext _context;
    
    public UserService(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager,
        IConfiguration configuration, ApplicationDbContext context)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _configuration = configuration;
        _context = context;
    }

    public async Task<LoginResponse> Login(LoginRequest request)
    {
        var user = await _userManager.FindByNameAsync(request.UserName);
        if (user == null)
        {
            throw new Exception("Username not exist");
        }

        var loginResponse = await _userManager.CheckPasswordAsync(user, request.Password);
        if (!loginResponse)
        {
            throw new Exception("Username or Password incorrect");
        }

        var token = await GenerateTokenJwtByUser(user);
        /*var userRoles = await _userManager.GetRolesAsync(user);
        List<string> claims = new List<string>();
        foreach (string role in userRoles)
        {
            var roleData = await _roleManager.FindByNameAsync(role);
            if (roleData != null)
            {
               var roleClaims = await _roleManager.GetClaimsAsync(roleData);
               foreach (Claim claim in roleClaims)
               {
                   claims.Add(claim.Value);
               }
            }
        }*/

        /*var fullName = user.FullName;*/
        return new LoginResponse
        {
            Token = new JwtSecurityTokenHandler().WriteToken(token),
        };
    }

    public async Task<bool> Registration(RegistrationRequest request)
    {
        var user = new ApplicationUser
        {
            Id = Guid.NewGuid(),
            UserName = request.Email,
            PhoneNumber = request.PhoneNumber,
            Email = request.Email,
            FullName = request.FullName,
            Address = request.Address
        };
        
        var newUser = await _userManager.CreateAsync(user, request.Password);
        if (!newUser.Succeeded) return false;
        await _userManager.AddToRolesAsync(user, request.Roles);
        return true;
    }
    
    public async Task<GetUserById> GetUserById(Guid userId)
    {
        var user = await _userManager.FindByIdAsync(userId.ToString());
        return new GetUserById
        {
            Id = user.Id,
            Email = user.Email,
            PhoneNumber = user.PhoneNumber,
            FullName = user.FullName
        };
    }
    private async Task<JwtSecurityToken> GenerateTokenJwtByUser(ApplicationUser user)
    {
        var authClaims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
        };

        var userRoles = await _userManager.GetRolesAsync(user);
        foreach (string role in userRoles)
        {
            var roleData = await _roleManager.FindByNameAsync(role);
            if (roleData != null)
            {
                var roleClaims = await _roleManager.GetClaimsAsync(roleData);
                foreach (Claim claim in roleClaims)
                {
                    authClaims.Add(claim);
                }
            }
        }

        /*if (user.UserName.Equals("tdao7"))
        {
            authClaims.Add(new Claim(ClaimTypes.Role, "CombinedCourse.Write"));
        }

        authClaims.Add(new Claim(ClaimTypes.Role, "manyRole"));*/

        /*foreach (var userRole in userRoles)
        {
            authClaims.Add(new Claim(ClaimTypes.Role, userRole));
        }*/
        

        var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(DefaultApplication.SecretKey));

        var token = new JwtSecurityToken(
            issuer: _configuration["JWT:ValidIssuer"],
            audience: _configuration["JWT:ValidAudience"],
            expires: DateTime.Now.AddHours(24),
            claims: authClaims,
            signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256));

        return token;
    }
}