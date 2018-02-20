using System;
using KnockKnock.Common;

namespace KnockKnock.Logic.Concrete
{
    public class ShapeFinderLogic : IShapeFinderLogic
    {
        public ShapeType GetShape(int a, int b, int c)
        {
            if (a <= 0 || b <= 0 || c <= 0) return ShapeType.Error;

            if (Math.Abs(b - c) >= a || Math.Abs(a - c) >= b || Math.Abs(a - b) >= c) return ShapeType.Error;

            if (b + c < a || a + c < b || a + b < c) return ShapeType.Error;

            if (a == b && a == c) return ShapeType.Equilateral;

            if (a == b || a == c || b == c) return ShapeType.Isosceles;

            return ShapeType.Scalene;
        }
    }
}