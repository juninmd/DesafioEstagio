using System;
using System.Globalization;

namespace DesafioEstagio
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please, insert the operation Signal \n(Example: - or +)");
            var operacao = Console.ReadLine()?.Trim();

            if (string.IsNullOrEmpty(operacao) || (operacao != "-" && operacao != "+"))
            {
                Console.WriteLine("Invalid operation. Use only (+ or -).");
                return;
            }

            Console.WriteLine("Please, insert the value in minutes \n(Example: 10 or 30)");
            var minutosInput = Console.ReadLine()?.Trim();

            if (!int.TryParse(minutosInput, NumberStyles.Integer, CultureInfo.InvariantCulture, out var minutes))
            {
                Console.WriteLine("Invalid minutes value. Enter a valid integer.");
                return;
            }

            var data = DateTime.Now.AddMinutes(minutes < 0 ? minutes : int.Parse(operacao + minutes));

            Console.WriteLine($"{Greeting(data)}! Today is {data.ToString("dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture)}");
            Console.ReadKey();
        }

        private static string Greeting(DateTime data)
        {
            if (data.Hour > 6 && data.Hour < 12)
                return "Good morning";
            if (data.Hour >= 12 && data.Hour < 18)
                return "Good afternoon";
            return "Good evening";
        }
    }
}
