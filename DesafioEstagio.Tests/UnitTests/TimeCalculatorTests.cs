using System;
using Xunit;

namespace DesafioEstagio.Tests.UnitTests
{
    public class TimeCalculatorTests
    {
        private readonly TimeCalculator _calculator = new TimeCalculator();

        [Fact]
        public void Calculate_AddsMinutes_WhenOperationIsPlus()
        {
            var baseDate = new DateTime(2024, 1, 1, 10, 0, 0);
            var result = _calculator.Calculate(baseDate, "+", 30);
            Assert.Equal(new DateTime(2024, 1, 1, 10, 30, 0), result);
        }

        [Fact]
        public void Calculate_SubtractsMinutes_WhenOperationIsMinus()
        {
            var baseDate = new DateTime(2024, 1, 1, 10, 0, 0);
            var result = _calculator.Calculate(baseDate, "-", 30);
            Assert.Equal(new DateTime(2024, 1, 1, 9, 30, 0), result);
        }

        [Fact]
        public void Calculate_AddsZeroMinutes_DoesNotChangeDate()
        {
            var baseDate = new DateTime(2024, 1, 1, 10, 0, 0);
            var result = _calculator.Calculate(baseDate, "+", 0);
            Assert.Equal(baseDate, result);
        }

        [Fact]
        public void Calculate_CanCrossMidnight()
        {
            var baseDate = new DateTime(2024, 1, 1, 23, 30, 0);
            var result = _calculator.Calculate(baseDate, "+", 45);
            Assert.Equal(new DateTime(2024, 1, 2, 0, 15, 0), result);
        }

        [Fact]
        public void Calculate_CanCrossDateBoundaryBackwards()
        {
            var baseDate = new DateTime(2024, 1, 1, 0, 15, 0);
            var result = _calculator.Calculate(baseDate, "-", 30);
            Assert.Equal(new DateTime(2023, 12, 31, 23, 45, 0), result);
        }

        [Theory]
        [InlineData("+")]
        [InlineData("-")]
        public void IsValidOperation_ReturnsTrue_ForValidOperations(string operation)
        {
            Assert.True(_calculator.IsValidOperation(operation));
        }

        [Theory]
        [InlineData("*")]
        [InlineData("/")]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("++")]
        [InlineData("add")]
        public void IsValidOperation_ReturnsFalse_ForInvalidOperations(string operation)
        {
            Assert.False(_calculator.IsValidOperation(operation));
        }

        [Fact]
        public void Calculate_Throws_WhenOperationIsNull()
        {
            var ex = Assert.Throws<ArgumentException>(() =>
                _calculator.Calculate(DateTime.Now, null, 10));
            Assert.Contains("operation", ex.Message, StringComparison.OrdinalIgnoreCase);
        }

        [Fact]
        public void Calculate_Throws_WhenOperationIsInvalid()
        {
            var ex = Assert.Throws<ArgumentException>(() =>
                _calculator.Calculate(DateTime.Now, "*", 10));
            Assert.Contains("operation", ex.Message, StringComparison.OrdinalIgnoreCase);
        }

        [Fact]
        public void ParseMinutes_ReturnsInteger_ForValidInput()
        {
            var result = _calculator.ParseMinutes("30");
            Assert.Equal(30, result);
        }

        [Fact]
        public void ParseMinutes_Throws_ForNullInput()
        {
            var ex = Assert.Throws<ArgumentException>(() =>
                _calculator.ParseMinutes(null));
            Assert.Contains("minutes", ex.Message, StringComparison.OrdinalIgnoreCase);
        }

        [Fact]
        public void ParseMinutes_Throws_ForEmptyInput()
        {
            var ex = Assert.Throws<ArgumentException>(() =>
                _calculator.ParseMinutes(""));
            Assert.Contains("minutes", ex.Message, StringComparison.OrdinalIgnoreCase);
        }

        [Fact]
        public void ParseMinutes_Throws_ForNonNumericInput()
        {
            var ex = Assert.Throws<ArgumentException>(() =>
                _calculator.ParseMinutes("abc"));
            Assert.Contains("minutes", ex.Message, StringComparison.OrdinalIgnoreCase);
        }

        [Fact]
        public void ParseMinutes_Throws_ForNegativeNumberString()
        {
            var ex = Assert.Throws<ArgumentException>(() =>
                _calculator.ParseMinutes("-5"));
            Assert.Contains("minutes", ex.Message, StringComparison.OrdinalIgnoreCase);
        }
    }
}
