using KnockKnock.Logic;
using System;
using System.Collections.Generic;
using System.Text;

namespace KnockKnock.Service.Concrete
{
    public class TokenService : ITokenService
    {
        private ITokenLogic Service { get; }

        public TokenService(ITokenLogic service)
        {
            Service = service;
        }

        public Guid GetToken()
        {
            return Service.GetToken();
        }
    }
}