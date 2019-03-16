﻿using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;

namespace cts.web.core.Jwt
{
    public class JWTFactory : IJWTFactory
    {
        private JWTTokenOptions _tokenOptions;

        public JWTFactory(JWTTokenOptions jWTTokenOptions)
        {
            _tokenOptions = jWTTokenOptions;

        }

        /// <summary>
        /// 生成一个新的 Token
        /// </summary>
        /// <param name="user">用户信息实体</param>
        /// <param name="expire">token 过期时间</param>
        /// <param name="audience">Token 接收者</param>
        /// <returns></returns>
        public string CreateToken(User user, string jti, DateTime expire)
        {
            var handler = new JwtSecurityTokenHandler();
            var claims = new[]
            {
                new Claim(ClaimTypes.PrimarySid,user.PrimarySid.ToString()),
                new Claim(ClaimTypes.UserData, user.UserID), 
                new Claim(JwtRegisteredClaimNames.Jti,jti,ClaimValueTypes.String) // jti，用来标识 token
            };
            ClaimsIdentity identity = new ClaimsIdentity(new GenericIdentity(user.UserName, "TokenAuth"), claims);
            var token = handler.CreateEncodedJwt(new SecurityTokenDescriptor
            {
                Issuer = _tokenOptions.Issuer,
                Audience = _tokenOptions.Audience,
                SigningCredentials = _tokenOptions.Credentials,
                Subject = identity,
                Expires = expire
            });
            return token;
        }
    }
}
