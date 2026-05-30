using System;

namespace DesafioEstagio
{
    public class GreetingService
    {
        public string GetGreeting(DateTime data)
        {
            if (data.Hour > 6 && data.Hour < 12)
                return "Good morning";
            if (data.Hour >= 12 && data.Hour < 18)
                return "Good afternoon";
            return "Good evening";
        }
    }
}
