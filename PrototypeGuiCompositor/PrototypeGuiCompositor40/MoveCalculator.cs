using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypeGuiCompositor30
{
    public static class MoveCalculator
    {
        public static double getNextOffset( double DistanceFromCorner, double MovedSize, double CanvasSize, double mousePosrelativeToMoved, double MousePosRelativeToCanvas, double previousMouseCanvasPosition)
        {
            if (MovedSize < 0)
                return 0;

            if (CanvasSize < 0)
                return 0;

            if (mousePosrelativeToMoved > MovedSize)
                mousePosrelativeToMoved = MovedSize;
            else if (mousePosrelativeToMoved < 0)
                mousePosrelativeToMoved = 0;

            var position = CanvasSize + DistanceFromCorner;
            var rightDistance = CanvasSize + DistanceFromCorner + MovedSize;
            var maxLeftOfset = CanvasSize - mousePosrelativeToMoved;

            if (DistanceFromCorner - MovedSize < 0)
            {
                if (((MousePosRelativeToCanvas - mousePosrelativeToMoved) <= 0))
                {
                    if (((MousePosRelativeToCanvas > MovedSize / 2) && (previousMouseCanvasPosition < MousePosRelativeToCanvas)))
                    {
                        return (1);
                    }
                    return (0);
                }
            }
            else if (DistanceFromCorner + MovedSize >= maxLeftOfset)
            {
                if (mousePosrelativeToMoved + MousePosRelativeToCanvas <= CanvasSize)
                    return (MousePosRelativeToCanvas - MovedSize / 2);
                return (CanvasSize - MovedSize);
            }
            else if (DistanceFromCorner == 0)
            {
                if ((MousePosRelativeToCanvas <= 0) || (MousePosRelativeToCanvas >= CanvasSize))
                {
                    return (MousePosRelativeToCanvas - mousePosrelativeToMoved);
                }
            }
            return (MousePosRelativeToCanvas - MovedSize / 2);
        }
    }
}
