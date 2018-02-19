using KnockKnock.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace KnockKnock.Logic
{
    public interface IShapeFinderLogic
    {
        ShapeType GetShape(int a, int b, int c);
    }
}