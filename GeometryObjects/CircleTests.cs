using Geometry.Exceptions;
using Geometry.GeometryObjects;
using System;
using Xunit;

namespace Geometry.Tests.GeometryObjects
{
    public class CircleTests
    {
        [Theory]
        [InlineData(1, Math.PI)] // Проверка единичной окружности
        [InlineData(2, 4 * Math.PI)] // Обычных чисел
        [InlineData(0.0001, 0.0001 * 0.0001 * Math.PI)] // Проверка на малые числа
        [InlineData(1000000, 1000000.0 * 1000000.0 * Math.PI)] // Проверка на большие числа
        public void CircleSquareTheory(double radius, double square)
        {
            Circle circle = new Circle(radius);
            Assert.Equal(circle.GetSquare(), square);
        }

        [Theory]
        [InlineData(Double.MinValue)]
        [InlineData(Double.MaxValue)]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-10)]
        [InlineData(-0.0001)]
        public void CircleExceptionsTheory(double radius)
        {
            Assert.Throws<GeometryException>(() =>
            {
                Circle circle = new Circle(radius);
                circle.GetSquare();
            });
        }

    }
}
