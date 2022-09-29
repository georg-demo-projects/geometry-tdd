using System;
using System.Collections.Generic;
using System.Linq;

namespace Geometry.Utility
{
    public static class Sort
    {
        /// <summary>
        /// Sort in descending order
        /// </summary>
        public static (double, double, double) Descending(double a, double b, double c)
        {
            if (a > b) (a, b) = (b, a);
            if (b > c) (b, c) = (c, b);
            if (a > b) (a, b) = (b, a);

            return (c, b, a);
        }
    }
}
