using System;
using System.IO;
using Xunit;

namespace DesafioEstagio.Tests.E2ETests
{
    public class ConsoleE2ETests
    {
        [Fact]
        public void CompletePositiveFlow_Addition_PrintsCorrectOutput()
        {
            var input = $"+{Environment.NewLine}60{Environment.NewLine}";
            var expectedMinutes = 60;

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

                    Assert.Contains("Please, insert the operation Signal", output);
                    Assert.Contains("Please, insert the value in minutes", output);

                    var expectedDate = DateTime.Now.AddMinutes(expectedMinutes);
                    Assert.Contains(expectedDate.ToString("dd/MM/yyyy"), output);

                    var hour = expectedDate.Hour;
                    string expectedGreeting;
                    if (hour > 6 && hour < 12)
                        expectedGreeting = "Good morning";
                    else if (hour >= 12 && hour < 18)
                        expectedGreeting = "Good afternoon";
                    else
                        expectedGreeting = "Good evening";

                    Assert.Contains(expectedGreeting, output);
                }
                finally
                {
                    Console.SetIn(originalIn);
                    Console.SetOut(originalOut);
                }
            }
        }

        [Fact]
        public void CompletePositiveFlow_Subtraction_PrintsCorrectOutput()
        {
            var input = $"-{Environment.NewLine}30{Environment.NewLine}";
            var expectedMinutes = -30;

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

                    var expectedDate = DateTime.Now.AddMinutes(expectedMinutes);
                    Assert.Contains(expectedDate.ToString("dd/MM/yyyy HH:mm"), output);
                }
                finally
                {
                    Console.SetIn(originalIn);
                    Console.SetOut(originalOut);
                }
            }
        }

        [Fact]
        public void CompleteFlow_WithZeroMinutes_WorksCorrectly()
        {
            var input = $"+{Environment.NewLine}0{Environment.NewLine}";

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

                    var now = DateTime.Now;
                    Assert.Contains(now.ToString("dd/MM/yyyy HH:mm"), output);
                }
                finally
                {
                    Console.SetIn(originalIn);
                    Console.SetOut(originalOut);
                }
            }
        }

        [Fact]
        public void InvalidInput_OperationNotRecognized_ShowsErrorMessage()
        {
            var input = $"notvalid{Environment.NewLine}10{Environment.NewLine}";

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
    }
}
