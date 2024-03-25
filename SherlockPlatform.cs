using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Data; 
using System.Net;
using System.Security.Claims;
using System.Text;
using Match.Platform.Secrets;
using Server.Util;

namespace SherlockPlatform
{
    public class SherlockAuthGen: ISherlockAuthGen
    {
        private IMemoryCache _cache;
        private IConfiguration _config;
        private readonly ICachedSecretsManager _secrets;
        public SherlockAuthGen(ICachedSecretsManager secrets, IMemoryCache cache, IConfiguration cofig)
        {
            _cache = cache;
            _config = cofig;
            _secrets = secrets;

        }
        public async Task<SherlockAuth> GetToken()
        {
            string secret = _config["Jwt:Key"];
            var CachedToken = await _cache.GetOrCreateAsync(
            secret,
            cacheEntry =>
            {
                var token = GenerateJSONWebToken();
                cacheEntry.SlidingExpiration = TimeSpan.FromSeconds(600);
                return Task.FromResult(token);
            });
            var obj = new SherlockAuth
            {
                Token = CachedToken,
                UserId = "PK",
                UserName = "Mal",
                Role = "TESTPK"
            };
            return obj;
        }


        public async Task<string> GenerateToken(string secret)
        {
            IdentityOptions identityOptions = new IdentityOptions();
            var claims = new Claim[]
            {
                        new Claim("Lid","123456789"),
                        new Claim(identityOptions.ClaimsIdentity.UserNameClaimType,"PK"),
                        new Claim(identityOptions.ClaimsIdentity.UserNameClaimType,"Mal"),
                        new Claim(identityOptions.ClaimsIdentity.RoleClaimType,"TESTPK")
            };
            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
            var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
            var jwt = new JwtSecurityToken("Test.com", "Test.com",
      claims,
      expires: DateTime.Now.AddMinutes(120),
      signingCredentials: signingCredentials);
            //var jwt = new JwtSecurityToken(signingCredentials: signingCredentials,
            //    claims: claims, expires: DateTime.Now.AddSeconds(3000));

            var obj = new SherlockAuth
            {
                Token = new JwtSecurityTokenHandler().WriteToken(jwt),
                UserId = "PK",
                UserName = "Mal",
                Role = "TESTPK"
            };
            return obj.Token;
        }

        public string getVaultSecret()
        {
          var secret =   _secrets.GetSecret<SherlockPipelinesSecretData>(SherlockPipelinesSecretData.PATH);
            return secret.Key;
        }

        private string GenerateJSONWebToken( )
        { 
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(getVaultSecret()));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
                 new Claim("name", "govind"),
                //new Claim(JwtRegisteredClaimNames.Email, userInfo.EmailAddress),
                //new Claim("DateOfJoing", userInfo.DateOfJoing.ToString("yyyy-MM-dd")),
                //new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }


    }
}
