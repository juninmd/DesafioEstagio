using System;
using System.IO;
using Xunit;

namespace DesafioEstagio.Tests.IntegrationTests
{
    public class ProgramIntegrationTests
    {
        [Theory]
        [InlineData("+", "30")]
        [InlineData("-", "15")]
        [InlineData("+", "0")]
        public void FullFlow_ProducesExpectedOutput(string operation, string minutes)
        {
            var input = $"{operation}{Environment.NewLine}{minutes}{Environment.NewLine}";
            var expectedHour = CalculateExpectedHour(operation, int.Parse(minutes));

            using (var reader = new StringReader(input))
            using (var writer = new StringWriter())
            {
                var originalIn = Console.In;
                var originalOut = Console.Out;
                Console.SetIn(reader);
                Console.SetOut(writer);

                try
                {
                    Program.Main(new string[0]);
                    var output = writer.ToString();

                    Assert.Contains("Today is", output);
                    Assert.Contains(expectedHour, output);
                }
                finally
                {
                    Console.SetIn(originalIn);
                    Console.SetOut(originalOut);
                }
            }
        }

        [Theory]
        [InlineData("*")]
        [InlineData("x")]
        [InlineData("")]
        public void InvalidOperation_ShowsErrorMessage(string operation)
        {
            var input = $"{operation}{Environment.NewLine}10{Environment.NewLine}";

            using (var reader = new StringReader(input))
            using (var writer = new StringWriter())
            {
                var originalIn = Console.In;
                var originalOut = Console.Out;
                Console.SetIn(reader);
                Console.SetOut(writer);

                try
                {
                    Program.Main(new string[0]);
                    var output = writer.ToString();
                    Assert.Contains("Error:", output);
                }
                finally
                {
                    Console.SetIn(originalIn);
                    Console.SetOut(originalOut);
                }
            }
        }

        private string CalculateExpectedHour(string operation, int minutes)
        {
            var now = DateTime.Now;
            var delta = operation == "+" ? minutes : -minutes;
            var result = now.AddMinutes(delta);
            return result.ToString("dd/MM/yyyy HH:mm:ss");
        }
    }
}
