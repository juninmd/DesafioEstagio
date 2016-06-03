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
            Console.WriteLine("Please, insert the value in minutes \n(Example: -10/30)");
            var minutos = Console.ReadLine();

            var data = DateTime.Now.AddMinutes(int.Parse(minutos));

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
