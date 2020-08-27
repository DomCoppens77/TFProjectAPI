using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace TFProjectAPI.MiddleWare
{
    public static class AuthenticationExtension
    {
        //Add following Nugget Pack : System.IdentityModel.Tokens.Jwt
        //Add following Nugget Pack : Microsoft.IdentityModel.Tokens
        //Add following Nugget Pack : Microsoft.AspNetCore.Authentication.JwtBearer 

        public static IServiceCollection AddTokenAuthentication(this IServiceCollection services, IConfiguration config)
        {
            var secret = config.GetSection("JwtConfig").GetSection("secret").Value;

            var key = Encoding.ASCII.GetBytes(secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                    //ValidIssuer = "localhost",
                    //ValidAudience = "localhost"
                };
            });

            return services;
        }
    }
}
