using KnockKnock.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace KnockKnock.Service
{
    public interface ITriangleTypeService
    {
        ShapeType GetTriangleType(string a, string b, string c);
    }
}