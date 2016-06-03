using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioEstagio
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please, insert the operation Signal \n(Example: - or +)");
            var operacao = Console.ReadLine();

            if (String.IsNullOrEmpty(operacao) == false && (operacao != "-" && operacao != "+"))
                throw new Exception("You should use only (+ or -)");

            Console.WriteLine("Please, insert the value in minutes \n(Example: 10 or 30)");

            var minutos = Console.ReadLine();

            var data = DateTime.Now.AddMinutes(int.Parse(int.Parse(minutos) < 0 ? minutos : operacao + minutos));

            Console.WriteLine($"{Cortesia(data)}! Today is {data.ToString("dd/MM/yyyy HH:mm:ss")}");
            Console.ReadKey();
        }

        private static string Cortesia(DateTime data)
        {
            if (data.Hour > 6 && data.Hour < 12)
                return "Good morning";
            if (data.Hour >= 12 && data.Hour < 18)
                return "Good afternoon";
            return "Good evening";
        }
    }
}
