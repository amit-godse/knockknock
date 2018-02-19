using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace KnockKnock.Logic.Concrete
{
    public class TokenLogic : ITokenLogic
    {
        private IConfiguration _configuration { get; }

        public TokenLogic(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Guid GetToken()
        {
            return Guid.Parse(_configuration["MyToken"]);
        }
    }
}