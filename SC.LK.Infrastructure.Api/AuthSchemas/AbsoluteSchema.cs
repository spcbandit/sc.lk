using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SC.LK.Application.Abstractions;
using SC.LK.Application.Domains.Entities;
using SC.LK.Application.Domains.Enums;
using SC.LK.Infrastructure.Api.Attributes;

namespace SC.LK.Infrastructure.Api.AuthSchemas;

public class AbsoluteSchema: AuthenticationHandler<BasicAuthOptions>
{
     private readonly IRepository<UserEntity> _repositoryUser;
     private readonly IRepository<MethodWithRoles> _repositoryMethodRoles;
     private readonly IRepository<MethodAccessTypeEntity> _repositoryMethodAccess;
     private readonly IRepository<AvailableRolesEntity> _repositoryRoles;
     private readonly IRepository<ContractorEntity> _repositoryContractor;

    public AbsoluteSchema(IRepository<UserEntity> repositoryUser,
        IOptionsMonitor<BasicAuthOptions> options, ILoggerFactory logger,
        UrlEncoder encoder, ISystemClock clock,IRepository<MethodWithRoles> repositoryMethodRoles,
        IRepository<MethodAccessTypeEntity> repositoryMethodAccess,
        IRepository<AvailableRolesEntity> repositoryRoles,
        IRepository<ContractorEntity> repositoryContractor)
        : base(options, logger, encoder, clock)
    {
        _repositoryUser = repositoryUser ?? throw new ArgumentException(nameof(repositoryUser));
        _repositoryMethodRoles = repositoryMethodRoles ?? throw new ArgumentException(nameof(repositoryUser));
        _repositoryMethodAccess = repositoryMethodAccess ?? throw new ArgumentException(nameof(repositoryMethodAccess));
        _repositoryRoles = repositoryRoles ?? throw new ArgumentException(nameof(repositoryRoles));
        _repositoryContractor = repositoryContractor;
    }
    protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        try
        {
            string authHeader = Request.Headers["Authorization"];
            if (authHeader == null)
            { return AuthenticateResult.Fail("Not found Authorization header"); }

            if (!authHeader.Contains("Bearer"))
            { return AuthenticateResult.Fail("Wrong authentication schema"); }

            var token = authHeader.Split(' ')[1];
            if (string.IsNullOrEmpty(token))
            { return AuthenticateResult.Fail("Token was null or empty"); }
            
            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(token);
            if (jwtToken is null)
            { return AuthenticateResult.Fail("Fail to parse jwt token"); }
            
            var role = jwtToken.Claims.FirstOrDefault(x => x.Type == ClaimsIdentity.DefaultNameClaimType);
            if (role is null)
            { return AuthenticateResult.Fail("Role not found"); }
            
            var resultAccess = GetAccess(role.Value);
            if(resultAccess.Success)
            {
                var claims = new[] {new Claim(ClaimTypes.Name, role.Value)};
                    var identity = new ClaimsIdentity(claims);
                    var principal = new ClaimsPrincipal(identity);

                    Context.User = principal;
                    return AuthenticateResult.Success(new AuthenticationTicket(principal, "Basic"));
            }
            else
            {
                return AuthenticateResult.Fail(resultAccess.ErrorMessage);
            }
        }
        catch(Exception exception)
        {
            return AuthenticateResult.Fail(exception);
        }
    }

    private AccessResponse GetAccess(string id)
    {
        
        /*По имени метода находим в базе существующие методы*/
        var route = _repositoryMethodAccess
            .Get(x => x.MethodName == Request.Path.Value.TrimStart('/'))
            .FirstOrDefault();

        
        if (route == null)
        {
            return new AccessResponse()
            {
                Success = false, ErrorMessage =
                    "Method doesn't exist in database. Check correct spelling, or use /methodAccess/addMethodAccess to Create new method"
            };
        }
        
        /*По Id находим существующего user'a*/
        var user = _repositoryUser
            .Get(x => x.Id.ToString() == id)
            .FirstOrDefault();

        if (user == null)
        {
            return new AccessResponse() { Success = false, ErrorMessage = "User doesn't exist" };
        }
        
        /*По id юзера находим MainContractor и ChildContractor*/
        
        /*var getContr = _repositoryContractor.Get(x => x.Id == user.MainContractor).FirstOrDefault();
        
        bool Child()
        {
            var getChild = _repositoryContractor.Any(x => x.Id == getContr.ParentContractorId);
            if(getChild)
                return true;
            return false;
        }

        
        if (getContr == null || (getContr.ParentContractorId != null && Child() == false))
        {
            return new AccessResponse() { Success = false, ErrorMessage = "Can't find contractor" };
        }*/



        /*По Id найденого метода находим его бинд с доступными ролями*/
        var methodWithRoles = _repositoryMethodRoles
            .Get(x => x.MethodAccessTypesEntitiesId == route.Id);
        if (methodWithRoles.Count() == null)
        {
            return new AccessResponse() { Success = false, ErrorMessage = "Can't find binded method to roles" };
        }
        
        /*По Id роли у найденого user'a находим доступную роль*/
        var userRole = _repositoryRoles
            .Get(x => x.Id == user.AvailableRoles)
            .FirstOrDefault();
        if (userRole == null)
        {
            return new AccessResponse() { Success = false, ErrorMessage = "Can't find binded role to user" };
        }
        
        /*Перебираем метод(ы) и выполняем проверку*/
        foreach (var bindedMethods in methodWithRoles)
        {
            /*Находим у опредленного метода Id роли и возвращаем свойства роли*/
            var methodRoles = _repositoryRoles
                .Get(x => x.Id == bindedMethods.AvailableRoleId)
                .FirstOrDefault();
            
            if (bindedMethods.AvailableRoleId == user.AvailableRoles ||
                userRole.RoleType == methodRoles.RoleType ||
                userRole.RoleType == decimal.Zero)
            {
                return new AccessResponse() { Success = true };
            }
            
        }
        
        
        return new AccessResponse() { Success = false , ErrorMessage = "User access denied"};
    }

}

public class AccessResponse
{
    public bool Success { get; set; }
    public string ErrorMessage { get; set; }
}