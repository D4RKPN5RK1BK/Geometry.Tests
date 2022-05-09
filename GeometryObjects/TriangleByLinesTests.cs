using Geometry.Exceptions;
using Geometry.GeometryObjects;
using System;
using Xunit;

namespace Geometry.Tests.GeometryObjects
{
    public class TriangleByLinesTests
    {
        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(1, 1, 3)]
        [InlineData(0, 2, 1)]
        [InlineData(1, 0, 0)]
        [InlineData(Double.MaxValue, Double.MaxValue, Double.MaxValue)]
        [InlineData(Double.MaxValue, Double.MinValue, Double.MinValue)]
        [InlineData(Double.MaxValue, 0, 0)]
        [InlineData(Double.MaxValue, 0.01, 0.01)]
        [InlineData(10050.01, Double.MinValue, 10000.01)]
        public void CorrectTriangleExceptionTheory(double ab, double bc, double ca)
        {
            Assert.Throws<GeometryException>(() =>
            {
                TriangleByLines triangle = new TriangleByLines(ab, bc, ca);
            });
        }

        [Theory]
        [InlineData(3, 4, 5, 6)]
        [InlineData(0.03, 0.04, 0.05, 0.06)]
        [InlineData(6, 8, 10, 24)]
        [InlineData(9, 12, 15, 54)]
        [InlineData(12, 16, 20, 96)]
        public void TriangleSquareTheory(double ab, double bc, double ca, double square)
        {
            TriangleByLines triangle = new TriangleByLines(ab, bc, ca);
            Assert.Equal(triangle.GetSquare(), square);
        }

        [Theory]
        [InlineData(4, 4, 5, false)]
        [InlineData(7, 8, 10, false)]
        [InlineData(10, 12, 15, false)]
        [InlineData(13, 16, 20, false)]
        [InlineData(3, 4, 5, true)]
        [InlineData(6, 8, 10, true)]
        [InlineData(9, 12, 15, true)]
        [InlineData(12, 16, 20, true)]
        public void TriangleIsStrightTheory(double ab, double bc, double ca, bool isStright)
        {
            TriangleByLines triangle = new TriangleByLines(ab, bc, ca);
            Assert.Equal(triangle.IsStright(), isStright);
        }
    }
}
