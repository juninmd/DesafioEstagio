using System;

namespace DesafioEstagio
{
    public class TimeCalculator
    {
        public DateTime Calculate(DateTime from, string operation, int minutes)
        {
            if (string.IsNullOrEmpty(operation))
                throw new ArgumentException("Operation cannot be null or empty", nameof(operation));
            if (operation != "+" && operation != "-")
                throw new ArgumentException("Operation must be '+' or '-'", nameof(operation));

            int signedMinutes = operation == "-" ? -minutes : minutes;
            return from.AddMinutes(signedMinutes);
        }

        public bool IsValidOperation(string operation)
        {
            return operation == "+" || operation == "-";
        }

        public int ParseMinutes(string input)
        {
            if (string.IsNullOrEmpty(input))
                throw new ArgumentException("Minutes input cannot be null or empty", nameof(input));

            if (!int.TryParse(input, out int minutes))
                throw new ArgumentException("Minutes must be a valid integer", nameof(input));

            return minutes;
        }
    }
}
