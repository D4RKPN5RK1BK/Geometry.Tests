using Geometry.Exceptions;
using Geometry.GeometryObjects;
using System;
using Xunit;

namespace Geometry.Tests.GeometryObjects
{
    public class TriangleByLinesTests
    {
        [Theory]
        [InlineData(0, 0, 0, false)]
        [InlineData(1, 1, 3, false)]
        [InlineData(0, 2, 1, false)]
        [InlineData(Double.MaxValue, Double.MaxValue, Double.MaxValue, false)]
        [InlineData(Double.MaxValue, Double.MinValue, Double.MinValue, false)]
        [InlineData(Double.MaxValue, 0, 0, false)]
        [InlineData(Double.MaxValue, 0.01, 0.01, false)]
        [InlineData(10050.01, Double.MinValue, 10000.01, false)]
        [InlineData(3, 4, 5, true)]
        [InlineData(0.01, 0.01, 0.01, true)]
        public void CorrectTriangleExceptionTheory(double ab, double bc, double ca, bool result)
        {
            if (result)
            {
                Assert.Throws<GeometryException>(() =>
                {
                    TriangleByLines triangle = new TriangleByLines(ab, bc, ca);
                });
            }
            else
            {
                Assert.True(true);
            }
            
        }

        [Theory]
        [InlineData(3, 4, 5, 6, true)]
        [InlineData(0.03, 0.04, 0.05, 50, false)]
        public void TriangleSquareTheory(double ab, double bc, double ca, double square, bool result)
        {
            
            TriangleByLines triangle = new TriangleByLines(ab, bc, ca);

            if (result)
            {
                Assert.Equal(triangle.GetSquare(), square);
            }
            else
            {
                Assert.NotEqual(triangle.GetSquare(), square);
            }
            
        }

        [Theory]
        [InlineData(4, 4, 5, false)]
        [InlineData(3, 4, 5, true)]
        public void TriangleIsStrightTheory(double ab, double bc, double ca, bool isStright)
        {
            TriangleByLines triangle = new TriangleByLines(ab, bc, ca);
            Assert.Equal(triangle.IsStright(), isStright);
        }
    }
}
