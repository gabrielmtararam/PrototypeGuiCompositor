using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrototypeGuiCompositor30;
using PrototypeGuiCompositor20;
using Xunit;

namespace PrototypeGuiCompositor20.Tests
{
    public class MoveCalculatorTests
    {

        [Theory]
        [InlineData(0,0,0,0,0,0,0)]
        public void getNextOffset_AllZeros(double DistanceFromCorner, double MovedSize, double CanvasSize, double mousePosrelativeToMoved, double MousePosRelativeToCanvas, double previousMouseCanvasPosition,double expected)
        {
            double actual = MoveCalculator.getNextOffset( DistanceFromCorner,  MovedSize,  CanvasSize,  mousePosrelativeToMoved,  MousePosRelativeToCanvas,  previousMouseCanvasPosition);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(0, -10, 0, 0, 0, 0, 0)]
        [InlineData(0, -10,-10, 0, 0, 0, 0)]
        [InlineData(0, 0, -10, 0, 0, 0, 0)]
        public void getNextOffset_NegativeSizes(double DistanceFromCorner, double MovedSize, double CanvasSize, double mousePosrelativeToMoved, double MousePosRelativeToCanvas, double previousMouseCanvasPosition, double expected)
        {
            double actual = MoveCalculator.getNextOffset(DistanceFromCorner, MovedSize, CanvasSize, mousePosrelativeToMoved, MousePosRelativeToCanvas, previousMouseCanvasPosition);
            Assert.Equal(expected, actual);
        }


        [Fact]
        public void getNextOffset_MovedGreaterThanCanvas()
        {
            //arange
            // Canvas.GetTop(_MovedElement), _FrMovedElement.ActualHeight, 
            //_myCanvas.ActualHeight, Mouse.GetPosition(_MovedElement).Y, Mouse.GetPosition(_myCanvas).Y, _previousMousePosition.Y)
            double expected = 0;
            double actual = MoveCalculator.getNextOffset(0, 100, 10, 0, 0, 0);

            Assert.Equal(expected, actual);
            //act

            //Assert

        }

        [Fact]
        public void getNextOffset_SimpleValueShoudCalculate()
        {
            //arange
            // Canvas.GetTop(_MovedElement), _FrMovedElement.ActualHeight, 
            //_myCanvas.ActualHeight, Mouse.GetPosition(_MovedElement).Y, Mouse.GetPosition(_myCanvas).Y, _previousMousePosition.Y)
            double expected = 5;
            double actual = MoveCalculator.getNextOffset(5, 10, 100, 5, 10, 0);

            Assert.Equal(expected, actual);
            //act

            //Assert

        }

        [Fact]
        public void getNextOffset_MouseOutOfCanvasNegative()
        {
            //arange
            // Canvas.GetTop(_MovedElement), _FrMovedElement.ActualHeight, 
            //_myCanvas.ActualHeight, Mouse.GetPosition(_MovedElement).Y, Mouse.GetPosition(_myCanvas).Y, _previousMousePosition.Y)
            double expected = 0;
            double actual = MoveCalculator.getNextOffset(5, 10, 100, 5, -10, 0);

            Assert.Equal(expected, actual);
            //act

            //Assert

        }


        [Fact]
        public void getNextOffset_MouseOutOfCanvasPositive()
        {
            //arange
            // Canvas.GetTop(_MovedElement), _FrMovedElement.ActualHeight, 
            //_myCanvas.ActualHeight, Mouse.GetPosition(_MovedElement).Y, Mouse.GetPosition(_myCanvas).Y, _previousMousePosition.Y)
            double expected = 100;
            double actual = MoveCalculator.getNextOffset(5, 10, 100, 5, 105, 0);

            Assert.Equal(expected, actual);
            //act

            //Assert

        }



    }
}
