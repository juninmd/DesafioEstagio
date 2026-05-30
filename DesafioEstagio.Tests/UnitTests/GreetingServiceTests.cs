using System;
using Xunit;

namespace DesafioEstagio.Tests.UnitTests
{
    public class GreetingServiceTests
    {
        private readonly GreetingService _service = new GreetingService();

        [Theory]
        [InlineData(7, "Good morning")]
        [InlineData(8, "Good morning")]
        [InlineData(11, "Good morning")]
        [InlineData(12, "Good afternoon")]
        [InlineData(13, "Good afternoon")]
        [InlineData(17, "Good afternoon")]
        [InlineData(18, "Good evening")]
        [InlineData(19, "Good evening")]
        [InlineData(23, "Good evening")]
        [InlineData(0, "Good evening")]
        [InlineData(5, "Good evening")]
        [InlineData(6, "Good evening")]
        public void GetGreeting_ReturnsCorrectGreeting_ForGivenHour(int hour, string expected)
        {
            var date = new DateTime(2024, 1, 1, hour, 0, 0);
            var result = _service.GetGreeting(date);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void GetGreeting_ReturnsGoodMorning_At7AM()
        {
            var date = new DateTime(2024, 1, 1, 7, 0, 0);
            var result = _service.GetGreeting(date);
            Assert.Equal("Good morning", result);
        }

        [Fact]
        public void GetGreeting_ReturnsGoodAfternoon_At12PM()
        {
            var date = new DateTime(2024, 1, 1, 12, 0, 0);
            var result = _service.GetGreeting(date);
            Assert.Equal("Good afternoon", result);
        }

        [Fact]
        public void GetGreeting_ReturnsGoodEvening_At6PM()
        {
            var date = new DateTime(2024, 1, 1, 18, 0, 0);
            var result = _service.GetGreeting(date);
            Assert.Equal("Good evening", result);
        }

        [Fact]
        public void GetGreeting_ReturnsGoodEvening_AtMidnight()
        {
            var date = new DateTime(2024, 1, 1, 0, 0, 0);
            var result = _service.GetGreeting(date);
            Assert.Equal("Good evening", result);
        }
    }
}
