using System;
using KnockKnock.Common;
using KnockKnock.Logic;

namespace KnockKnock.Service.Concrete
{
    public class TriangleTypeService : ITriangleTypeService
    {
        public TriangleTypeService(IShapeFinderLogic service)
        {
            Service = service;
        }

        private IShapeFinderLogic Service { get; }

        /// <summary>
        ///     Returns the type of triange given the lengths of its sides
        /// </summary>
        /// <param name="a">The length of side a</param>
        /// <param name="b">The length of side b</param>
        /// <param name="c">The length of side c</param>
        /// <returns>String</returns>
        public ShapeType GetTriangleType(string a, string b, string c)
        {
            var sidea = 0;
            if (int.TryParse(a, out sidea) && int.TryParse(b, out sidea) && int.TryParse(c, out sidea))
                return Service.GetShape(int.Parse(a), int.Parse(b), int.Parse(c));
            throw new InvalidCastException();
        }
    }
}