using System;
using Microsoft.Extensions.Configuration;

namespace KnockKnock.Logic.Concrete
{
    public class TokenLogic : ITokenLogic
    {
        public TokenLogic(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private IConfiguration _configuration { get; }

        public Guid GetToken()
        {
            return Guid.Parse(_configuration["MyToken"]);
        }
    }
}