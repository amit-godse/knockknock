using KnockKnock.Common;

namespace KnockKnock.Service
{
    public interface ITriangleTypeService
    {
        ShapeType GetTriangleType(string a, string b, string c);
    }
}