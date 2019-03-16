using System;
using System.Collections.Generic;
using System.Text;

namespace cts.web.core.Jwt
{
    public interface IJWTFactory
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <param name="jti"></param>
        /// <param name="expire"></param>
        /// <returns></returns>
        string CreateToken(User user, string jti, DateTime expire);
    }
}
