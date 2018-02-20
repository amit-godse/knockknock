using System;
using KnockKnock.Logic;

namespace KnockKnock.Service.Concrete
{
    public class TokenService : ITokenService
    {
        public TokenService(ITokenLogic service)
        {
            Service = service;
        }

        private ITokenLogic Service { get; }

        public Guid GetToken()
        {
            return Service.GetToken();
        }
    }
}