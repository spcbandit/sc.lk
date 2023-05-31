using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SC.LK.Application.Abstractions;
using SC.LK.Application.Domains.Dto;
using SC.LK.Application.Domains.Entities;
using SC.LK.Application.Domains.Requests.Profile;
using SC.LK.Application.Domains.Requests.User;
using SC.LK.Application.Domains.Responses.Profile;
using SC.LK.Application.Extentions;
using Services = SC.LK.Application.Domains.IdentityService.Requests.Services;


namespace SC.LK.Application.Handlers.Profile
{
    internal class LoginUserHandler : IRequestHandler<LoginRequest, LoginResponse>
    {
        
        private readonly IRepository<UserEntity> _repositoryUser;
        private readonly IRepository<QuarantineEntity> _repositoryQuarantine;

        /// <summary>
        /// Логирование пользователя
        /// </summary>
        /// <param name="repositoryUser"></param>
        /// <param name="isClient"></param>
        /// <exception cref="ArgumentException"></exception>
        public LoginUserHandler(IRepository<UserEntity> repositoryUser, IMapper mapper, IRepository<QuarantineEntity> repositoryQuarantine)
        {
            _repositoryUser = repositoryUser ?? throw new ArgumentException(nameof(repositoryUser));
            _repositoryQuarantine = repositoryQuarantine;
        }

        /// <summary>
        /// Логирование пользователя
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<LoginResponse> Handle(LoginRequest request, CancellationToken cancellationToken)
        {
            var user = _repositoryUser
                .GetWithInclude(x => x.Login == request.Login && x.IsDelete != true)
                .FirstOrDefault();
            
            if (user is null)
            {
                return new LoginResponse() {Success = false, ErrorMessage = "Введенный логин не найден"};
            }
            
            if (user.Password != GetHash(request.Password))
            {
                return new LoginResponse() {Success = false, ErrorMessage = "Введенный пароль не верен"};
            }

            if (!user.IsActive)
            {
                return new LoginResponse() {Success = false, ErrorMessage = "Аккаунт не активирован"};
            }
            
            var token = CreateJwtToken(user.Id);
            user.Token = token;
            user.Updated = DateTime.Now;
            //если пользователь заходит раньше, чем истекает срок карантина, то удаляется из карантина
            QuarantineEntity quarantine = _repositoryQuarantine.Get(x => x.QuarantineMemberId == user.MainContractor).FirstOrDefault();
            if (quarantine != null)
            {
                _repositoryQuarantine.Remove(quarantine);
            }
            
            if (_repositoryUser.Update(user) != 0)
            {
                return new LoginResponse() {Success = true, Token = token, UserId = user.Id};
            }

            return new LoginResponse() {Success = false, ErrorMessage = MessageResource.FailedLogin};
        }

        /// <summary>
        /// Создание JWT токена
        /// </summary>
        /// <param name="login"></param>
        /// <param name="role"></param>
        /// <returns></returns>
        private string CreateJwtToken(Guid? id)
        {
            var now = DateTime.UtcNow;

            var jwt = new JwtSecurityToken(
                issuer: MessageResource.JWT_Issuer,
                audience: MessageResource.JWT_Audience,
                notBefore: now,
                claims: CreateClaims(id).Claims,
                expires: now.Add(TimeSpan.FromMinutes(Convert.ToInt32(MessageResource.JWT_LifetimeInMinute))),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(MessageResource.JWT_Key)), SecurityAlgorithms.HmacSha256));
            
            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }

        /// <summary>
        /// Создание клеймов пользователя
        /// </summary>
        /// <param name="username"></param>
        /// <param name="roleEntity"></param>
        /// <returns></returns>
        private ClaimsIdentity CreateClaims(Guid? id)
        {
            var claims = new List<Claim>
            {
                new (ClaimsIdentity.DefaultNameClaimType, id.Value.ToString()?? throw new ArgumentNullException(nameof(id)))
            };
            
            var claimsIdentity = new ClaimsIdentity(claims, 
                "JWTAuth", 
                ClaimsIdentity.DefaultNameClaimType, 
                ClaimsIdentity.DefaultRoleClaimType);
            
            return claimsIdentity;
        }
        
        
        /// <summary>
        /// Хэширование строки
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        private string GetHash(string password)
        {
            var sha1 = new SHA1CryptoServiceProvider();
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(password);
            return Encoding.UTF8.GetString(sha1.ComputeHash(plainTextBytes));
        }
    }
}
