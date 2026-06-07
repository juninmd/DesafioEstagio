using System;

namespace DesafioEstagio
{
    class Program
    {
        static readonly TimeCalculator _calculator = new TimeCalculator();
        static readonly GreetingService _greeting = new GreetingService();

        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Please, insert the operation Signal \n(Example: - or +)");
                var operacao = Console.ReadLine();

                if (string.IsNullOrEmpty(operacao))
                    throw new InvalidOperationException("Operation cannot be empty");

                if (!_calculator.IsValidOperation(operacao))
                    throw new InvalidOperationException("You should use only (+ or -)");

                Console.WriteLine("Please, insert the value in minutes \n(Example: 10 or 30)");

                var minutosInput = Console.ReadLine();
                var minutos = _calculator.ParseMinutes(minutosInput);

                var data = _calculator.Calculate(DateTime.Now, operacao, minutos);

                Console.WriteLine($"{_greeting.GetGreeting(data)}! Today is {data.ToString("dd/MM/yyyy HH:mm:ss")}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                Console.ReadKey();
            }
        }
    }
}