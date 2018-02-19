using System;
using System.Collections.Generic;
using System.Text;

namespace KnockKnock.Service
{
    public interface ITokenService
    {
        Guid GetToken();
    }
}