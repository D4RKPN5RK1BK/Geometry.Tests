using Geometry.Exceptions;
using Geometry.GeometryObjects;
using System;
using Xunit;

namespace Geometry.Tests.GeometryObjects
{
    public class CircleTests
    {
        [Theory]
        [InlineData(1, Math.PI)]
        [InlineData(0.0001, 0.0001 * 0.0001 * Math.PI)]
        [InlineData(1000000, 1000000.0 * 1000000.0 * Math.PI)]
        public void CircleSquareTheory(double radius, double square)
        {
            Circle circle = new Circle(radius);
            Assert.Equal(circle.GetSquare(), square);
        }

        [Theory]
        [InlineData(Double.MinValue, false)]
        [InlineData(Double.MaxValue, false)]
        [InlineData(0, false)]
        [InlineData(-0.0001, false)]
        [InlineData(1, true)]
        public void CircleExceptionsTheory(double radius, bool result)
        {
            Assert.Throws<GeometryException>(() =>
            {
                Circle circle = new Circle(radius);
                circle.GetSquare();
                
            });

            Assert.True(result);
        }

    }
}
